function arguments(){
    let numbers = [];
    for(let element of arguments){
        if(numbers[typeof(element)] === undefined) numbers[typeof(element)] = 0;
        numbers[typeof(element)]++;
        console.log(`${typeof(element)}: ${element}`);
    }
    Object.entries(numbers).sort((a,b) => b[1]-a[1]).forEach(element => {
        console.log(`${element[0]} = ${element[1]}`);
    });
}

arguments('cat', 42, function () { console.log('Hello world!');});

