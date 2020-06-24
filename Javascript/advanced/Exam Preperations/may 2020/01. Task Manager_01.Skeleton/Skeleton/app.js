function solve() {
    document.getElementById('add').addEventListener('click', add);
    function add(env){
        const form = env.currentTarget.parentNode;
        let task = form.querySelector('#task').value;
        let description = form.querySelector('#description').value;
        let duedate = form.querySelector('#date').value;
        let article = document.createElement('article');
        let articleHtml = 
        `<h3>${task}</h3>
        <p>Description: ${description}</p>
        <p>Due Date: ${duedate}</p>
        <div class="flex">
            <button class="red">Delete</button>
            <button class="orange">Finish</button>
        </div>`;
        article.innerHTML = articleHtml;
        alert(article.innerHTML);
        document.querySelectorAll('section')[1].children[1].appendChild(article);
        
    }
}