function main(number, cmd1, cmd2, cmd3, cmd4, cmd5) {

    let num = parseInt(number);

    let result = Cmd(num, cmd1);
    console.log(result);

    result = Cmd(result, cmd2);
    console.log(result);

    result = Cmd(result, cmd3);
    console.log(result);

    result = Cmd(result, cmd4);
    console.log(result);

    result = Cmd(result, cmd5);
    console.log(result.toFixed(1));
    function Cmd(num, cmd) {

        switch (cmd) {
    
            case `chop`:
    
                num /= 2;
                break;
            case `dice`:
    
                num = Math.sqrt(num);
                break;
            case `spice`:
    
                num += 1;
                break;
            case `bake`:
    
                num *= 3;
                break;
    
            case `fillet`:
    
                num *=  0.8;
                break;
            default:
                break;
        }
    
        return num;
    }
}



main('9', 'dice', 'spice', 'chop', 'bake', 'fillet');