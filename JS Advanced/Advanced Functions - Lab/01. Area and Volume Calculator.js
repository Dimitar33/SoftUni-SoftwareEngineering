function solve(area, vol, input){

    let objects = JSON.parse(input);

    function calc(obj){

        let resArea = area.call(obj);
        let resVol = vol.call(obj);

        return {area: resArea, volume: resVol};
    }

    return objects.map(calc);
}

function area(){

    return Math.abs(this.x * this.y);
}

function vol(){

    return Math.abs(this.x * this.y * this.z);
}

console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
    ))