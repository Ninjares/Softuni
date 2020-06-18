function notify(message) {
    let notification = document.getElementById('notification');
    notification.style.setProperty('display', 'block');
    notification.innerText = message;
    setTimeout(function(){
        notification.innerText = '';
        notification.style.setProperty('display', 'none');
    }, 2000)
}