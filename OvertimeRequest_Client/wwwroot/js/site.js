// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var span = document.getElementById('nameLogin');
var name = $("#nickName").val();

while (span.firstChild) {
    span.removeChild(span.firstChild);
}
span.appendChild(document.createTextNode(name));