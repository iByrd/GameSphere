"use strict";
async function type(sentences, image) {
    const textBox = document.getElementById('welcome-text');
    if (!textBox)
        return;
    textBox.innerHTML = '';
    let fastForwardText = false;
    const onKeyDown = (e) => {
        if (e.code === 'Space' || e.code === 'Enter') {
            fastForwardText = true;
        }
    };
    const onKeyUp = (e) => {
        if (e.code === 'Space') {
            fastForwardText = false;
        }
    };
    window.addEventListener('keydown', onKeyDown);
    window.addEventListener('keyup', onKeyUp);
    let imgY = 0;
    const typeChar = (char, ms) => {
        return new Promise((resolve) => setTimeout(() => {
            textBox.innerHTML += char;
            if (image) {
                imgY += 4;
                image.style.transform = `translateX(${imgY}px)`;
            }
            resolve();
        }, ms));
    };
    for (const sentence of sentences) {
        fastForwardText = false;
        for (const char of sentence) {
            await typeChar(char, fastForwardText ? 8 : 60);
        }
        await typeChar(' ', fastForwardText ? 100 : 500);
    }
    window.removeEventListener('keydown', onKeyDown);
    window.removeEventListener('keyup', onKeyUp);
}
async function onYesClicked() {
    const walkingExplorer = document.getElementById('walkingCaveExplorer');
    document.getElementById('idleCaveExplorer')?.classList.add('d-none');
    document.getElementById('gandalf')?.classList.add('d-none');
    if (!walkingExplorer)
        return;
    walkingExplorer.classList.remove('d-none');
    await type([
        'OOOhhhh goodie!',
        "I'm glad to see you have a sense of adventure!!",
        'Your first task is to find the enterance.....',
        'Well, what are you waiting for??????'
    ], walkingExplorer);
    const enterBtn = document.getElementById('enter-btn');
    enterBtn?.classList.remove('d-none');
}
async function main() {
    await type([
        'Welcome to GameSphere!',
        'Do you have amazing memories playing video games...........?',
        'Are you inspired by the adventures you have had saving a princess,',
        'or defeating your greatest foe...?'
    ]);
    const yesOrNo = document.getElementById('yes-or-no');
    if (!yesOrNo)
        return;
    yesOrNo.classList.remove('d-none');
    yesOrNo.classList.add('d-grid');
    yesOrNo.addEventListener('click', (e) => {
        const btn = e.target;
        if (btn?.dataset.value === 'n') {
            document.getElementById('gandalf')?.classList.remove('d-none');
            btn.disabled = true;
        }
        else {
            yesOrNo.classList.add('d-none');
            yesOrNo.classList.remove('d-grid');
            onYesClicked();
        }
    });
}
setTimeout(main, 100);
