'use strict';

const somearray = [1, 'bumpa', 3, 4]

function addEl(arr, el) {
    arr.push(el);
}
function rest(...rest) {
    console.log(rest);
}
//rest(5, 6, 7);


var otherarray = [...somearray, { bu: "mpa" }];

//addEl(somearray, 5);
//console.log(otherarray);
//console.log(somearray.splice(2, 3, 9));

function ArrrayConstructor1(rest) {
    let output = "";
    for (let i = 0; i < rest.length - 1; i++) {
        output += rest[i] + (i == rest.length-2 ? "" : rest[rest.length - 1]);
    }
    return output;
}

function nthElement(args) {
    let output = "";
    for (let i = 0; i < args.length - 1; i += parseInt(args[args.length - 1])) {
        output += args[i] + '\n';
    }
    return output;
}

function addorremove(array) {
    let output = [];
    let number = 1;
    array.forEach((element) => {
        if (element == 'add') output.push(number);
        else if (element == 'remove') output.pop();
        number++;
    });
    if (output.length == 0) return 'Empty';
    return output.join('\n');
}

function arrayrotator(args) {
    let rotations = parseInt(args.pop()) % (args.length);
    for (let i = 0; i < rotations; i++) {
        args.unshift(args.pop());
    }
    return args.join(' ');
}

function IncreasingArray(array) {
    let outputarray = [];
    let max;
    if (array.length != 0) {
        outputarray.push(array[0]);
        max = array[0];
        array.shift();
    }
    array.forEach((number) => {
        if (number >= max) {
            max = number;
            outputarray.push(number);
        }
    });
    return outputarray.join('\n');
}

function SortArray(array) {
    function byLength(a, b) {
        if (a.length < b.length) return -1;
        if (a.length > b.length) return 1;
        return 0;
    }
    function byAlphabetical(a, b) {
            if (a < b) return -1;
            if (a > b) return 1;
            return 0;
    }
    array.sort(byAlphabetical);
    array.sort(byLength);
    return array.join('\n');
}

function magicMatrices(matrix) {
    let lastsum = null;
    let magical = true;
    for (let i = 0; i < matrix.length && magical; i++) {
        let currentsum = 0;
        for (let j = 0; j < matrix[i].length && magical; j++) {
            currentsum += matrix[i][j];
        }
        if (lastsum == null) lastsum = currentsum;
        if (lastsum != currentsum) magical = false;
    };
    let firstowlength = matrix[0].length;
    for (let i = 0; i < firstowlength && magical; i++) {
        let currentsum = 0;
        for (let j = 0; j < matrix.length && magical; j++) {
            currentsum += matrix[j][i];
        }
        if (lastsum == null) lastsum = currentsum;
        if (lastsum != currentsum) magical = false;
    };
    return magical;
}

function tictactoe(matrix) {

}

console.log(arrayrotator([1,2,3,4, 2]));


console.log();


//.push() return the length of the array
// .pop() returns the element
// .splice() ???