function main(steps, stepLength, speed) {

    let sec = 0;
    let distance = stepLength * steps;
    let seconds = Math.ceil((distance / 1000) / speed * 3600);
    let minutes = 0;
    let hours = 0;

    while (distance > 500) {

        distance -= 500;
        minutes ++;
    }


    for (let i = 1; i <= seconds; i++) {

        sec++;

        if (sec > 59) {

            minutes++;
            sec = 0;

            if (minutes > 59) {

                hours++;
                minutes = 0;
            }
        }
    }

    console.log(`${hours.toString().padStart(2, 0)}:${minutes.toString().padStart(2, 0)}:${sec}`)

}

main(4000, 0.60, 5);
main(2564, 0.70, 5.5);

