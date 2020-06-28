function solve() {
    document.querySelector('#container').querySelector('button').addEventListener('click', addPet);
    function addPet(env){
        env.preventDefault();
        let name = document.querySelector('#container').children[0].value.trim();
        let age = document.querySelector('#container').children[1].value.trim();
        let kind = document.querySelector('#container').children[2].value.trim();
        let currentOwner = document.querySelector('#container').children[3].value.trim();
        if((name!==''&&age!==''&&kind!==''&&currentOwner!=='')&&isNaN(age)!==true)//need to check if age is a number, currently only received as string
        {
        let pet = document.createElement('li');
        pet.innerHTML = 
            `<p><strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong></p>
            <span>Owner: ${currentOwner}</span>
            <button>Contact with owner</button>
            `;
        pet.querySelector('button').addEventListener('click', adoptPet);
        document.querySelector('#adoption').querySelector('ul').appendChild(pet);
        }
    }
    function adoptPet(e){
        e.currentTarget.parentNode;
        let div = document.createElement('div');
        div.innerHTML = 
        `<input placeholder="Enter your names">
         <button>Yes! I take it!</button>`;
        div.querySelector('button').addEventListener('click', takePet);
        e.currentTarget.parentNode.appendChild(div);
        e.currentTarget.parentNode.querySelector('button').remove();
    }

    function takePet(e){
        let names = e.currentTarget.parentNode.querySelector('input').value;
        if(names!==''){
            let pet =  e.currentTarget.parentNode.parentNode;
            pet.querySelector('span').innerHTML = `New Owner: ${names}`;
            let newbutton = document.createElement('button');
            newbutton.addEventListener('click', check);
            newbutton.innerText = 'Checked';
            e.currentTarget.parentNode.parentNode.appendChild(newbutton);
            pet.querySelector('div').remove();
            document.querySelector('#adopted').querySelector('ul').appendChild(pet);
            //e.currentTarget.parentNode.parentNode.remove();
        }
    }
    function check(e){
        e.currentTarget.parentNode.remove();
    }
}

