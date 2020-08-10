let t = 0;

function add(a,b) {return t+a+b};

function changeT(newvalue){
    t = newvalue;
}

export {add, changeT}

//You must install nvm and use a newer one than 12.1