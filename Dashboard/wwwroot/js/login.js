function showLogin() {
    create = document.getElementById("create");
    login = document.getElementById("login");
    create.style.display = "none";
    login.style.display = "block";
    console.log("test2");
}

function showCreate() {
    create = document.getElementById("create");
    login = document.getElementById("login");
    create.style.display = "block";
    login.style.display = "none";
    console.log("test1");
}