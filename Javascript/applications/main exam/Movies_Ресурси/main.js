var firebaseConfig = {
    apiKey: "AIzaSyD_mMbqA-rdttYH3mCAdQet45-woKzB84w",
    authDomain: "movies-7bac6.firebaseapp.com",
    databaseURL: "https://movies-7bac6.firebaseio.com",
    projectId: "movies-7bac6",
    storageBucket: "movies-7bac6.appspot.com",
    messagingSenderId: "180187138592",
    appId: "1:180187138592:web:3c9f75f6ac2b6d677bca45"
};

function errorMessage(message){
    const errorbox = document.querySelector('#errorBox');
    errorbox.parentNode.style.display = 'block';
    errorbox.innerHTML = message;
    setTimeout(function(){
        errorbox.parentNode.style.display = 'none';
        errorbox.innerHTML = '';
    }, 1000)
}

function successMessage(message){
    const successbox = document.querySelector('#successBox');
    successbox.parentNode.style.display = 'block';
    successbox.innerHTML = message;
    setTimeout(function(){
        successbox.parentNode.style.display = 'none';
        successbox.innerHTML = '';
    }, 1000)
}

let templates = [];
function getTemplate(templateUrl){ 
    if(templates[templateUrl] !== undefined) return Promise.resolve(templates[templateUrl]);
    return fetch(`/templates/${templateUrl}.hbs`).then(response => response.text()).then(templateString => {
        templates[templateUrl]  = Handlebars.compile(templateString);
        return templates[templateUrl];
    });  
}
function renderTemplate(templatePath, templateContext, swapFn){
    return getTemplate(templatePath).then(templateFn => {
        const content = templateFn(templateContext);
        swapFn(content);
    });
}
function  registerPartialTemplate (templatePath, templateName) {
    fetch(`/templates/${templatePath}.hbs`).then(res => res.text()).then(template => {
        Handlebars.registerPartial(
            templateName, 
            template
        );
    });
}

function signInUser(email, password, redirector){
    return fetch(`${firebaseConfig.databaseURL}/users/.json`).then(res => res.json()).then(x => {
        const users = Object.keys(x).reduce((arr, key) => {
            return arr.concat({key, ...x[key]});
        }, []);
        if(users.filter(x => x.password == password && x.email == email).length == 0){
            throw new Error('Invalid email and/or password');
        }
        else{
            let userId = users.filter(x => x.password == password && x.email == email)[0].key;
            sessionStorage.setItem('userId', userId);
            sessionStorage.setItem('email', email);
            successMessage('Login successful.');                                                                                                       
            redirector('/#/');
        }
    });
}
function registerUser(email, password, rePassword, redirector){
    if(password !== rePassword) return Promise.reject(new Error('Passwords do not macth'));
    if(password.length < 6) return Promise.reject(new Error('Password must be at least 6 letters long'));
    if(email == "") return Promise.reject(new Error('No email found'));
    return fetch(`${firebaseConfig.databaseURL}/users/.json`, {method: 'POST', body: JSON.stringify({email, password})}).then(res => {
        if(res.status == 200){
                successMessage('Successful registration!');                                                                                        
                return signInUser(email, password, redirector);
        };
    });
}
function signOutUser(){
    //firebase.auth().signOut();
    sessionStorage.clear();
    successMessage('Successful logout');                                                                                                 
}
function userIsSingedIn(){
    return sessionStorage.getItem('userId') != null && sessionStorage.getItem('userId') != 'null';
}

function addMovie(title, description, imageUrl){
    if(title==""||description==""||imageUrl=="") return Promise.reject(new Error('Invalid inputs!'));
    return fetch(`${firebaseConfig.databaseURL}/movies/.json`, {method: 'POST', body: JSON.stringify(
        {
            title, 
            description, 
            imageUrl,
            creator: sessionStorage.getItem('userId'),
            likes: JSON.stringify([])
        })}).then(res => {if(res.status == 200) successMessage('Created successfully!')});
}
function getMovie(id){
    if(id) return fetch(`${firebaseConfig.databaseURL}/movies/${id}.json`).then(x => x.json());
    return fetch(`${firebaseConfig.databaseURL}/movies/.json`).then(x => x.json()).then(data =>{
        if(data == null) return [];
        return Object.keys(data).reduce((acc, currId) => {
            const currentItem = data[currId];
            return acc.concat({id: currId, title: currentItem.title, imageUrl: currentItem.imageUrl});
        }, []);
    });
}
function editMovie(id, title, description, imageUrl){
    if(title==""||description==""||imageUrl=="") return Promise.reject(new Error('Invalid inputs!'));
    return getMovie(id).then(movie => {
        movie.title = title;
        movie.description = description;
        movie.imageUrl = imageUrl;
        return fetch(`${firebaseConfig.databaseURL}/movies/${id}.json`, {method: 'PUT', body: JSON.stringify(movie)}).then(res => {if(res.status == 200) successMessage('Editted successfully!')});      //success message
    });
}
function likeMovie(id){
    return getMovie(id).then(movie => {
        let currentUser = sessionStorage.getItem('userId');
        let likeArray = JSON.parse(movie.likes);
        if(likeArray.filter(x => x == currentUser).length==0){
            likeArray.push(currentUser);
            movie.likes = JSON.stringify(likeArray);
            return fetch(`${firebaseConfig.databaseURL}/movies/${id}.json`, {method: 'PUT', body: JSON.stringify(movie)});
        }
    });
}

let hbData;
const app = Sammy("#container", function(){
    this.before({}, function(){
        hbData = { SignedIn: userIsSingedIn(), email: sessionStorage.getItem('email'), userId: sessionStorage.getItem('userId')};
        registerPartialTemplate('partials/navbar', 'navbar')
    });
    this.get('/#/', function(){
        if(userIsSingedIn()) {
            Promise.all([getMovie(), registerPartialTemplate('partials/movieList', 'movielist') ,registerPartialTemplate('partials/movie-item', 'moviebox')]).then(([movies]) =>{
                hbData.movies = movies;
                hbData.therearemovies = movies.length !=0;
                renderTemplate('home', hbData, this.swap.bind(this)).catch(err => errorMessage(err));
            });   
        }
        else
        renderTemplate('home', hbData, this.swap.bind(this));
    });
    this.get('/#/login', function(){
        renderTemplate('forms/login', hbData, this.swap.bind(this)).catch(err => errorMessage(err));;
    });
    this.get('/#/register', function(){
        renderTemplate('forms/register', hbData, this.swap.bind(this)).catch(err => errorMessage(err));;
    });
    this.post('/#/login', function(context){
        const {email, password} = context.params;
        signInUser(email, password, this.redirect.bind(this)).catch(err => errorMessage(err));
    });
    this.post('/#/register', function(context){
        const {email, password, repeatPassword} = context.params;
        registerUser(email, password, repeatPassword, this.redirect.bind(this)).catch(err => errorMessage(err));
    });
    this.get('/#/logout', function(){
        signOutUser();
        this.redirect('/#/login');
    });
    this.get('/#/addMovie', function(){
        renderTemplate('forms/addMovie', hbData, this.swap.bind(this)).catch(err => errorMessage(err));
    })
    this.post('/#/addMovie', function(context){
        const {title, description, imageUrl} = context.params;
        addMovie(title, description, imageUrl).then(() => this.redirect('/#/')).catch(err => errorMessage(err));
    });
    this.get('#/details/:id', function(context){
        let movieId = context.params.id;
        getMovie(movieId).then(movie =>{
            hbData.movie = movie;
            hbData.movie.id = movieId;
            hbData.movie.nlikes = JSON.parse(movie.likes).length;
            hbData.IsOwner = movie.creator == sessionStorage.getItem('userId');
            hbData.IsLiked = JSON.parse(movie.likes).filter(x => x == sessionStorage.getItem('userId')).length > 0;
            renderTemplate('movieDetails', hbData, this.swap.bind(this))
        }).catch(err => errorMessage(err));
    });
    this.get('#/edit/:id', function(context){
        let movieId = context.params.id;
        getMovie(movieId).then(movie =>{
            hbData.movie = movie;
            hbData.movie.id = movieId;
            renderTemplate('forms/editMovie', hbData, this.swap.bind(this));
        }).catch(err => errorMessage(err));;
    });
    this.post('#/edit/:id', function(context){
        let movieId = context.params.id;
        let {title, description, imageUrl} = context.params;
        editMovie(movieId,title, description, imageUrl).then(() => {
            this.redirect(`#/details/${movieId}`); // add something to await
        }).catch(err => errorMessage(err));
    });
    this.get('/#/delete/:id', function(context){
        fetch(`${firebaseConfig.databaseURL}/movies/${context.params.id}.json`, {method: 'DELETE'}).then(() => successMessage('Deleted successfully')).then(() => this.redirect('/#/')).catch(err => errorMessage(err));
    });
    this.get('/#/like/:id', function(context){
        let movieId = context.params.id;
        likeMovie(movieId).then(() => this.redirect(`/#/details/${movieId}`)).catch(err => errorMessage(err));
    });
});

app.run('/#/');