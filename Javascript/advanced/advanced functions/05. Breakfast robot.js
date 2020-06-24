function solution(){
    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }
    const storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    function restock(element, quantity){
        if(storage[element] != null && quantity>0){
        storage[element]+= Number(quantity);
        return 'Success';
        } else return 'error' ;
    }
    function prepare(recipe, quantity){
        if(recipes[recipe] === undefined) return 'Error';
        else{
            rec = Object.entries(recipes[recipe]);
            rec.forEach(element => {
                element[1] *= quantity;
            });
            //console.log(rec);
            if(_sufficient(rec)===true){
                for(let ingr of rec){
                    storage[ingr[0]] -= ingr[1];
                }
                return 'Success' ;
            }
            else return _sufficient(rec);
        }
    }
    function report(){
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
    }

    function _sufficient(rec){
        let ok = true;
        for(let ingr of rec){
            if(storage[ingr[0]] - ingr[1] <0) return `Error: not enough ${ingr[0]} in stock`;
        }
        return ok;
    }

    return (argument) => {
        if(argument == 'report') return report();
        if(argument.split(' ')[0] == 'prepare') return prepare(argument.split(' ')[1], Number(argument.split(' ')[2]));
        if(argument.split(' ')[0] == 'restock') return restock(argument.split(' ')[1], Number(argument.split(' ')[2]));
    }
}


let manager = solution();

console.log(manager('restock flavour 50'));
console.log(manager('prepare lemonade 4'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 3'));
// console.log(manager('prepare apple 1'));
// console.log(manager('prepare apple 1'));
console.log(manager('report'));