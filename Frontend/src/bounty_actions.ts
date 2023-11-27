import 'vite/modulepreload-polyfill'

import 'bootstrap/js/dist/modal'

import Modal from 'bootstrap/js/dist/modal'

const abort = new AbortController()

async function httpMethodCall(url: string, httpMethod: string) {
  await fetch(url, { method: httpMethod }).finally(() =>
    location.replace(location.href)
  )
}

const modal = document.getElementById('confirm-delete-modal') as Element

modal?.addEventListener('show.bs.modal', (event: Modal.Event) => {
  const caller = event.relatedTarget

  const label = modal.querySelector('.label')
  const url = caller?.dataset.url

  if (!url || !label) return

  label.textContent = caller.getAttribute('data-label')

  document
    .getElementById('confirm-delete-btn')
    ?.addEventListener('click', () => httpMethodCall(url, 'DELETE'), {
      signal: abort.signal
    })
})

modal?.addEventListener('hide.bs.modal', () => abort.abort())

document
  .querySelectorAll<HTMLButtonElement>('.change-status')
  .forEach((button) => {
    const url = button.dataset.url

    if (!url) return

    button.addEventListener('click', () => httpMethodCall(url, 'PUT'))
  })
