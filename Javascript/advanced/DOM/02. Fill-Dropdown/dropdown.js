function addItem() {
    let text = document.getElementById('newItemText').value;
    let val = document.getElementById('newItemValue').value;
    const option = document.createElement('option');
    option.textContent = text;
    option.value = val;
    document.querySelector("#menu").appendChild(option);
    document.getElementById("newItemText").value = '';
    document.getElementById('newItemValue').value = '';
}