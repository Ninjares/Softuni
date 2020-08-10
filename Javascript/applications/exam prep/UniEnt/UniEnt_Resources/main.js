//const { Exception } = require("handlebars");

//import * as firebase from "https://www.gstatic.com/firebasejs/7.17.1/firebase-app.js";
var firebaseConfig = {
    apiKey: "AIzaSyD8iCiZGLeE5iV8RKn8uMXXP2_ViAMmJKg",
    authDomain: "unient-c1b12.firebaseapp.com",
    databaseURL: "https://unient-c1b12.firebaseio.com",
    projectId: "unient-c1b12",
    storageBucket: "unient-c1b12.appspot.com",
    messagingSenderId: "697545956916",
    appId: "1:697545956916:web:8680388664a60db675f461"
};
// firebase.initializeApp(firebaseConfig);

import {loadingNotification} from './controllers/notificationController.mjs'; //type="module" in the html

// function loadingNotification(show){
//     if(show) document.querySelector('#loadingBox').style.display = 'block';
//     else document.querySelector('#loadingBox').style.display = 'none';
// }
function showError(message){
    document.querySelector('#errorBox').style.display = 'block';
    document.querySelector('#errorBox').innerText = message;
}
function successNotification(message){
    document.querySelector('#successBox').innerText = message;
    document.querySelector('#successBox').style.display = 'block';
    setTimeout(() => {
        document.querySelector('#successBox').style.display = 'none';
        document.querySelector('#successBox').innerText = '';
    }, 5000)
}

function signInUser(username, password, redirector){
    return fetch(`${firebaseConfig.databaseURL}/users/.json`).then(res => res.json()).then(x => {
        const users = Object.keys(x).reduce((arr, key) => {
            return arr.concat({key, ...x[key]});
        }, []);
        if(users.filter(x => x.password == password && x.username == username).length == 0){
            throw new Error('Invalid username and/or password');
        }
        else{
            let userId = users.filter(x => x.password == password && x.username == username)[0].key;
            sessionStorage.setItem('userId', userId);
            sessionStorage.setItem('username', username);
            redirector('/#/');
        }
    });
}
function registerUser(username, password, rePassword, redirector){
    if(password !== rePassword) return Promise.reject(new Error('Passwords do not macth'));
    return fetch(`${firebaseConfig.databaseURL}/users/.json`, {method: 'POST', body: JSON.stringify({username, password})}).then(res => {
        if(res.status == 200){
            successNotification('User registered successfully');
            setTimeout(function (){
                return signInUser(username, password, redirector);
            }, 1500);
        };
    });
}
function signOutUser(){
    //firebase.auth().signOut();
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('username')
}
function userIsSingedIn(){
    return sessionStorage.getItem('userId') != null && sessionStorage.getItem('userId') != 'null';
}


function organizeEvent(name, dateTime, description, imageURL) {
    return fetch(`${firebaseConfig.databaseURL}/events/.json`, {method: 'POST', body:JSON.stringify({name, dateTime, description, imageURL, OrganizerId: sessionStorage.getItem('userId'), OrganizerName: sessionStorage.getItem('username'), usersInterested: JSON.stringify([sessionStorage.getItem('userId')])})}).then(res => {
        if(res.status == 200){
            successNotification('Event successfully created');
        }
    }).catch(err => err);
}
function EditEvent(id, name, dateTime, description, imageURL) {
    getEvent(id).then(x => {
        x.name = name;
        x.dateTime = dateTime;
        x.description = description;
        x.imageURL = imageURL;
        fetch(`${firebaseConfig.databaseURL}/events/${id}.json`, {method: 'PUT', body: JSON.stringify(x)});
    })
}
function getEvent(id){
    if(id) return fetch(`${firebaseConfig.databaseURL}/events/${id}.json`).then(x => x.json())
    return fetch(`${firebaseConfig.databaseURL}/events/.json`).then(x => x.json()).then(data => {
        if(data == null) return [];
        return Object.keys(data).reduce((acc, currId) => {
            const currentItem = data[currId];
            return acc.concat({id: currId, name: currentItem.name, imageURL: currentItem.imageURL, OrganizerId: currentItem.OrganizerId });
        }, []);
    })
}



let templates = [];
function getTemplate(templateUrl){ //why does it return a promise? I don't quite get it
    if(templates[templateUrl] !== undefined) return Promise.resolve(templates[templateUrl]);
    //console.log(`/templates/${templateUrl}.hbs`);
    return fetch(`/templates/${templateUrl}.hbs`).then(response => response.text()).then(templateString => {
        templates[templateUrl]  = Handlebars.compile(templateString);
        return templates[templateUrl];
    });  
}
function renderTemplate(templatePath, templateContext, swapFn){
    return getTemplate(templatePath).then(templateFn => {
        const content = templateFn(templateContext);
        //console.log(templateContext);
        swapFn(content);
    });
}
function  registerPartialTemplate (templatePath, templateName) {
    fetch(`/templates/${templatePath}.hbs`).then(res => res.text()).then(template => {
        Handlebars.registerPartial(
            templateName, 
            template
        );
        //console.log(template);
        //return template;
    });
}


let hbData;
const app = Sammy('#mainContainer', function(){
    this.before({}, function(){
        document.querySelector('#errorBox').style.display = 'none';
        loadingNotification(true);
        registerPartialTemplate('partial/navbar', 'navbar');
        hbData = { SignedIn: userIsSingedIn(), username: sessionStorage.getItem('username'), userId: sessionStorage.getItem('userId')};
    });
    this.get('#/', function(){
        if(userIsSingedIn()) {loadingNotification(true); this.redirect('#/allEvents');}
        else{
        renderTemplate('home', hbData, this.swap.bind(this))
        .then(loadingNotification(false)).catch(err => showError(err));
        }
        
    });
    this.get('#/404', function(context) {
        renderTemplate('404', hbData, this.swap.bind(this)).then(loadingNotification(false)).catch(err => showError(err));
    });
    this.get('#/login', function(){
        renderTemplate('forms/login', hbData, this.swap.bind(this)).then(loadingNotification(false));
    })
    this.post('#/login', function(context){
        loadingNotification(true);
        const {username, password} = context.params;
        signInUser(username, password, this.redirect.bind(this)).catch(err => showError(err));
    })
    this.get('#/register', function(){
        renderTemplate('forms/register', hbData, this.swap.bind(this)).then(loadingNotification(false));
    });
    this.post('#/register', function(context){
        loadingNotification(true);
        const {username, password, rePassword} = context.params;
        registerUser(username, password, rePassword, this.redirect.bind(this)).catch(err => showError(err));
    });
    this.get('#/logout', function(){
        signOutUser();
        this.redirect('/#/');
    });

    this.get('#/organize', function(){
        renderTemplate('forms/organize', hbData, this.swap.bind(this)).then(loadingNotification(false)).catch(err => showError(err));
    });
    this.post('#/organize', function (context) {
        const {name, dateTime, description, imageURL} = context.params;
        organizeEvent(name, dateTime, description, imageURL).then(loadingNotification(true)).then(() => {
            setTimeout(() => {this.redirect('#/')}, 1000);
        }).catch(err => showError(err));
    });
    this.get('#/allEvents', function(){
        Promise.all([getEvent(), registerPartialTemplate('partial/event-template', 'eventBox')]).then(([events]) => {
            if(events.length == 0) this.redirect('#/404')
            else{
            hbData.events = events;
            renderTemplate('event-list', hbData, this.swap.bind(this));
            }
        }).then(loadingNotification(false)).catch(err => showError(err));
    });
    this.get('#/event/:id', function(context){
        const eventId = context.params.id;
        getEvent(eventId).then(event => {
            hbData.event = event;
            hbData.organizerOfEvent = hbData.event.OrganizerId == sessionStorage.getItem('userId');
            hbData.event.usersInterested = JSON.parse(hbData.event.usersInterested).length;
            hbData.event.id = eventId;
            renderTemplate('details', hbData, this.swap.bind(this));
        }).then(loadingNotification(false)).catch(err => showError(err));
    });
    this.get('#/event/edit/:id', function(context){
        let eventId = context.params.id;
        getEvent(eventId).then(event => {
            hbData.event = event;
            hbData.event.id = eventId;
        renderTemplate('forms/edit', hbData, this.swap.bind(this)).then(loadingNotification(false)).catch(err => showError(err));
        })
    });
    this.post('#/event/edit/:id', function(context){
        getEvent(context.params.id).then(loadingNotification(true)).then(event => {
            event.name = context.params.name;
            event.dateTime = context.params.dateTime;
            event.description = context.params.description;
            event.imageURL = context.params.imageURL;
            fetch(`${firebaseConfig.databaseURL}/events/${context.params.id}.json`, {method: 'PUT', body: JSON.stringify(event)}).then(successNotification('Entry successfully updated')).then(() =>{
               this.redirect(`#/event/${context.params.id}`)
            });
            
        }).catch(err => showError(err));
    });
    this.get('#/event/delete/:id', function(context){
        fetch(`${firebaseConfig.databaseURL}/events/${context.params.id}.json`, {method: 'DELETE'}).then(successNotification('Deletion successful')).catch(err => showError(err));;
        this.redirect('#/allEvents');
        
    });
    this.get('#/user/:id', function(context){
        fetch(`${firebaseConfig.databaseURL}/users/${context.params.id}/.json`).then(x => x.json()).then(user => {
            getEvent().then(x => x.filter(event => event.OrganizerId == context.params.id)).then(x => {
                hbData.events = x;
                renderTemplate('userpage', hbData, this.swap.bind(this))
            });
        }).then(loadingNotification(false)).catch(err => showError(err));
    });
    this.get('#/join/:id', function(context){
        let eventId = context.params.id;
        let currentUser = sessionStorage.getItem('userId');
        getEvent(eventId).then(event =>{
            let participants = JSON.parse(event.usersInterested);
            if(participants.filter(x => x == currentUser).length > 0) throw new Error('You already have joined this event');
            else {
            participants.push(currentUser);
            event.usersInterested = JSON.stringify(participants);
            fetch(`${firebaseConfig.databaseURL}/events/${eventId}.json`, {method: 'PUT', body: JSON.stringify(event)})
            .then(() => {successNotification('You have successfully joined the event')})
            .then(() => {setTimeout(this.redirect(`#/event/${eventId}`), 1000)});
            }
        }).then(loadingNotification(false)).catch(err => showError(err));
    })
    
});

app.run('/#/');