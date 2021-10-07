function main(arr) {

    let cpu = command();
    
    for (const i of arr) {
        
        let cmd = i.split(` `);
        let name = cmd[1];

        if (cmd[0] === `create`) {
            
            cpu.create(name);

            if (cmd[2] === `inherit`) {
                
                cpu.inherit(cmd[1], cmd[3]);
            }
        }

        else if (cmd[0] == `set`) {
            
            cpu.set(cmd[1],cmd[2],cmd[3])
        }

        else{

            cpu.print(cmd[1]);
        }
    }

    function command() {

        let objects = {};

        return {

            create,
            inherit,
            set,
            print
        }

        function create(name) {
            objects[name] = {};
        }

        function inherit(name, parentName) {

            objects[name] = Object.create(objects[parentName]);
        }

        function set(name, key, value) {

            objects[name][key] = value;
        }

        function print(name) {

            let result = [];

            for (const key in objects[name]) {

                result.push(`${key}:${objects[name][key]}`);
            }

            console.log(result.join(`,`))
        }
    }
}

main(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'])