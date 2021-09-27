function extractText() {
    
    const text = document.getElementById('items').children;

    const result = [];

    for (const el of Array.from(text)) {
        
        result.push(el.textContent);
    }
  
    document.getElementById('result').textContent = result.join('\n');
}