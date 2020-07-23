module.exports.add = function(a,b) {return t+a+b};

let t = 0; //singleton

module.exports.changeT = function(newvalue){
    t = newvalue;
}