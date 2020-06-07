'use strict';

console.log('Hello world');

function fruit(fruittype, quantity, price) {
    let kg = (quantity / 1000).toFixed(2);
    let total = (price * kg).toFixed(2);
    let str = "I need $" + total + " to buy " + kg + " kilograms " + fruittype + ".";
    return str;
};

function GCD(a, b) {
    let start;
    if (a > b) start = b;
    else start = a;
    for (var i = start; i >= 1; i--) {
        if (a % i == 0 && b % i == 0) return i;
    }
}

function SameNumbers(numbers) {
    let stringednumbers = numbers.toString();
    let same = true;
    let sum = parseInt(stringednumbers[0]);
    for (let i = 1; i < stringednumbers.length; i++) {
        sum = sum + parseInt(stringednumbers[i]);
        if (stringednumbers[i] != stringednumbers[i - 1]) same = false;
    }
    return same + "\n" + sum;
}

function TimeToWalk(steps, stepmeters, kmh) {
    let totaldistanceKm = steps * stepmeters / 1000;
    let restTime = 0;
    for (let i = 0.5; i < totaldistanceKm; i += 0.5) {
        restTime += 60;
    }
    let Totaltraveltime = ((totaldistanceKm / kmh) * 3600) + restTime;
    let hours = Math.floor(Totaltraveltime / 3600);
    Totaltraveltime -= hours * 3600;
    let Minutes = Math.floor(Totaltraveltime / 60);
    Totaltraveltime -= Minutes * 60;
    let seconds = Math.round(Totaltraveltime);
    return (hours > 9 ? "" + hours : "0" + hours) + ":" + (Minutes > 9 ? "" + Minutes : "0" + Minutes) + ":" + (seconds > 9 ? "" + seconds : "0" + seconds);
}

function RoadRadar(data) {
    let speed = data[0];
    let area = data[1];
    let speedlimits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };
    let result;
    if (speed <= speedlimits[area]) result = '';
    else if (speed > speedlimits[area] && speed <= speedlimits[area] + 20) result = 'speeding';
    else if (speed > speedlimits[area] + 20 && speed <= speedlimits[area] + 40) result = 'excessive speeding';
    else if (speed > speedlimits[area] + 40) result = 'reckless driving';
    return result;
}

function CookingByNumbas(array) {
    let output = '';
    let number = parseInt(array[0]);
    for (let i = 1; i < array.length; i++) {
        switch (array[i]) {
            case 'chop': { number /= 2; break; }
            case 'dice': { number = Math.sqrt(number); break; }
            case 'spice': { number += 1; break; }
            case 'bake': { number *= 3; break; }
            case 'fillet': { number *= 0.8; break; }
        }
        output += number + '\n' ;
    }
    return output;
}

function PointChecker(array) {
    let x1 = array[0], y1 = array[1], x2 = array[2], y2 = array[3];
    let output = "";
    if (Number.isInteger(Math.sqrt(x1 ** 2 + y1 ** 2))) output += "{" + x1 + ', ' + y1 + '} to {0, 0} is valid\n';
    else output += "{" + x1 + ', ' + y1 + '} to {0, 0} is invalid\n';
    if (Number.isInteger(Math.sqrt(x2 ** 2 + y2 ** 2))) output += "{" + x2 + ', ' + y2 + '} to {0, 0} is valid\n';
    else output += "{" + x2 + ', ' + y2 + '} to {0, 0} is invalid\n';

    if (Number.isInteger(Math.sqrt(Math.abs(x1 - x2) ** 2 + Math.abs(y1-y2) ** 2))) output += "{" + x1 + ', ' + y1 + '} to ' + "{" + x2 + ', ' + y2 + '}' + ' is valid\n';
    else output += "{" + x1 + ', ' + y1 + '} to ' + "{" + x2 + ', ' + y2 + '}' + ' is invalid\n';
    
    return output;
}

function CalorieObject(array) {
    let output = {};
    for (let i = 0; i < array.length; i += 2) {
        output[array[i]] = parseFloat(array[i + 1]);
    }
    return output;
}
console.log(fruit([2, 1, 1, 1]));
console.log();


