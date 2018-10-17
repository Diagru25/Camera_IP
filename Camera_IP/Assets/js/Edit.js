
$(document).ready(function () {

    //chỉnh class active của lefmenu
    $('ul').children().removeClass('active');
    $('#a_manage').parent().addClass('active');


    // xét giá trị khi cấu hình camera
    var type = $('#select_type_camera_edit').data('value');

    $('option[value="' + type + '"]').prop('selected', true);

    // xét giá trị cho đường dẫn khi khỏi tạo
    Set_value_path_add();
})


// button sua camera
$('#payment-button').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#select_type_camera_edit :selected').val();
    var trangthai = "Online";
    var duongdan = $('#cc-number-path').val();
    var id = $(this).data('id');

    if (check_null(ten, diachi_ip, cong, vitri) == false) {
        return;
    }

    if (validate(diachi_ip, cong)) {
        $.ajax({
            url: '/Manage/Edit_abc_Camera',
            data: { id: id, ten: ten, diachi_ip: diachi_ip, cong: cong, vitri: vitri, loai: loai, trangthai: trangthai, duongdan: duongdan },
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Cấu hình camera thành công');
                    window.location.href = '/Manage/Index';
                }
                else {
                    alert('Cấu hình không thành công');
                }
            },
            error: function () {
                alert('error: 500 internal server');
            }
        })
    }
})


//button them camera
$('#payment-button-add').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#select_type_camera :selected').val();
    var trangthai = "Online";
    var duongdan = $('#cc-number-path').val();
    if (check_null(ten, diachi_ip, cong, vitri) == false) {
        return;
    }

    if (validate(diachi_ip, cong)) {
        $.ajax({
            url: '/Manage/Add_abc_Camera',
            data: { ten: ten, diachi_ip: diachi_ip, cong: cong, vitri: vitri, loai: loai, trangthai: trangthai, duongdan: duongdan },
            type: 'post',
            dataType: 'json',
            success: function (data) {
                if (data.status == true) {
                    alert('Thêm camera thành công');
                    window.location.href = '/Manage/Index';
                }
                else {
                    alert('Thêm không thành công');
                }
            },
            complete: function () {
                window.location.href = '/Manage/Index';
            },
            error: function () {
                alert('error: 500 internal server');
            }
        })
    }

})


// Event change value

// thay đổi loại camera
$('#select_type_camera').change(function () {
    Set_value_path_add();
})
$('#select_type_camera_edit').change(function () {
    Set_value_path_edit();
})
// thay đổi địa chỉ ip
$('#cc-exp').change(function () {
    if (Set_value_path_add() == false) {
       
        Set_value_path_edit();
    }
    
})

//thay đổi cổng
$('#x_card_code').change(function () {
    if (Set_value_path_add() == false) {
        Set_value_path_edit();
    }
})


// sử dụng trong phần thêm camera
function Set_value_path_add() {
    var path = "";
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var loai = $('#select_type_camera :selected').val();

    if (loai == "SmartPhone") {
        path += "http://" + diachi_ip + ":" + cong + "/video";
    }
    if (loai == "Webcam") {
        path = "videoElement";
    }
    $('#cc-number-path').val(path);

    if (loai == undefined)
        return false;
    else return true;
}

// sử dụng trong phần sửa camera
function Set_value_path_edit() {
    var path = "";
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var loai = $('#select_type_camera_edit :selected').val();

    if (loai == "SmartPhone") {
        path += "http://" + diachi_ip + ":" + cong + "/video";
    }
    if (loai == "Webcam") {
        path = "videoElement";
    }
    $('#cc-number-path').val(path);
}


//validate
function validate(ip_address, port) {

    var check = 0;
    if (validate_ip(ip_address) == false) {
        $('#text_ip').empty().append("Sai địa chỉ ip").css("color", "red");
        check = 1;
    }
    else {
        $('#text_ip').empty();
    }

    if (validate_port(port) == false) {
        $('#text_port').empty().append("Sai cổng").css("color", "red");
        check = 1;
    }
    else {
        $('#text_port').empty();
    }

    return check == 0 ? true : false;
}

//validate port
function validate_port(port) {
    //return false;
    var convert = parseInt(port);

    if (convert >= 0 && convert < 65536) {
        return true;
    }
    else return false;
}

//validate ip_address
function validate_ip(ip_address) {

    var ip_address_split = ip_address.split(".");

    if (ip_address_split.length != 4)
        return false;
    else {
        for (var i = 0; i < 4; i++) {
            if (ip_address_split[i] < 0 || ip_address_split[i] > 255)
                return false;
        }
        return true;
    }
}

//check null
function check_null(ten, diachi_ip, cong, vitri) {
    if (ten == "" || diachi_ip == "" || cong == "" || vitri == "") {
        alert('Không được để trống các trường');
        return false;
    }
    else return true;
}