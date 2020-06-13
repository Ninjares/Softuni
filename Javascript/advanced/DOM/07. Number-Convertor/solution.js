function solve() {
    document.getElementsByTagName('button')[0].addEventListener('click', convert);
    var bin = document.createElement('option');
    var hex = document.createElement('option');
    bin.value = 'binary';
    bin.innerText = 'Binary';
    hex.value = 'hexadecimal';
    hex.innerText = 'Hexadecimal';
    document.getElementById('selectMenuTo').appendChild(bin);
    document.getElementById('selectMenuTo').appendChild(hex);
    function convert(){
        let result = '';
        let decimal =parseInt(document.getElementById('input').value);
        let to = document.getElementById('selectMenuTo').value;
        if(to=='binary'){
            result = (decimal >>> 0).toString(2)
        }
        if(to=='hexadecimal'){
            result = (decimal >>> 0).toString(16).toUpperCase();
        }
        document.getElementById('result').value = result;
    }
}