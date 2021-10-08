function add(num) {

    let sum = num;
    
    function calc(num) {
        
        sum += num;
        
        return calc;
    }
    
    calc.toString = () => sum;
    return calc;

}

console.log(+add(1));
console.log(+add(1)(6)(-3));