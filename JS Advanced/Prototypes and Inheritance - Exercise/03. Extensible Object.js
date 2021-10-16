function extensibleObject(){

    let obj = {};

    obj.extend = (model) =>{

        Object.entries(model).forEach(([k, v]) => {
            
            if (typeof v == `function`) {
                
                Object.getPrototypeOf(obj)[k] = v;
            }
            else{
                obj[k] = v;
            }
        });
    }

    return obj;
}