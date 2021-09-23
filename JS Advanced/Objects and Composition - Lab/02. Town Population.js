function main(arr) {

    let towns = {};

    for (let key of arr) {

        let [name, population] = key.split(' <-> ');

        let pop = Number(population);

        if (towns[name]) {

            pop += towns[name];

        }

        towns[name] = pop;

    }

    for (const key in towns) {

        console.log(`${key} : ${towns[key]}`);

    }
}

main(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

)