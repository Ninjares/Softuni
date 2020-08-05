const fetch = require('./node_modules/node-fetch');
Promise.resolve(2).then(x => x+1).then(x => x*x).then(x => console.log(x));

console.log('before');
function doAsync(){ 
    return new Promise(function(resolve, reject) {
        setTimeout(function() {
        if(true) resolve('yes');
        reject(new Error('noooooooooo'));
    }, 500);
    })
    .then(function(res) {
    return 'Then returned: ' + res;
});
}

doAsync().then(x => console.log(x)).catch(x => console.log(x)); //return x in catch means like you've processed the error

console.log('after');

async function AsyncF(url){
    try{
    let result = await fetch(url);
    console.log(await result.text());
    throw new Error('BUMPAAAA');  //error could be a return state of 404
    }
    catch(error){
        console.log(error);
    }
}

console.log(AsyncF('https://api.banggood.com/product/getProductInfo?access_token=tests31df51sa35d4fW4E68F4Atest&product_id=27827¤cy=USD&lang=en'));