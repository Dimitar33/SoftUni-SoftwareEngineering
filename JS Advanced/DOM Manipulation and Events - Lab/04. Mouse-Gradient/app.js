function attachGradientEvents() {
   
    let gradient = document.getElementById(`gradient`);

    gradient.addEventListener(`mousemove`, gradientIn);
    gradient.addEventListener(`mouseout`, gradientOut);

    function gradientIn(event){

        let power = event.offsetX / (event.target.clientWidth -1);
        power = Math.trunc(power * 100);
        document.getElementById(`result`).textContent = `${power}%`;
    }

    function gradientOut(event){

        document.getElementById(`result`).textContent = ``;
    }
}