function main(arr){

    let cpu = comp();

    for (const i of arr) {

        if (i == `print`) {

            cpu.print();
            
        }
        else{

            let [cmd, str] = i.split(` `)

            if (cmd == `add`) {
                
                cpu.add(str);
            }
            else{

                cpu.remove(str);
            }
        }
    }
    function comp(){

        result = [];
    
        return {
            add,
            remove,
            print
        }
    
        function add(str){
    
            result.push(str);
        }
    
        function remove(str){
    
           result = result.filter(x => x != str);
        }
    
        function print(){
    
            console.log(result.join(`,`));
        }
    }
}



main(['add hello', 'add again', 'remove hello', 'add again', 'print']);