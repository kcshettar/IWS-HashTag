// Write your JavaScript code.

// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

/*function to check userid & password*/

// Below function Executes on click of login button.
function checkForm(form) {
    if (form.uname.value == "admin" && form.passwd.value == "admin") {
        window.open('index.html', "_self");
        
    }
    else {
        alert("Invalid Username/Password");
        break;
    }
    return true;
}

function pageReload() {
    location.reload();
    document.getElementById('username').value = '';
    document.getElementById('password').value = '';
}