function solve() {
  
  const text = document.getElementById(`text`).value;
  const convention = document.getElementById(`naming-convention`).value;

  let result = '';

  let arr = text.toLowerCase().split(` `);

  if (convention == `Camel Case`) {
    
    result += arr[0];
    
    for (let i = 1; i < arr.length; i++) {

      result += arr[i].charAt(0).toUpperCase() + arr[i].slice(1);
  }
  }
  else if (convention == `Pascal Case`) {
    
    for (let i = 0; i < arr.length; i++) {

      result = arr[i].charAt(0).toUpperCase() + arr[i].slice(1);
  }
  }
  else{

      result = `error`;
  }

  document.getElementById(`result`).textContent = result; 
  
}