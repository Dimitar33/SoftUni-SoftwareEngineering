function toggle() {

    let text = document.getElementById(`extra`);
    let btn = document.getElementsByClassName(`button`);
    
    
    if (btn[0].textContent == `More`) {

        text.style.display = `block`;
        btn[0].textContent = `Less`;
    }
    
    else  {

        text.style.display = `none`;
        btn[0].textContent = `More`;
    }
    
    console.log(btn[0].textContent);
}