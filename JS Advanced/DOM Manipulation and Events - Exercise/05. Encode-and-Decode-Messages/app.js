function encodeAndDecodeMessages() {

    let reciveText = document.getElementById(`main`).children[1].querySelector(`textarea`);

    let buttons = document.getElementsByTagName(`button`);

    buttons[0].addEventListener(`click`, shifer);
    buttons[1].addEventListener(`click`, deShifer);

    function shifer() {

        let sendText = document.getElementById(`main`)
            .children[0].querySelector(`textarea`).value;

        let codedMsg = '';

        for (let i = 0; i < sendText.length; i++) {

            codedMsg += String.fromCharCode(sendText.charCodeAt(i) + 1);
        }

        reciveText.value = codedMsg;
        document.getElementById(`main`).children[0].querySelector(`textarea`).value = ``;


    }

    function deShifer() {

        let text = reciveText.value;

        let deCodedMsg = '';

        for (let i = 0; i < text.length; i++) {

            deCodedMsg += String.fromCharCode(text.charCodeAt(i) - 1);
        }

        reciveText.value = deCodedMsg;
    }
}