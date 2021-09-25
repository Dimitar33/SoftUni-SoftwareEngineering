function main(arr) {

    let result = [];

    for (let i = 1; i < arr.length; i++) {

       let [_, Town, Latitude, Longitude] = arr[i].split(/\s*\|\s*/);
       
       let newTown = {
           Town,
           Latitude: Number(Number(Latitude).toFixed(2)),
           Longitude: Number(Number(Longitude).toFixed(2))
       }

       result.push(newTown);

    }
    console.log(JSON.stringify(result));
}
    



main(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);