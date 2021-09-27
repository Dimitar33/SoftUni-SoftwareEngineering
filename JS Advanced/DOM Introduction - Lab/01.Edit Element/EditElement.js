function editElement(ref, match, replacer) {
    
    let text = ref.textContent;
    let matcher = new RegExp(match, `g`);
    let result = text.replace(matcher, replacer);

    ref.textContent = result;
}