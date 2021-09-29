function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
     
      let input = JSON.parse(document.querySelector(`textarea`).value);
      let restourants = {};

      input.forEach(el => {
         
         const [restourantName, restourantWorkers] = el.split(` - `);
         const workersData = restourantWorkers.split(`, `);

         let workers = [];

         workersData.forEach(el => {

            const [name, salary] = el.split(` `);
            
            worker = {

               name,
               salary
            }

            workers.push(worker);
         });
         
         if (restourants[restourantName]) {
            
            workers = workers.concat(restourants[restourantName].workers)
         }

         workers.sort((a, b) => b.salary - a.salary)

         const avgSalary = workers.reduce((sum, worker) => sum + Number(worker.salary) / workers.length);
         const bestSalary = Number(workers[0].salary);

         restourants[restourantName] = {

            workers,
            avgSalary,
            bestSalary
         }


      });

      let bestName = ``;
      let bestSalary = 0;

      for (const i in restourants) {

         if (restourants[i].avgSalary > bestSalary) {

            bestSalary = restourants[i].avgSalary;
            bestName = i;
         }
      }

      const bestRestourant = restourants[bestName];
      
      document.querySelector(`#bestRestaurant p`).textContent = 
      `Name: ${bestName} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      

      let workersResult = [];

      bestRestorant.workers.forEach(el => {
         
         workersResult.push(`Name: ${w.name} With Salary: ${w.salary}`)
      });

      document.querySelector(`#workers p`).textContent = workersResult.join(` `);
   }
}