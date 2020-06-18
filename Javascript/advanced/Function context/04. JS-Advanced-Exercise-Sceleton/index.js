function solve(){
   for(let i=0; i<document.getElementsByTagName('tbody')[0].children.length; i++){
      document.getElementsByTagName('tbody')[0].children[i].addEventListener('click', highlight);
   }


   function highlight(e){
      if(e.currentTarget.style.backgroundColor == ''){
         clearList();
         e.currentTarget.style.backgroundColor = '#413f5e';
      }
      else 
      e.currentTarget.style.backgroundColor = '';
   }

   function clearList(){
      for(let i=0; i<document.getElementsByTagName('tbody')[0].children.length; i++){
         document.getElementsByTagName('tbody')[0].children[i].style.backgroundColor = '';
      }
   }
}
