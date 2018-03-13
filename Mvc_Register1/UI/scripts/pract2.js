// Check the corresponding value of the two arrays for the combination of the ball animation and the rectangle/square animation.

var animationRect = [
  "rotationClockwise ease-in-out",
  "rotation360 ease-in-out",
  "rotation90 ease-in-out",
  "rectStill ease-in-out"
];
var animationBall = [
  "halfJump ease-in-out",
  "completeJump ease-in-out",
  "halfJump ease-in-out",
  "completeJumpTransformation ease-in-out"
];
var loop = document.querySelector(".loop");
var num = 1;

function changeAnimation(n) {
    document.documentElement.style.setProperty(
      "--rect-animation",
      animationRect[n]
    );
    document.documentElement.style.setProperty(
      "--ball-animation",
      animationBall[n]
    );
}

loop.addEventListener("click", function () {
    changeAnimation(num);
    num++;
    if (num == 4) {
        num = 0;
    }
});
