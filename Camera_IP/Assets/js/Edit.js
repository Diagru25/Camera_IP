$('#payment-button').off('click').on('click', function () {
    var ten = $('#cc-pament').val();
    var diachi_ip = $('#cc-exp').val();
    var cong = $('#x_card_code').val();
    var vitri = $('#cc-number').val();
    var loai = $('#cc-name').val();
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