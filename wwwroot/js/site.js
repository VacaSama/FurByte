// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    const canvas = document.getElementById("furbyteCanvas");
    const context = canvas.getContext("2d");

    var gameArea = {
        canvas: canvas,
        start: function () {
            this.canvas.width = 480;
            this.canvas.height = 270; // may increase to 300
            this.context = this.canvas.getContext("2d");
        }
    };
 
    function startGame() {
        gameArea.start();
    }

    startGame();
};