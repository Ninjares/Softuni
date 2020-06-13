function toggle() {
    const visibility = document.getElementById("extra");
    if(visibility.style.display == 'block') 
    { 
        visibility.style.display = 'none'; 
        document.getElementsByClassName("button")[0].innerHTML = "More";
    }
    else if(visibility.style.display == '' || visibility.style.display == 'none') 
    {
        visibility.style.display = 'block'; 
        document.getElementsByClassName("button")[0].innerHTML = "Less";
    }
}