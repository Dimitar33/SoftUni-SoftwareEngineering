function attachEventsListeners() {

    document.querySelector(`main`).addEventListener(`click`, btn => {

        let days = Number(document.getElementById(`days`).value);
        let hours = Number(document.getElementById(`hours`).value);
        let minutes = Number(document.getElementById(`minutes`).value);
        let seconds = Number(document.getElementById(`seconds`).value);

        if (btn.target.type == `button`) {

            if (btn.target.id == `daysBtn`) {

                let hours = document.getElementById(`hours`).value = days * 24;
                let minutes = document.getElementById(`minutes`).value = hours * 60;
                let seconds = document.getElementById(`seconds`).value = minutes * 60;
            }
            else if (btn.target.id == `hoursBtn`) {

                let days = document.getElementById(`days`).value = hours / 24;
                let minutes = document.getElementById(`minutes`).value = hours * 60;
                let seconds = document.getElementById(`seconds`).value = minutes * 60;
            }
            else if (btn.target.id == `minutesBtn`) {

                let hours = document.getElementById(`hours`).value = minutes / 60;
                let days = document.getElementById(`days`).value = hours / 24;
                let seconds = document.getElementById(`seconds`).value = minutes * 60;
            }
            else if (btn.target.id == `secondsBtn`) {

                let minutes = document.getElementById(`minutes`).value = seconds / 60;
                let hours = document.getElementById(`hours`).value = minutes / 60;
                let days = document.getElementById(`days`).value = hours / 24;
            }
            console.log(btn.target);
        }

    });

    
    console.log('TODO:...');
}