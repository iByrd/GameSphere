"use strict";
const abort = new AbortController();
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
        ?.addEventListener('click', () => fetch(url, { method: 'DELETE' }).finally(() => location.replace(location.href)));
});
modal?.addEventListener('hide.bs.modal', () => abort.abort());
//# sourceMappingURL=delete_modal.js.map