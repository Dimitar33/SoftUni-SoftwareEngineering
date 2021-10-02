function focused() {

   let section = Array.from(document.getElementsByTagName(`input`));

    section.forEach(el => {

        el.addEventListener(`focus`, onFocus);
        el.addEventListener(`blur`, blurred);
    });

    function onFocus(el){

        el.target.parentNode.className = `focused`;
    }

    function blurred(el){

        el.target.parentNode.className = ``;
    }
}