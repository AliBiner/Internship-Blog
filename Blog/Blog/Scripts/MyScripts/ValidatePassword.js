var password = document.getElementById("PasswordHash"),
    confirm_password = document.getElementById("passwordRepeat");

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Şifre Eşleşmiyor");
    } else {
        confirm_password.setCustomValidity("");
    }
}

password.onchange = validatePassword;
confirm_password.onkeyup = validatePassword;