// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// -----------------------------------------------------------------------------------
// Displays welcome text and unveils the buttons
const textToType = "Welcome to GameSphere! Do you have amazing memories playing video games...........? Are you inspired by the adventures you have had saving a princess, or defeating your greatest foe...?";

const textElement = document.getElementById("welcome-text");

function typeText(text, index = 0) {
    if (index < text.length) {
        textElement.innerHTML += text.charAt(index);
        index++;
        setTimeout(() => typeText(text, index), 50); 
    }
    if (index >= text.length) {
        document.getElementById("q1yes").style.display = "inline";
        document.getElementById("q1no").style.display = "inline";
    }
}
// 

// waits for user to select yes and fires next message
document.getElementById("q1yes").onclick = function () { typeText2(textToType2) };

const textToType2 = "OOOhhhh goodie! I'm glad to see you have a sense of adventure!! Your first task is to find the enterance..... Well, what are you waiting for??????";

const textElement2 = document.getElementById("welcome-text2");

function typeText2(text, index = 0) {

    if (index < text.length) {
        textElement2.innerHTML += text.charAt(index);
        index++;
        setTimeout(() => typeText2(text, index), 50);
    }
}

// -----------------------------------------------------------------------

document.addEventListener("DOMContentLoaded", function () {
    // Initialize an empty string to store user input
    let userInput = "";

    // Function to check user input and navigate to page 2
    function checkUserInput() {
        if (userInput === "start") {
            // Redirect to page2.html
            window.location.href = "/Home/Privacy";
        }
    }

    // Listen for keydown events
    document.addEventListener("keydown", function (event) {
        // Check if the pressed key is alphanumeric
        if (event.key.match(/^[a-zA-Z0-9]$/)) {
            // Append the key to the userInput string
            userInput += event.key;
            // Check user input after each keypress
            checkUserInput();
        } else {
            // If a non-alphanumeric key is pressed, reset the userInput
            userInput = "";
        }
    });
});


window.onload = () => {
    typeText(textToType);
};