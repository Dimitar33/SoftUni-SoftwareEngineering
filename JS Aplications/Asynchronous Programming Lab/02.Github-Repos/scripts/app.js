function loadRepos() {

	let user = document.getElementById(`username`).value;
	let repos = document.getElementById(`repos`);
	let url = `https://api.github.com/users/${user}/repos`;

	fetch(url)
		.then(res => {

			if (res.ok == false) {

				throw new Error(`Error ${res.status}`);
			}
			return res.json();
		})
		.then(data => {

			repos.innerHTML = ``;

			for (const el of data) {
				
				const li = document.createElement(`li`);
				li.innerHTML = `<a href="${el.html_url}">${el.full_name}</a>`; 
				repos.appendChild(li);
			}
		})
		.catch(error => {
			
			repos.innerHTML = ``;
			repos.textContent = `${error.message}`;
		});
}