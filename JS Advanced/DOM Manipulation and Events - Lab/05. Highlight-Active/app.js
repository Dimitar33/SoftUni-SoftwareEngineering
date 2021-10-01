function focused() {

   // let section = Array.from(document.getElementsByTagName(`input`));

    let section = document.getElementsByTagName(`div`)[0];
    // section.forEach(el => {

    //     el.addEventListener(`focus`, onFocus);
    //     el.addEventListener(`blur`, blurred);
    // });

    // function onFocus(el){

    //     el.target.parentNode.className = `focused`;
    // }

    // function blurred(el){

    //     el.target.parentNode.className = ``;
    // }

    section.childNodes.addEventListener(`mouseover`, function(e) {

        if (e.target.className == `focused`) {
            
            e.target.className = ``;
        }
        else{
            e.target.className = `focused`
        }
    })
}