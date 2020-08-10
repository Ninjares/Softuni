export function loadingNotification(show){
    if(show) document.querySelector('#loadingBox').style.display = 'block';
    else document.querySelector('#loadingBox').style.display = 'none';
}
export function showError(message){
    document.querySelector('#errorBox').style.display = 'block';
    document.querySelector('#errorBox').innerText = message;
}
export function successNotification(message){
    document.querySelector('#successBox').innerText = message;
    document.querySelector('#successBox').style.display = 'block';
    setTimeout(() => {
        document.querySelector('#successBox').style.display = 'none';
        document.querySelector('#successBox').innerText = '';
    }, 5000)
}