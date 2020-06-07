'use strict';

var obj = {
    1: "test",
    aaa: 3,
    bbb: "reeeeee",
    ccc: function Ce() {
        console.log("bumpa");
    }
};
function returnanumba(numba = -10) {
    return numba;
//}
//let bumpa = readline();
//console.log(bumpa);
console.log('Hello world');
console.log(obj);
console.log(3 == "3");
console.log(3 === "3");
console.log(3 === 3);
console.log(3 != "3");
console.log(3 !== "3");
console.log(3 !== 3);
console.log(0 == -0);
console.log(returnanumba(3));
console.log(typeof 'hi');
    
function foo(a, b, c) {
    console.log(arguments[0]); // 1
    console.log(arguments[4]); // 7
    console.log(arguments[3] + arguments[4]); // 13
    console.log(arguments);
}

    function fruit(fruit, quantity, priceperkilo) {
        return null;
    }
    foo(1, 2, 3, 6, 7);
    console.log();

// Value and type "==="
// Not equal value/type "!=="
//false, null, undefined, NaN, 0, "" - falsy values