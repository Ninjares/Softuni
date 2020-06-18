function solve() {
   document.getElementById('searchBtn').addEventListener('click', search);
   function search(){
      let searchquery = document.getElementById('searchField').value.trim();
      if(searchquery==''){}
      else{
         for(let element of document.getElementsByTagName('tbody')[0].children){
            element.classList.remove('select');
         }
         for(let element of document.getElementsByTagName('tbody')[0].children){
            let name = element.children[0].innerText.toLocaleLowerCase();
            let email = element.children[1].innerText.toLocaleLowerCase();
            let course = element.children[2].innerText.toLocaleLowerCase();
            if(searchquery!= '' && (name.includes(searchquery) || email.includes(searchquery) || course.includes(searchquery))){
               element.classList.add('select');
            }
         }
      }
      document.getElementById('searchField').value = '';
   }
}

//document.getElementsByTagName('tr')[3].classList.add('select');
//document.getElementsByTagName('tr')[3].classList.remove('select');
