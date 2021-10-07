function main(inputJson, criteria){

    let objects = JSON.parse(inputJson);

    if (criteria != `all`) {
        
        let [property, criteriaValue] = criteria.split(`-`);

         objects = objects.filter(x => x[property] == criteriaValue);
    }

    let result = [];
    let count = 0;

    objects.map(e => {

        result.push(`${count++}. ${e.first_name} ${e.last_name} - ${e.email}`);
    })

    console.log(result.join(`\n`));

}

main(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female');