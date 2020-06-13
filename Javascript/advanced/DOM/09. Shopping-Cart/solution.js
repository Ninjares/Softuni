function solve() {
   let list = [];
   let logg = '';
   document.querySelector('.checkout').addEventListener('click', checkout);
   for(let product of document.querySelectorAll('.product')){
      product.children[2].firstElementChild.addEventListener('click', addtolist);
      
   }

   function addtolist(evt){
      let name = evt.currentTarget.parentNode.parentNode.children[1].children[0].innerText;
      let price = Number(evt.currentTarget.parentNode.parentNode.children[3].innerText);
      list.push({name, price});
      logg += "Added "+name+" for "+price.toFixed(2)+" to the cart." + '\n';
      document.getElementsByTagName('textarea')[0].innerHTML = logg;
   }

   function checkout(){
      let toadd = getnames(list).join(', ');
      let sum = getsum(list);
      logg += "You bought "+toadd+" for "+sum.toFixed(2)+"."+'\n';
      document.getElementsByTagName('textarea')[0].innerHTML = logg;
      document.querySelector('.checkout').removeEventListener('click', checkout);
      for(let product of document.querySelectorAll('.product')){
         product.children[2].firstElementChild.removeEventListener('click', addtolist);
      }
   }

   function getnames(array){
      let newarray = [];
      for(let product of array){
         if(!newarray.includes(product.name))
         newarray.push(product.name);
      }
      return newarray;
   }
   function getsum(array){
      let sum = 0;
      for(let product of array){
         sum += product.price;
      }
      return sum;
   }
}