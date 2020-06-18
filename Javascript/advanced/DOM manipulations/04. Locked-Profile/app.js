function lockedProfile() {
    for(let button of document.getElementsByTagName('button')){
        button.addEventListener('click', clickedprofile);
    }

    function clickedprofile(e){
        let profile = e.currentTarget.parentNode;
        let isOpen = profile.children[9].style.display == 'block' ? true : false;
            if(profile.children[2].checked){
            }
            else if(profile.children[4].checked){
                console.log(isOpen);
                if(!isOpen){
                    profile.children[9].style.display = 'block';
                    profile.getElementsByTagName('button')[0].innerText = "Hide it";
                }
                else{
                    profile.children[9].style.display = 'none';
                    profile.getElementsByTagName('button')[0].innerText = "Show more";
                }
            }
    }
}