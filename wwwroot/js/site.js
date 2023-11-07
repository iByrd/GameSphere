// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const textToType = "Welcome to GameSphere! Do you have amazing memories playing video games...........? Are you inspired by the adventures you have had saving a princess, or defeating your greatest foe...?";

const textElement = document.getElementById("welcome-text");

function typeText(text, index = 0) {
    if (index < text.length) {
        textElement.innerHTML += text.charAt(index);
        index++;
        setTimeout(() => typeText(text, index), 50); 
    }
}

window.onload = () => {
    typeText(textToType);
};