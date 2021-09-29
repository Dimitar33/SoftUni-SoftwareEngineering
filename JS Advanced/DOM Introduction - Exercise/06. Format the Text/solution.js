function solve() {

  let text = document.getElementById(`input`).value;

  let sentences = text.split(`.`).filter(x => x != ``);
  let result = ``;
  let count = 0;
  
  for (let i = 0; i < sentences.length; i +=3) {

    let para = ``;
    
    for (let j = 0; j < 3; j++) {
      
      if (sentences[i + j]) {

        para += sentences[i + j] + `. `;
        
      }
    }
    result += `<p> ${para} </p>`;
  }

  document.getElementById(`output`).innerHTML = result;

}