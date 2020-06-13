function solve() {
    document.getElementById("send").addEventListener('click', addmessage)
 
    function addmessage(){
       let message = document.getElementById('chat_input').value;
       if(message != '' && message != null){
       let div = document.createElement('div');
       div.setAttribute('class', 'message my-message');
       div.innerText = document.getElementById('chat_input').value;
       document.getElementById('chat_messages').appendChild(div);
       document.getElementById('chat_input').value = '';
       }
    }
 }
 