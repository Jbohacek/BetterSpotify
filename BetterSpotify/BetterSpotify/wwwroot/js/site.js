// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openLogIn() {
    const url = 'https://localhost:7155/Login';
    window.open(url);
}


console.log(document.querySelector(".displayMusic"));

if (document.querySelector('.displayMusic') != null) {
    var player = document.querySelector('.Player');
    player.classList.remove('d-none');
}
