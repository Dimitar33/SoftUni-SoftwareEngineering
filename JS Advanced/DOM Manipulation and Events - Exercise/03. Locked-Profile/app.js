function lockedProfile() {

  Array.from(document.querySelectorAll(`button`)).forEach(el => {

        el.addEventListener(`click`, toggle);
    });

    function toggle(el) {

        let content = el.target.parentNode.querySelector(`div`);
        let btn = el.target;
        let isLocked = el.target.parentNode.querySelector(`input[value="lock"]`).checked;

        if (isLocked == false) {

            if (btn.textContent == `Show more`) {

                content.style.display = `block`;
                btn.textContent = `Hide it`;

                console.log(isLocked)
            }
            else {

                btn.textContent = `Show more`;
                content.style.display = `none`;
            }
        }
    }

}