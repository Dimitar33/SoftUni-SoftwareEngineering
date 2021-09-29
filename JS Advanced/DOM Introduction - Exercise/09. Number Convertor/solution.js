function solve() {


    let num = Number(document.getElementById(`input`).value);
    let selectOptions =  document.getElementById(`selectMenuTo`);
    let selected = selectOptions.options[selectOptions.selectedIndex].value;
    let result = [];

    if (selected == `binary`) {

        while (num > 0) {

            if (num % 2 != 0) {

                result.unshift(1);
            }
            else {

                result.unshift(0);
            }

            num = Math.floor(num / 2);
        }

    }
    else {

        while (num > 0) {

            let devizor = Math.floor(num / 16);
            let leftOver = (num / 16) - devizor;
            let endNumber = leftOver * 16;

            switch (endNumber) {
                case 10:
                    endNumber = `A`
                    break;
                case 11:
                    endNumber = `B`
                    break;
                case 12:
                    endNumber = `C`
                    break;
                case 13:
                    endNumber = `D`
                    break;
                case 14:
                    endNumber = `E`
                    break;
                case 15:
                    endNumber = `F`
                    break;

                default:
                    break;
            }
            result.unshift(endNumber);
            num = Math.floor(num / 16);
        }

    }
    document.getElementById(`result`).value = result.join(``);
}