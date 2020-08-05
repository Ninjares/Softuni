const templates = {};
const loadingBox = document.getElementById('loadingBox');
const infoBox = document.getElementById('infoBox');
const errorBox= document.getElementById('errorBox');

const firebaselink = "https://furniture-153e2.firebaseio.com";

function toggleLoader(load){
    if(load){ //Why won't the const work?
        document.getElementById('loadingBox').style.display = "block";
    }
    else {
        document.getElementById('loadingBox').style.display = "";
    }

}

function onCreatePageLoad(redirector) {
    const newMake = document.getElementById("new-make");
    const newModel = document.getElementById("new-model");
    const newYear = document.getElementById("new-year");
    const newDescription = document.getElementById("new-description");
    const newPrice = document.getElementById("new-price");
    const newImage = document.getElementById("new-image");
    const newMaterial = document.getElementById("new-material");
    const createBtn = document.getElementById("create-btn");

    createBtn.addEventListener('click', () => {
        const furniture = {
            make: newMake.value, 
            model: newModel.value,
            year: newYear.value,
            description: newDescription.value,
            price: newPrice.value,
            image: newImage.value,
            material: newMaterial.value
        }
        const furniturearray = [
            newMake.value, 
            newModel.value,
            newYear.value,
            newDescription.value,
            newPrice.value,
            newImage.value,
            newMaterial.value
        ]
        console.log(furniturearray.filter(x => x !=""));
        if(furniturearray.filter(x => x !="").length !== 7) console.error("MISSING DATA");
        else
            fetch(`${firebaselink}/furniture/.json`, {method: 'POST', body: JSON.stringify(furniture)}).then(() => {
                redirector('#/furniture/all');
            });
        
    });
}


function getTemplate(templateUrl){ //why does it return a promise? I don't quite get it
    if(templates[templateUrl] !== undefined) return Promise.resolve(templates[templateUrl]);
    return fetch(`Resources/templates/${templateUrl}.hbs`).then(response => response.text()).then(templateString => {
        templates[templateUrl]  = Handlebars.compile(templateString);
        return templates[templateUrl];
    });
    
}

function renderTemplate(templatePath, templateContext, swapFn){
    return getTemplate(templatePath).then(templateFn => {
        const content = templateFn(templateContext);
        console.log(templateContext);
        swapFn(content);
    });
}

function  registerPartialTemplate (templatePath, templateName) {
    fetch(`Resources/templates/partials/${templatePath}.hbs`).then(res => res.text()).then(template => {
        Handlebars.registerPartial(
            templateName, 
            template
        );
        //console.log(template);
        //return template;
    });
}

function loadFurniture(id) {
    if(id !== undefined){
        return fetch(`${firebaselink}/furniture/${id}.json`).then(x => x.json());
    }
    else
    return fetch(`${firebaselink}/furniture/.json`).then(x => x.json())
    .then(data => {
        return Object.keys(data).reduce((acc, currId) => {
            const currentItem = data[currId];
            return acc.concat({id: currId, ...currentItem});
        }, []);
    });
}

const app = Sammy('#container',function(){
    this.before({/*exceptions and options}*/}, function(){
        toggleLoader(true);
    });
    this.get('/#/furniture/profile', function(){
        renderTemplate('profile', {}, this.swap.bind(this))
        .then(() => toggleLoader(false));
    });
    this.get('/#/furniture/create', function(){
        renderTemplate('create-furniture', {}, this.swap.bind(this))
        .then(() => {
            toggleLoader(false);
            onCreatePageLoad(this.redirect.bind(this));
        });
    });
    this.get('/#/furniture/details/:id', function(context){
        const id = context.params.id;
        loadFurniture(id).then().then(furniture => {
            renderTemplate('furniture-details', {furniture}, this.swap.bind(this))
            .then(() => toggleLoader(false));
        });
    });
    this.get('#/', function(){
        Promise.all([loadFurniture(), registerPartialTemplate('furniture-item', 'furnitureItem')])
        .then(([items]) => {console.log("too early" + items); renderTemplate('furniture-system', {items}, this.swap.bind(this));})
        .then(() => {
            toggleLoader(false)
        });
    });
});



app.run('/#/'); //depends which will be the first page to load

//1. npm init
//2. npm i local-web-server
//3. npm install sammy,handlebarsm,jquery
//4. npm run serve

//$() means communicating with jquery