function scrollToBottom(element) {
    if (element) {
        element.scrollTop = element.scrollHeight;
    }
}

function shakeElement(element) {
    if (element) {
        element.classList.add('shake');
        setTimeout(() => element.classList.remove('shake'), 500); // Match the animation duration
    }
}

function addTemporaryClass(elementId, className, duration) {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.add(className);
        setTimeout(() => element.classList.remove(className), duration);
    }
}

function scrambleText(elementId, finalText) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
    const scrambleDuration = 1000; // in ms
    const interval = 50; // interval between changes
    const length = finalText.length;
    let elapsedTime = 0;

    const scramble = setInterval(() => {
        elapsedTime += interval;

        const scrambledText = Array.from({ length }, () =>
            characters.charAt(Math.floor(Math.random() * characters.length))
        ).join("");

        element.textContent = elapsedTime < scrambleDuration
            ? scrambledText
            : finalText;

        if (elapsedTime >= scrambleDuration) {
            clearInterval(scramble);
        }
    }, interval);
}

function applyDistortionWave(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.add('distortion-wave');
        setTimeout(() => element.classList.remove('distortion-wave'), 700); // Match animation duration
    }
}

function hackingSequence(elementId, finalText, duration = 2000) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:'\",.<>?/`~";
    const interval = 50; // Interval between updates
    const finalTextArray = finalText.split("");
    let elapsed = 0;

    const scramble = setInterval(() => {
        elapsed += interval;

        const scrambleText = finalTextArray.map((char, index) => {
            if (elapsed < duration) {
                return Math.random() > 0.5
                    ? characters.charAt(Math.floor(Math.random() * characters.length))
                    : char;
            }
            return char;
        }).join("");

        element.textContent = scrambleText;

        if (elapsed >= duration) {
            clearInterval(scramble);
            element.textContent = finalText; // Set final text when done
        }
    }, interval);
}
