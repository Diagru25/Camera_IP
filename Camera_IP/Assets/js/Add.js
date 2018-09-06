$('#payment-button').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#cc-name').val();
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
        error: function () {
            alert('error: 500 internal server');
        }
    })
})