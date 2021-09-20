function main(speed, area) {

    let status = "";
    let speedLimit = 0;

    switch (area) {

        case 'motorway':

            speedLimit = 130;

            if (speed > 130 && speed < 151) {

                status = 'speeding'
            }

            else if (speed > 150 && speed < 171) {

                status = 'excessive speeding';
            }

            else if (speed > 170) {

                status = 'reckless driving';
            }

            break;

        case 'interstate':

            speedLimit = 90;

            if (speed > 90 && speed < 111) {

                status = 'speeding'
            }

            else if (speed > 110 && speed < 131) {

                status = 'excessive speeding';
            }

            else if (speed > 130) {

                status = 'reckless driving';
            }

            break;

        case 'city':

            speedLimit = 50;

            if (speed > 50 && speed < 71) {

                status = 'speeding'
            }

            else if (speed > 70 && speed < 91) {

                status = 'excessive speeding';
            }

            else if (speed > 90) {

                status = 'reckless driving';
            }

            break;

        case 'residential':

            speedLimit = 20;

            if (speed > 20 && speed < 41) {

                status = 'speeding'
            }

            else if (speed > 40 && speed < 61) {

                status = 'excessive speeding';
            }

            else if (speed > 60) {

                status = 'reckless driving';
            }

            break;

        default:
            break;
    }

    if (status == '') {

        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
    else {

        console.log(`The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }

}

main(40, 'city');
main(200, 'motorway');