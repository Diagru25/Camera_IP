$(document).ready(function () {
    $('ul').children().removeClass('active');
    $('#a_account').parent().addClass('active');
})

$(document).ready(function () {
    var array = document.getElementsByClassName('role-select');
    for (var i = 0; i < array.length; i++) {
        array[i].value = array[i].getAttribute('data-id');
    }
})
//Edit 
$('.btn_edit').off('click').on('click', function () {
    var id = $(this).parent().parent().data('id');
    var role_id = $(this).parent().parent().data('role_id');

    var result = confirm('Bạn có chắc chắn muốn thay đổi quyền cho tài khoản này');
    if (result == true) {
        $.ajax({
            url: '/Account/ChangeRoleAccount',
            data: { Account_ID: id, Role_ID: role_id},
            contenType: 'x-www-form-unlencoded',
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Thay đổi quyền thành công');
                    window.location.href = '/Account/RoleAccount';
                }
                else {
                    alert('Thay đổi quyền không thành công');
                }
            },
            error: function () {
                alert('error: 500 internal server');
            }

        })
    }
})
$('.role-select').off('click').on('click', function () {
    $(this).parent().parent().data('role_id', $(this).val());
})

//Delete
$('.btn_delete').off('click').on('click', function () {
    var id = $(this).data('id');
    var result = confirm('Bạn có chắc chắn muốn xóa tài khoản này');
    if (result == true) {
        $.ajax({
            url: '/Account/DeleteAccount',
            data: { Account_ID: id },
            contenType: 'x-www-form-unlencoded',
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Xóa thành công');
                    window.location.href = '/Account/RoleAccount';
                }
                else {
                    alert('Xóa không thành công');
                }
            },
            error: function () {
                alert('error: 500 internal server');
            }

        })
    }
})