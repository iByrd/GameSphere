// Input isn't checked, not safe
function setThemeAttribute(theme: string) {
  document.documentElement.setAttribute('data-bs-theme', theme)
}

function setTheme(isDark: boolean) {
  setThemeAttribute(isDark ? 'dark' : 'light')
}

const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)')

// For auto theme
mediaQuery.addEventListener('change', () => {
  if (!('theme' in localStorage)) setTheme(mediaQuery.matches)
})

// Now wait until dom is loaded since this module is placed before in the head tag and before css
document.addEventListener('DOMContentLoaded', () => {
  const themeSwitcher = document.getElementById('theme-switcher')

  if (!themeSwitcher) {
    return
  }

  // Update the dropdown
  const showActiveTheme = () => {
    const activeThemeIcon = themeSwitcher.querySelector('#theme-icon use')

    const activeBtn = themeSwitcher.querySelector(
      `[data-theme-pref="${localStorage.theme ?? 'auto'}"]`
    )

    const activeBtnIcon = activeBtn
      ?.querySelector('svg use')
      ?.getAttribute('href')

    if (!activeBtn || !activeThemeIcon || !activeBtnIcon) {
      return
    }

    for (const element of themeSwitcher.querySelectorAll('[data-theme-pref]')) {
      element.classList.remove('active')
      element.setAttribute('aria-pressed', 'false')
    }

    activeBtn.classList.add('active')
    activeBtn.setAttribute('aria-pressed', 'true')
    activeThemeIcon.setAttribute('href', activeBtnIcon)
  }

  // Set initial theme
  if ('theme' in localStorage) {
    setTheme(localStorage.theme === 'dark')
  } else {
    setTheme(mediaQuery.matches)
  }
  showActiveTheme()

  const menu = themeSwitcher.querySelector('.dropdown-menu')

  menu?.addEventListener('click', (event) => {
    const theme = (event.target as HTMLButtonElement).dataset.themePref

    if (theme === 'light' || theme === 'dark') {
      localStorage.theme = theme
      // It's safe to use this function since we already checked the input
      setThemeAttribute(theme)
    } else {
      localStorage.removeItem('theme')
      setTheme(mediaQuery.matches)
    }

    showActiveTheme()
  })
})
