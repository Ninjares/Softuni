function solve(){
   document.querySelector('.btn.create').addEventListener('click', addArticle);
   function addArticle(env){
      env.preventDefault();
      let author = document.querySelector('#creator').value;
      let title = document.querySelector('#title').value;
      let category = document.querySelector('#category').value;
      let content = document.querySelector('#content').value;
      let article = document.createElement('article');
      article.innerHTML = 
      `<h1>${title}</h1>
      <p>Category:
         <strong>${category}</strong>
      </p>
      <p>Creator:
         <strong>${author}</strong>
      </p>
      <p>${content}</p>
      <div class="buttons">
         <button class="btn delete">Delete</button>
         <button class="btn archive">Archive</button>
      </div>`;
      article.querySelector('.delete').addEventListener('click', deleteArticle);
      article.querySelector('.archive').addEventListener('click',archiveArticle);
      document.querySelectorAll('section')[1].appendChild(article);

   }
   function deleteArticle(env){
      env.currentTarget.parentNode.parentNode.remove();
   }  
   function archiveArticle(env){
      
      let articleName =  env.currentTarget.parentNode.parentNode.querySelector('h1').innerText;
      env.currentTarget.parentNode.parentNode.remove();
      let article = document.createElement('li');
      article.innerText = articleName;
      document.querySelector('.archive-section').querySelector('ul').appendChild(article);
      
         let allTitles = [];
         for(let element of document.querySelector('.archive-section').querySelector('ul').children){
            allTitles.push(element.innerText);
         };
         document.querySelector('.archive-section').querySelector('ul').innerHTML = "";
         allTitles.sort((a,b) => a.toLocaleLowerCase() == b.toLocaleLowerCase() ? 0 : a.toLocaleLowerCase() < b.toLocaleLowerCase() ? -1 : 1);
         for(let element of allTitles){
            let toadd = document.createElement('li');
            toadd.innerText = element;
            document.querySelector('.archive-section').querySelector('ul').appendChild(toadd);
         }
   }
}