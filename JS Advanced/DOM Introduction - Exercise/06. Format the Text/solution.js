function solve() {

  let text = document.getElementById(`input`).value;

  let sentences = text.split(`.`).filter(x => x != ``);

  for (let i = 0; i < sentences.length; i +=3) {

    let para = [];
    
    for (let j = 0; j < 3; j++) {
      
      if (sentences[i + j]) {

        para.push(sentences[i + j]);
        
      }
    }
    let result = para.join(`. `) + `.`;
    document.getElementById(`output`).innerHTML += `<p>${result}</p>`;
  }


}