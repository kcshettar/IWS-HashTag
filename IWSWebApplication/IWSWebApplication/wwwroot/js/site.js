// Write your JavaScript code.

    function checkPass() {
            //Store the password field objects into variables ...
            var pass1 = document.getElementById('pass1');
            var pass2 = document.getElementById('pass2');
            var buttonregister = document.getElementById('submitformregister');
            //Store the Confimation Message Object ...
            var message = document.getElementById('confirmMessage');
            //Set the colors we will be using ...
            var goodColor = "#66cc66";
            var badColor = "#ff6666";
            //Compare the values in the password field
            //and the confirmation field
            if (pass1.value == pass2.value) {
        //The passwords match. 
        //Set the color to the good color and inform
        //the user that they have entered the correct password 
        pass2.style.backgroundColor = goodColor;
    message.style.color = goodColor;
                buttonregister.disabled = false;
                message.innerHTML = "Passwords Match!";
            } else {
        //The passwords do not match.
        //Set the color to the bad color and
        //notify the user.
        //document.getElementById("submitform").disabled = true;
        pass2.style.backgroundColor = badColor;
    message.style.color = badColor;
                buttonregister.disabled = true;
                message.innerHTML = "Passwords Do Not Match!";

            }
        }

        function checkLogin() {
            var unamelogin = document.getElementById('usernamelogin');
            var passlogin = document.getElementById('passwordlogin');
            var buttonlogin = document.getElementById('submitformlogin');
            var invalidmessage = document.getElementById('invalidMessage');

            if (unamelogin.value == "admin" && passlogin.value == "admin")
            {
        //buttonlogin.disabled = false;
        location.href.value = "/Home/Mainpage";
    }
            else
            {
        buttonlogin.disabled = true;
    invalidmessage.innerHTML = "Check UserName & Password";
            }

}

//CONTACT PAGE
        var maxchar = 160;
        var i = document.getElementById("textinput");
        var c = document.getElementById("count");
        c.innerHTML = maxchar;

        i.addEventListener("keydown", count);

        function count(e) {
            var len = i.value.length;
            if (len >= maxchar) {
                e.preventDefault();
            } else {
                c.innerHTML = maxchar - len - 1;
            }
        }


//END

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