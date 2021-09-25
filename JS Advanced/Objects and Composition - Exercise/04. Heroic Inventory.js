function main(arr){

    let heroes = [];

    for (const item of arr) {
        
        let [name, level, items] = item.split(' / ');
        level = Number(level);

        items = items ? items.split(', ') : [];

        heroes.push({name, level, items});
    }

    console.log(JSON.stringify(heroes));
}

main(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)