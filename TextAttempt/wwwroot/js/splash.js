window.fadeOutSplash = function () {
    const splashScreen = document.getElementById("splash-screen");

    if (splashScreen) {
        splashScreen.classList.add("hidden");
        setTimeout(() => {
            splashScreen.style.display = "none";
        }, 2000);
    }
};
