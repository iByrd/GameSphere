const modal = document.getElementById('confirm-delete')

if (modal) {
    const abort = new AbortController()

    modal.addEventListener('hide.bs.modal', () => abort.abort())

    modal.addEventListener('show.bs.modal', (event) => {
        const button = event.relatedTarget

        if (!button) {
            return
        }

        const movieSpan = modal.querySelector<HTMLSpanElement>('.bounty')
        const deleteURL = button.dataset.url

        if (!deleteURL || !movieSpan) {
            return
        }

        movieSpan.textContent = button.getAttribute('data-bounty')

        modal.querySelector('#confirm-button')?.addEventListener(
            'click',
            async () => {
                await fetch(deleteURL, {
                    method: 'DELETE'
                }).finally(() => location.replace(location.href))
            },
            { signal: abort.signal }
        )
    })
}
