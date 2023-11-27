window.addEventListener('keydown', (e: KeyboardEvent) => {
  // If Enter + shift is pressed go to camp
  if (e.code === 'Enter' && e.shiftKey) {
    window.location.replace('/Home/Camp')
  }
})

async function type(sentences: string[], image?: HTMLElement) {
  const textBox = document.getElementById('welcome-text') as HTMLElement | null
  if (!textBox) return

  textBox.innerHTML = ''
  let fastForwardText = false

  /* While space is held, fast forward text.
   * If enter is pressed, fast forward sententence. */
  const onKeyDown = (e: KeyboardEvent) => {
    if (e.code === 'Space' || e.code === 'Enter') {
      fastForwardText = true
    }
  }

  const onKeyUp = (e: KeyboardEvent) => {
    if (e.code === 'Space') {
      fastForwardText = false
    }
  }

  window.addEventListener('keydown', onKeyDown)
  window.addEventListener('keyup', onKeyUp)

  let imgY = 0

  // Really stupid way of making setTimout asynchronous
  const typeChar = (char: string, ms: number): Promise<void> => {
    return new Promise((resolve) =>
      setTimeout(() => {
        textBox.innerHTML += char
        if (image) {
          imgY += 4
          image.style.transform = `translateX(${imgY}px)`
        }
        resolve()
      }, ms)
    )
  }

  /* Could be done functionally without loops like setTimeout is usually used,
   * but I don't really think there would be a huge performance boost and
   * the code would be really confusing. This is how I would do it with ncurses at least */
  for (const sentence of sentences) {
    fastForwardText = false // reset if enter was pressed
    for (const char of sentence) {
      await typeChar(char, fastForwardText ? 8 : 60)
    }
    await typeChar(' ', fastForwardText ? 100 : 500)
  }

  window.removeEventListener('keydown', onKeyDown)
  window.removeEventListener('keyup', onKeyUp)
}

async function onYesClicked() {
  const walkingExplorer = document.getElementById('walkingCaveExplorer')
  document.getElementById('idleCaveExplorer')?.classList.add('d-none')
  document.getElementById('gandalf')?.classList.add('d-none')

  if (!walkingExplorer) return

  walkingExplorer.classList.remove('d-none')

  await type(
    [
      'OOOhhhh goodie!',
      "I'm glad to see you have a sense of adventure!!",
      'Your first task is to find the enterance.....',
      'Well, what are you waiting for??????'
    ],
    walkingExplorer
  )

  const enterBtn = document.getElementById('enter-btn')

  enterBtn?.classList.remove('d-none')
}

async function main() {
  await type([
    'Welcome to GameSphere!',
    'Do you have amazing memories playing video games...........?',
    'Are you inspired by the adventures you have had saving a princess,',
    'or defeating your greatest foe...?'
  ])

  const yesOrNo = document.getElementById('yes-or-no')

  if (!yesOrNo) return

  yesOrNo.classList.remove('d-none')

  yesOrNo.addEventListener('click', (e: MouseEvent) => {
    const btn = e.target as HTMLButtonElement | null
    if (btn?.dataset.value === 'n') {
      // No clicked
      document.getElementById('gandalf')?.classList.remove('d-none')
      btn.disabled = true
    } else {
      yesOrNo.classList.add('d-none')
      onYesClicked()
    }
  })
}

// Shouldn't be necessary to wait for any window messages, this is better IMO
setTimeout(main, 100)
