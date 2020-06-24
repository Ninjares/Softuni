function solve() {
    document.getElementById('exercise').children[2].addEventListener('click', onclick);
    const field = document.getElementById('exercise').children[1];
    document.getElementsByTagName('input')[0].disabled = false;

    function onclick(){
        let furniture = JSON.parse(field.value);
        for(let furn of furniture){
            let newfurniture = document.createElement('tr');

            let img = document.createElement('img');
            img.src = furn.img
            let td1 = document.createElement('td');
            td1.appendChild(img);
            newfurniture.appendChild(td1);

            let name = document.createElement('p');
            name.innerText = furn.name;
            let td2 = document.createElement('td');
            td2.appendChild(name);
            newfurniture.appendChild(td2);

            let price = document.createElement('p');
            price.innerText = furn.price;
            let td3 = document.createElement('td');
            td3.appendChild(price);
            newfurniture.appendChild(td3);

            let decFactor = document.createElement('p');
            decFactor.innerText = furn.decFactor;
            let td4 = document.createElement('td');
            td4.appendChild(decFactor);
            newfurniture.appendChild(td4);

            let checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            let td5 = document.createElement('td');
            td5.appendChild(checkbox);
            newfurniture.appendChild(td5);

            document.getElementsByTagName('tbody')[0].appendChild(newfurniture);
        }
    }

    document.getElementsByTagName('button')[1].addEventListener('click', buy);
    function buy(){
        let shoppingCart = [];
        for(let article of document.querySelector('tbody').children){
            if(article.children[4].firstElementChild.checked===true)
            {
                let toadd = {};
                toadd.name = article.children[1].firstElementChild.innerHTML;
                toadd.price = Number(article.children[2].firstElementChild.innerHTML);
                toadd.decFactor = Number(article.children[3].firstElementChild.innerHTML);
                shoppingCart.push(toadd);
            }
        }
        
        let result = '';
        if(shoppingCart.length!=0){
        result += `Bought furniture: ${shoppingCart.map(fur => fur.name).join(', ')}\n`;
        result += `Total price: ${shoppingCart.map(fur => fur.price).reduce((a,b) => a+b).toFixed(2)}\n`;
        result += `Average decoration factor: ${(shoppingCart.map(fur => fur.decFactor).reduce((a,b) => a+b) / shoppingCart.length).toFixed(1)}`;
        document.getElementsByTagName('textarea')[1].value = result;
        }

    }
}