"use strict";
document
    .querySelectorAll('.change-status')
    .forEach((button) => {
    const url = button.dataset.url;
    if (!url)
        return;
    button.addEventListener('click', () => fetch(url, { method: 'PUT' }).finally(() => location.replace(location.href)));
});
//# sourceMappingURL=change_status.js.map