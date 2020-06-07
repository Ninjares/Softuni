'use strict';

function heroicInventory(input) {
    let result = [];
    for (const str of input) {
        let [name, level, items] = str.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];
        result.push({ name, level, items });
    }
    return JSON.stringify(result);
}

function jsonsTable(input) {
    let table = [];
    for (const str of input) {
        let clas = JSON.parse(str);
        table.push(clas);
    }
    let result = '<table>\n';
    for (let row of table) {
        result += '    <tr>\n';
        for (let element in row) {
            result += '        <td>' + row[element] + '</td>\n';
        }
        result += '    </tr>\n';
    }
    result += '</table>';
    return result;
}

function CappyJuice(input) {
    let juices = [];
    let bottles = [];
    for (let juice of input) {
        let name = juice.split(' => ')[0];
        let quantity = Number(juice.split(' => ')[1]);
        if (juices[name] == null) juices[name] = quantity;
        else juices[name] += quantity;
        while (juices[name] >= 1000) {
            if (bottles[name] == null) bottles[name] = 0;
            bottles[name] += 1;
            juices[name] -= 1000;
        }
    }
    let ret = "";
    for (const bottle in bottles) {
        ret += bottle + " => " + bottles[bottle]+'\n';
    }
    return ret;
}

function store(input) {
    let products = {};
    for (let prd of input) {
        const [name, quantity] = prd.split(' : ')
        let letter = name[0];
        if (products.hasOwnProperty(letter) === false) {
            products[letter] = {};
        }
        products[letter][name] = quantity;
    }
    let output = "";
    for (let letter of Object.keys(products).sort((a, b) => { if (a > b) return 1; if (a < b) return -1; else return 0; })) {
        output += letter + '\n';
        for (let product of Object.keys(products[letter]).sort((a, b) => { if (a > b) return 1; if (a < b) return -1; else return 0; })) {
            output += '\t' + product + ': ' + products[letter][product] + '\n';
        }
    }
    return output;
}

function cars(input) {
    let catalog = {};
    for (let car of input) {
        let [brand, model, price] = car.split(' | ');
        if (catalog[brand] == null) catalog[brand] = {};
        if (catalog[brand][model] == null) catalog[brand][model] = 0;
        catalog[brand][model] += Number(price);
    }
    let output = "";
    for (let brand of Object.keys(catalog)) {
        output += brand + '\n';
        for (let carmodel in catalog[brand]) {
            output += '###' + carmodel + ' -> ' + catalog[brand][carmodel] +'\n';
        }
    }
    return output;
}

function system(input) {
    let systems = {};
    for (let comp of input) {
        let [system, component, subcomponent] = comp.split(' | ');
        if (systems[system] == null) systems[system] = {};
        if (systems[system][component] == null) systems[system][component] = [];
        systems[system][component].push(subcomponent);
    }
    let output = "";
    for (let sys of Object.keys(systems)
        .sort((a, b) => {
            if (Object.keys(systems[a]).length < Object.keys(systems[b]).length) return 1; else if (Object.keys(systems[a]).length > Object.keys(systems[b]).length) return -1; else
            { if (String(a).toUpperCase() < String(b).toUpperCase()) return -1; else if (String(a).toUpperCase() > String(b).toUpperCase()) return 1; else return 0; }
            })
    )
    {
        output += sys + '\n';

        for (let comp of Object.keys(systems[sys]).sort((a, b) => { if (systems[sys][a].length < systems[sys][b].length) return 1 ; else if (systems[sys][a].length > systems[sys][b].length) return -1; else return 0; })) {
            output += '|||' + comp + '\n';
            for (let subc of systems[sys][comp])
                output += '||||||' + subc + '\n';
        }
    }
    return output;
}

class Request{
    //constructor() {
    //    this.method = '';
    //    this.url = '';
    //    this.version = '';
    //    this.message = '';
    //    this.response = undefined;
    //    this.fulfilled = false;
    //}
    constructor(method, url, version, message) {
        this.method = method;
        this.uri = url;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
}
let myclass = new Request('GET', 'google.com', 'HTTP/1.1', '');

class Test {
    constructor(a) {
        this.input = a;
    }
    getDestination(ay) {
        return input + ' ' + ay;
    }
}
let test = new Test('yabumpa');

class Tickets {
    constructor(array, sortingcriteria) {
        let alltickets = [];
        for (let input of array) {
            let [dest, price, stat] = input.split('|');
            alltickets.push({ destination: dest, price: Number(price), status: stat });
        }
    }
}

function ticketsolver(tcks, sortby) {
    let newticket = class Ticket {
        constructor(inp) {
            let [dest, price, stat] = inp.split('|');
            this.destination = dest;
            this.price = Number(price);
            this.status = stat;
        }
    }
    let tickets = [];
    for (let input of tcks) {
        tickets.push(new newticket(input));
    }
    let sorter;
    if (sortby == 'destination') sorter = (a, b) => { if (a.destination < b.destination) return -1; else if (a.destination > b.destination) return 1; else return 0; }
    if (sortby == 'price') sorter = (a, b) => { if (a.price < b.price) return -1; else if (a.price > b.price) return 1; else return 0; }
    if (sortby == 'status') sorter = (a, b) => { if (a.status < b.status) return -1; else if (a.status > b.status) return 1; else return 0; }
    return tickets.sort(sorter);
}

class List {
    constructor() {
        this.array = [];
        this.size = 0;
    }
    add(element) {
        this.array.push(element);
        this.array.sort((a, b) => a - b);
        this.size = this.array.length;
    }
    remove(position) {
        if (position >= 0 && position < this.array.length) {
            this.array.splice(position, 1);
            this.array.sort((a, b) => a - b);
        }
        this.size = this.array.length;
    }
    get(position) {
        if (position >= 0 && position < this.array.length)
        return this.array[position];
    }
}
ticketsolver(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination');


class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }
    increase(length) {
        this.innerLength += length;
    };
    decrease(length) {
        if (length > this.innerLength) this.innerLength = 0;
        else this.innerLength -= length;
    }
    toString() {
        if (this.innerString.length <= this.innerLength) return this.innerString;
        else return this.innerString.substring(0, this.innerLength) + '...';
    }
}

let stringer = new Stringer('Test', 5);
console.log(stringer.toString());
stringer.decrease(2);
console.log(stringer);
console.log(stringer.toString());
console.log();
