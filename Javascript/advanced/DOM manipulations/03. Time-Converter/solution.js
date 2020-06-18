function attachEventsListeners() {
    for(let converter of document.getElementsByTagName('div')){
        let frame = converter.children[0].getAttribute('for');
        switch(frame){
            case 'days': {  
                converter.children[2].addEventListener('click', function(){ 
                    let days = document.getElementById('days').value;
                    document.getElementById('hours').value = days * 24;
                    document.getElementById('minutes').value = days * 24 * 60; 
                    document.getElementById('seconds').value = days * 24 * 60 * 60;
                }); 
                break;
            }
            case 'hours': {  
                converter.children[2].addEventListener('click', function(){ 
                    let hours = document.getElementById('hours').value;
                    document.getElementById('days').value = hours / 24;
                    document.getElementById('minutes').value = hours * 60; 
                    document.getElementById('seconds').value = hours * 60 * 60;
                }); 
                break;
            }
            case 'minutes': {  
                converter.children[2].addEventListener('click', function(){ 
                    let minutes = document.getElementById('minutes').value;
                    document.getElementById('days').value = minutes / 24 / 60;
                    document.getElementById('hours').value = minutes / 60; 
                    document.getElementById('seconds').value = minutes * 60;
                }); 
                break;
            }
            case 'seconds': {  
                converter.children[2].addEventListener('click', function(){ 
                    let seconds = document.getElementById('seconds').value;
                    document.getElementById('days').value = seconds / 24 / 60 / 60;
                    document.getElementById('hours').value = seconds  / 60 / 60; 
                    document.getElementById('minutes').value = seconds / 60 ;
                }); 
                break;
            }
        }
    }
}
