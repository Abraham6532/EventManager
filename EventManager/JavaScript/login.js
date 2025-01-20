function authentication() {
    event.preventDefault();
    const email = document.getElementById("email");
    const pass = document.getElementById("password");
    console.log(email.value + "/" + pass.value)
    if (email.value == "Abraham@gmail.com" && pass.value == "qwerty123") {
        window.location.href = "./HTML/eventos.html"
    } else {
        var errorMessage = document.getElementById("errormessage");
        // Hacerlo visible quitando el atributo hidden
        errorMessage.hidden = false;
    }
}