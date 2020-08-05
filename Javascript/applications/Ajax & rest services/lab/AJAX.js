const mod = require('./node_modules/xmlhttprequest');
let url = 'https://api.banggood.com/product/getProductInfo?access_token=tests31df51sa35d4fW4E68F4Atest&product_id=27827¤cy=USD&lang=en';
const httpRequest = new mod.XMLHttpRequest();
httpRequest.addEventListener('readystatechange', function (){
    if(httpRequest.readyState == 4 || httpRequest.status == 200)   {
        console.log(httpRequest.responseText); //in a browser context this is used to change page elements with dom
    }
})
httpRequest.open('GET', url, true);
httpRequest.send();

fetch(url).then(res => console.log(res)); //???