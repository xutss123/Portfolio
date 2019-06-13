/*Input Validation Subscribe*/
function validateForm() {
    var x = document.forms[".myForm"][".email"].value;
    if (x === "") {
        alert("Please enter an email.");
        return false;
    }
}

/* Normal States for forms*/
function normalState(inputID) {
    document.getElementById(inputID).className = "Textboxes";
}

function emailNormalState(inputID) {
    document.getElementById(inputID).className = "Textboxes TextboxesEmail";
}

function messageNormalState(inputID) {
    document.getElementById(inputID).className = "Textboxes TextboxesMessage";
}

/* Input Validation Form*/
function valFirst(formName, inputID, arrayIndex) {
    var last = document.forms[formName][".LastName"].value;
    var first = document.forms[formName][inputID].value;
    var normalClass = "Textboxes";
    var empText = "You cannot leave this empty.";
    var empClassName = " TextboxesEmpty";
    if (first === "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = empText;
    }
    if (first === "") {
        document.getElementById(inputID).className += empClassName;
    }
    if (first !== "") {
        document.getElementById(inputID).className = normalClass;
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = "";
    }
    if (first !== "" && last !== "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = "";
    }
    return false;
}

function valLast(formName, inputID, arrayIndex) {
    var first = document.forms[formName][".FirstName"].value;
    var last = document.forms[formName][inputID].value;
    var normalClass = "Textboxes";
    var empText = "You cannot leave this empty.";
    var empClassName = " TextboxesEmpty";
    if (last === "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = empText;
    }
    if (last === "") {
        document.getElementById(inputID).className += empClassName;
        
    }
    if (last !== "") {
        document.getElementById(inputID).className = normalClass;
    }
    if (first !== "" && last !== "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = "";
    }
    return false;
}

function valEmail(formName, inputID, arrayIndex) {
    var email = document.forms[formName][inputID].value;
    var normalClass = "Textboxes TextboxesEmail";
    var empText = "You cannot leave this empty.";
    var empClassName = " TextboxesEmpty";
    if (email === "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = empText;
    }
    if (email === "") {
        document.getElementById(inputID).className += empClassName;
        
    }
    if (email !== "") {
        document.getElementById(inputID).className = normalClass;
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = "";
    }
}

function valMessage(formName, inputID, arrayIndex) {
    var message = document.forms[formName][inputID].value;
    var normalClass = "Textboxes TextboxesMessage";
    var empText = "You cannot leave this empty.";
    var empClassName = " TextboxesEmpty";
    if (message === "") {
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = empText;
    }
    if (message === "") {
        document.getElementById(inputID).className += empClassName;
    }
    if (message !== "") {
        document.getElementById(inputID).className = normalClass;
        document.getElementsByClassName("emptyFields")[arrayIndex].innerHTML = "";
    }
}

function valAllDonation() {
    var first = document.forms[".DonForm"][".FirstName"].value;
    var last = document.forms[".DonForm"][".LastName"].value;
    var email = document.forms[".DonForm"][".Email"].value;
    var message = document.forms[".DonForm"][".Message"].value;
    var empText = "You cannot leave this empty.";
    var empClassName = " TextboxesEmpty";

    if (first === "") {
        document.getElementsByClassName("emptyFields")[0].innerHTML = empText;
    }
    if (last === "") {
        document.getElementsByClassName("emptyFields")[0].innerHTML = empText;
    }
    if (first === "") {
        document.getElementById(".FirstName").className += empClassName;
    }
    if (last === "") {
        document.getElementById(".LastName").className += empClassName;
    }
    if (email === "") {
        document.getElementsByClassName("emptyFields")[1].innerHTML = empText;
        document.getElementById(".Email").className += empClassName;
    }
    if (message === "") {
        document.getElementsByClassName("emptyFields")[2].innerHTML = empText;
        document.getElementById(".Message").className += empClassName;
    }
    return false;
}
