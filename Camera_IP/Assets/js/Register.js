//Register button
$('#register-button').off('click').on('click', function () {
    var userName = $('#username-text').val();
    var password = $('#password-text').val();
    var role_id = $('#role-select').val();
    if (userName == '' || password == '' || role_id == '') {
        alert('Không được để trống các trường');
        return;
    }
    $.ajax({
        url: '/Login/UserRegister',
        data: { userName: userName, password: password, role_id: role_id },
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.status == 'success') {
                alert('Đăng kí thành công');
                window.location.href = '/Login/Index';
            }
            else if(data.status == 'duplicate'){
                alert('Tên đăng nhập đã tồn tại');
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

//Validate cofirm password
$('#password-text, #confirm-password-text').on('keyup', function () {
    if ($('#password-text').val() == $('#confirm-password-text').val()) {
        $('#confirm_message').html('').css('color', 'green');
        $('#register-button').prop('disabled', false);
    } else {
        $('#confirm_message').html('Chưa chính xác').css('color', 'red');
        $('#register-button').prop('disabled', true);
    }
});

//Validate username null
$('#username-text').on('keyup', function () {
    if ($('#username-text').val() !='') {
        $('#username_message').html('').css('color', 'green');
        $('#register-button').prop('disabled', false);
    } else {
        $('#username_message').html('Không được để trống').css('color', 'red');
        $('#register-button').prop('disabled', true);
    }
       
});
//Validate username null
$('#password-text').on('keyup', function () {
    if ($('#password-text').val() != '') {
        $('#password_message').html('').css('color', 'green');
        $('#register-button').prop('disabled', false);
    } else
        $('#password_message').html('Không được để trống').css('color', 'red');
        $('#register-button').prop('disabled', true);
});
