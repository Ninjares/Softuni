function loadRepos() {
	let user = document.querySelector('#username').value;
	let html =  `https://api.github.com/users/${user}/repos`;

	fetch(html).then(x => {
	     document.getElementById('repos').innerHTML = '';
		 if(x.status == 404){
			 console.log('crap');
			const li = document.createElement('li');
			const a = document.createElement('a');
			a.innerText = 'Error 404: no such user';
			li.appendChild(a);
			document.getElementById('repos').appendChild(li);
		 }
		 else return x.json();
		})
		.then(data => {
			if(!data) return;
			console.log(data);
			data.forEach(element => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.href = element.html_url;
				a.innerText = element.full_name;
				li.appendChild(a);
				document.getElementById('repos').appendChild(li);
			});
		});
}