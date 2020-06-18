function create(words) {
      for(let word of words){
         let w = document.createElement('div');
         let p = document.createElement('p');
         p.innerText = word;
         p.style.display = 'none';
         w.appendChild(p); 
         w.addEventListener('click', function(){ w.firstChild.style.display = 'block';})
         document.getElementById('content').appendChild(w);
      }
}