function Main(x1, y1, x2, y2){

    x1 = Number(x1);
    x2 = Number(x2);
    y1 = Number(y1);
    y2 = Number(y2);

    function distance(x1, y1, x2, y2){

        let distX = x1 - x2;
        let distY = y1 - y2;

        return Math.sqrt(distX ** 2 + distY ** 2);
    }

    if (Number.isInteger(distance(x1, y1, 0, 0))) {
        
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else{

        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
    if (Number.isInteger(distance(x2, y2, 0, 0))) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }
 
    if (Number.isInteger(distance(x1, y1, x2, y2))) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

Main(2, 1, 1, 1);