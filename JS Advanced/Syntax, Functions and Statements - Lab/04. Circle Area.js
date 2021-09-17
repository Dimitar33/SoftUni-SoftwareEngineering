function main(num){
   
    if (typeof(num) === 'number') {
        
        let area = Math.PI * Math.pow(num, 2);
        console.log(area.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(num)}.`);
    }

}

main(5);
main('name');