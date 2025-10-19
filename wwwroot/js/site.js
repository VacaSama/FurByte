// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    // retrieves the canvas element from the HTML document (Dashboard/Index)
    const canvas = document.getElementById("furbyteCanvas");
    // retrieves the 2d rendering needed for the canvas 
    const context = canvas.getContext("2d");
    // declares and retrieves the modular sprite sheet 
    const sprite = new Image();
    // dimensions of each sprite frame (should be..32x32 pixels)
    const spriteWidth = 250; // some resizing needs to be done.. 
    const spriteHeight = 250; // sprite sheet is 1024x1536
    // column index 
    const spriteX = 0;
    // row index 
    const spriteY = 0;
    // sprite source path 
    sprite.src = "/images/sprites/modular-cat.png";

    // draw aspecified portion of the sprite sheet onto the canvas
    sprite.onload = function () {

        context.drawImage(
            sprite, // what we're drawing
            spriteX * spriteWidth, spriteY * spriteHeight, // how big and where it is
            spriteWidth, spriteHeight, 
            5, 5,
            spriteWidth, spriteHeight
        );
        function drawSprite(spriteX, spriteY) {
            context.clearRect(0, 0, canvas.width, canvas.height);
            context.drawImage(
                sprite,
                spriteX * spriteWidth, spriteY * spriteHeight,
                spriteWidth, spriteHeight,
                0, 0,
                spriteWidth, spriteHeight
            );
        };
    };

    var gameArea = {
        canvas: canvas,
        start: function () {
            this.canvas.width = 260;
            this.canvas.height = 260; // may increase to 300
            this.context = this.canvas.getContext("2d");
        }
    };

    function startGame() {
        gameArea.start();
        drawSprite(0, 0); // draw first frame
        drawSprite(0, 3); // draw first frame
    }
    startGame();
};
