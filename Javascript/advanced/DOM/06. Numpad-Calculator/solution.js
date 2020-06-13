function solve() {
    for(let button of document.getElementsByTagName('button')){
        if(button.classList[0] == 'clear') {
            button.addEventListener('click', clear);
            }
        else if(button.value == '=') {
            button.addEventListener('click', solv);
        }
        else {
            button.addEventListener('click', function(){addSymbol(button.value)});
        }
    }
    let lastsymbol;
    function addSymbol(symbol){
        if(document.getElementById("resultOutput").innerText != '') clear();
        if(lastsymbol == '+' || lastsymbol == '-' || lastsymbol == '*' || lastsymbol == '/') symbol = " "+symbol;
        lastsymbol=symbol;
        if(symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/') symbol =" "+symbol;
        document.getElementById("expressionOutput").innerText += symbol;
    }
    function clear(){
        document.getElementById("expressionOutput").innerText = '';
        document.getElementById("resultOutput").innerText = '';
    }
    function solv(){
        let array = document.getElementById("expressionOutput").innerText.split(' ');
        let result;
        if(array.length != 3 || Number(array[0]) == NaN || (array[2]) == NaN) result = 'NaN';
        else
        {
            let [first, operator, second] = array
            if(operator == '+') result = Number(first) + Number(second);
            if(operator == '-') result = Number(first) - Number(second);
            if(operator == '*') result = Number(first) * Number(second);
            if(operator == '/') {
                if(second == 0) result = 'NaN';
                else result = Number(first) / Number(second);
            }

        }
        document.getElementById("resultOutput").innerText = result;
    }
}