//
$('#login-button').off('click').on('click', function () {
    var user = $('#cc-username').val();
    var password = $('#cc-password').val();

    if (check_null(user, password) == false) {
        return;
    }

    $.ajax({
        url: '/Login/UserLogin',
        data: { userName: user, password: password },
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.status == true) {
                window.location.href = '/Monitor_Camera/Index';
            }
            else {
                alert('Đăng nhập không thành công');
            }
        },
        error: function () {
            alert('error: 500 internal server');
        }
    })

})
//check null
function check_null(userName, password) {
    if (userName == "") {
        alert('Bạn nhập tên đăng nhập');
        return false;
    }
    if (password == "") {
        alert('Bạn phải nhập mật khẩu');
        return false;
    }
    return true;
}