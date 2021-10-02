function validate() {
   document.getElementById(`email`).addEventListener(`change`, check);
  

   function check(ev){

        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (!regex.test(ev.target.value)) {
            
            ev.target.classList.add(`error`);
        }
        else{
            ev.target.classList.remove(`error`);
        }
   }
}