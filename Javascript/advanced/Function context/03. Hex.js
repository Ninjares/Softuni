class Hex{
    constructor(value){
        this.decimalValue = value;
    }
    valueOf(){
        return this.decimalValue;
    }
    toString(){
        return '0x'+(this.decimalValue >>> 0).toString(16).toUpperCase();
    }
    plus(hex){
        return new Hex(this.decimalValue + hex.valueOf());
    }
    minus(hex){
        return new Hex(this.decimalValue - hex.valueOf());
    }
    parse(hexString){
        this.decimalValue = parseInt(hexString, 16);
        return this;
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');