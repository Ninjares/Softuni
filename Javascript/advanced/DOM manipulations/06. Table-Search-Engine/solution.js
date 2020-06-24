function solve() {
   document.getElementById('searchBtn').addEventListener('click', search);
   function search(){
      let searchquery = document.getElementById('searchField').value.trim().toLocaleLowerCase();
      if(searchquery.trim().length>0)
      {
         const tbody = document.querySelector('tbody');
         [...tbody.querySelectorAll('tr')].forEach(x => x.classList.remove('select'));
         [...tbody.querySelectorAll('td')].forEach(x => {
            if(x.textContent.trim().toLocaleLowerCase().includes(searchquery)) x.parentNode.classList.add('select');
         });

      }
      document.getElementById('searchField').value = '';
   }
}
