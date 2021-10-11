function notify(message) {

  let notification = document.getElementById(`notification`);

  notification.addEventListener(`click`, () => {
    
    notification.style.display = `none`;
  });


  notification.style.display = `block`;
  notification.textContent = message;

  console.log(notification)
}