function solve() {
    document.getElementById('add').addEventListener('click', add);
    function add(env){
        env.preventDefault(); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        const form = env.currentTarget.parentNode;
        let task = form.querySelector('#task').value;
        let description = form.querySelector('#description').value;
        let duedate = form.querySelector('#date').value;
        if(task!=''&&description!=''&&duedate!=''){
            let article = document.createElement('article');
            let articleHtml = 
            `<h3>${task}</h3>
            <p>Description: ${description}</p>
            <p>Due Date: ${duedate}</p>
            <div class="flex">
                <button class="green">Start</button>
                <button class="red">Delete</button>
            </div>`;
            article.innerHTML = articleHtml;
            article.querySelector('.red').addEventListener('click', deleteTask);
            article.querySelector('.green').addEventListener('click', movetask);
            document.querySelectorAll('section')[1].children[1].appendChild(article);
        }
    }
    function movetask(env){
        let move = document.createElement('article');
        move.innerHTML = env.currentTarget.parentNode.parentNode.innerHTML;
        move.querySelector('.flex').innerHTML = 
        `<button class="red">Delete</button>
         <button class="orange">Finish</button>`;
        move.querySelector('.red').addEventListener('click', deleteTask);
        move.querySelector('.orange').addEventListener('click', movetoFinish);
        document.querySelector('#in-progress').appendChild(move);
        env.currentTarget.parentNode.parentNode.remove();
    }
    function deleteTask(env){
        env.currentTarget.parentNode.parentNode.remove();
    }
    function movetoFinish(env){
        let finish = document.createElement('article');
        finish.innerHTML = env.currentTarget.parentNode.parentNode.innerHTML;
        finish.querySelector('.flex').remove();
        document.querySelectorAll('section')[3].children[1].appendChild(finish);
        env.currentTarget.parentNode.parentNode.remove();
    }
}