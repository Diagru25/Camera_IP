
$(document).ready(function () {
    $('ul').children().removeClass('active');
    $('#a_manage').parent().addClass('active');

    var type = $('#select_type_camera_edit').data('value');

    $('option[value="' + type + '"]').prop('selected', true);
    //$('#select_type_camera_edit option:selected').val(type);
})


// button sua camera
$('#payment-button').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#select_type_camera_edit :selected').val();
    var trangthai = "Online";
    var id = $(this).data('id');
    $.ajax({
        url: '/Manage/Edit_abc_Camera',
        data: {id: id, ten: ten, diachi_ip: diachi_ip, cong: cong, vitri: vitri, loai: loai, trangthai: trangthai },
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
})


//button them camera
$('#payment-button-add').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#select_type_camera :selected').val();
    var trangthai = "Online";

    $.ajax({
        url: '/Manage/Add_abc_Camera',
        data: { ten: ten, diachi_ip: diachi_ip, cong: cong, vitri: vitri, loai: loai, trangthai: trangthai },
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
})