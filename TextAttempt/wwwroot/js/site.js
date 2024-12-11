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