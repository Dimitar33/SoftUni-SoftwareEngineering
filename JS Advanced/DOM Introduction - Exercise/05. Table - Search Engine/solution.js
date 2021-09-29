function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      
      let searchTerm = document.getElementById('searchField');
      let search = searchTerm.value.toLowerCase();

      let table = Array.from(document.querySelectorAll('tbody tr'));

      table.forEach(el => {
         let text = el.textContent.toLowerCase();

         if (text.includes(search) && search != '') {

            el.classList.add('select');
         }
         else{
            el.classList.remove('select');
         }
      });

      searchTerm.value = '';
   }
}