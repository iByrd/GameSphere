import 'vite/modulepreload-polyfill'

import 'jquery-validation-unobtrusive'

document.getElementById('')

$('#bountyForm').validate({
  errorClass: 'help-block animation-slideDown',
  errorElement: 'span',
  errorPlacement: function (error, e) {
    e.parents('.form-group > span').append(error)
  },
  highlight: function (e) {
    $(e)
      .closest('.form-group')
      .removeClass('has-success has-error')
      .addClass('has-error')
    $(e).closest('.help-block').remove()
  },
  success: function (e) {
    e.closest('.form-group').removeClass('has-success has-error')
    e.closest('.help-block').remove()
  }
})
