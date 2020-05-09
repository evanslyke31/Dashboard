function showLogin() {
    var create = document.getElementById("create");
    var login = document.getElementById("login");
    create.style.display = "none";
    login.style.display = "block";
    var createbtn = document.getElementById("createbtn");
    var loginbtn = document.getElementById("loginbtn");
    createbtn.classList.remove('active');
    loginbtn.classList.add('active');
}

function showCreate() {
    var create = document.getElementById("create");
    var login = document.getElementById("login");
    create.style.display = "block";
    login.style.display = "none";
    var createbtn = document.getElementById("createbtn");
    var loginbtn = document.getElementById("loginbtn");
    createbtn.classList.add('active');
    loginbtn.classList.remove('active');
}