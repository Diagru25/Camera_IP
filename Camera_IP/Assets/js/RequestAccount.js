
$(document).ready(function () {
    $('ul').children().removeClass('active');
    $('#a_account').parent().addClass('active');
})

//Accept 
$('.btn_edit').off('click').on('click', function () {
    var id = $(this).data('id');

    var result = confirm('Bạn có chắc chắn muốn cấp quyền cho tài khoản này');
    if (result == true)
    {
        $.ajax({
            url: '/Account/AcceptAccount',
            data: { Account_ID: id },
            contenType:'x-www-form-unlencoded',
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Cấp quyền thành công');
                    window.location.href = '/Account/RequestAccount';
                }
                else {
                    alert('Cấp quyền không thành công');
                }
            },
            error: function () {
                alert('error: 500 internal server');
            }

        })
    }
})

//Delete
$('.btn_delete').off('click').on('click', function () {
    var id = $(this).data('id');
    var result = confirm('Bạn có chắc chắn muốn từ chối tài khoản này');
    if (result == true) {
        $.ajax({
            url: '/Account/DenyAccount',
            data: { Account_ID: id },
            contenType: 'x-www-form-unlencoded',
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Từ chối thành công');
                    window.location.href = '/Account/RequestAccount';
                }
                else {
                    alert('Từ chối không thành công');
                }
            },
            error: function () {
                alert('error: 500 internal server');
            }

        })
    }
})
