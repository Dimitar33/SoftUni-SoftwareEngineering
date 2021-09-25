function main(car){

    function getEngine(power) {

        if (power < 91) {
           
            return {power: 90, volume: 1800};
        }
        else if (power > 90 && power < 121) {
            
            return { power: 120, volume: 2400 };
        }
        else{
            return { power: 200, volume: 3500 };
        }
    };
    
    let carriage ={

        type: car.carriage,
        color: car.color
    }

    let wheelsize = car.wheelsize;

    if (car.wheelsize % 2 == 0) {

        wheelsize -= 1;
    }

    let wheels = Array(4).fill(wheelsize);

    let newCar = {
        model: car.model,
        engine: getEngine(car.power),
        carriage: carriage,
        wheels: wheels
    }

    return newCar;
}

main({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);