function solve(){
    const _proto = {};
    const instance = {} ;
    instance.extend = function extend(template){
        for(let prop in template){
            if(typeof template[prop] === 'function'){
                _proto[prop] = template[prop];
            }
            else{
                instance[prop] = template[prop];
            }
        }
    }
    instance._proto_ = _proto;
    return instance;
}

const myinstance = solve();
myinstance.extend({
    extensionMethod: function (){console.log('yabumpa')},
    extensionProperty: 'someString'
    });
console.log(myinstance);