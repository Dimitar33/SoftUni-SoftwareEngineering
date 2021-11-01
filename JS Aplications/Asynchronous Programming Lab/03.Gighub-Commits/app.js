function loadCommits() {

    let username = document.getElementById(`username`).value;
    let repo = document.getElementById(`repo`).value;
    let commits = document.getElementById(`commits`);

    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(url)
        .then(x => {

            if (!x.ok) {

                throw new Error(`Error: ${x.status} (Not Found)`)
            }
            return x.json();
        })
        .then(x => {

            commits.innerHTML = ``;

            for (const el of x) {

                let li = document.createElement(`li`);
                li.textContent = `${el.commit.author.name}: ${el.commit.message}`;

                commits.appendChild(li);
            }

        })
        .catch(er => {

            commits.innerHTML = ``;
            let li = document.createElement(`li`);
            li.textContent = er.message;

            commits.appendChild(li);
        })
}