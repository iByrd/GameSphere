"use strict";
const abort = new AbortController();
async function httpMethodCall(url, httpMethod) {
    await fetch(url, { method: httpMethod }).finally(() => location.replace(location.href));
}
const modal = document.getElementById('confirm-delete-modal');
modal?.addEventListener('show.bs.modal', (event) => {
    const caller = event.relatedTarget;
    const label = document.getElementById('confirm-delete-label');
    const url = caller?.dataset.url;
    if (!url || !label)
        return;
    label.textContent = caller.getAttribute('data-label');
    document
        .getElementById('confirm-delete-btn')
        ?.addEventListener('click', () => httpMethodCall(url, 'DELETE'), {
        signal: abort.signal
    });
});
modal?.addEventListener('hide.bs.modal', () => abort.abort());
document
    .querySelectorAll('.change-status')
    .forEach((button) => {
    const url = button.dataset.url;
    if (!url)
        return;
    button.addEventListener('click', () => httpMethodCall(url, 'PUT'));
});
