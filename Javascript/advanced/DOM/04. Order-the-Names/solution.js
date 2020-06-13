function solve() {
    document.querySelector('button').addEventListener('click', addStudent);
    document.getElementsByTagName("input")[0].addEventListener("keydown", function(e){
        if(e.keyCode === 13) addStudent();
    })
    const collection = document.querySelectorAll('ol > li');
    let dictionary = {};
    for(let i=65; i<=90; i++){
        dictionary[String.fromCharCode(i)] = collection[i-65].innerHTML;
    }
    console.log(dictionary);
    function addStudent(){
        let nameToAdd =  document.getElementsByTagName('input')[0].value;
        if(nameToAdd != '')
        {
        nameToAdd = nameToAdd[0].toUpperCase() + nameToAdd.slice(1).toLowerCase();
        if(dictionary[nameToAdd[0].toUpperCase()] == "") dictionary[nameToAdd[0].toUpperCase()] = nameToAdd;
        else dictionary[nameToAdd[0].toUpperCase()] += ", " + nameToAdd;
        collection[nameToAdd.charCodeAt(0) - 65].innerHTML = dictionary[nameToAdd[0]];
        document.getElementsByTagName("input")[0].value = '';
        }
    }
}
