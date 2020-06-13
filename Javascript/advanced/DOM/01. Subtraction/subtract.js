
function result(){
    let num1 = Number(document.getElementById("firstNumber").value);
    let num2 = Number(document.getElementById("secondNumber").value);
    document.getElementById("result").innerHTML = num1 - num2;
}
result();