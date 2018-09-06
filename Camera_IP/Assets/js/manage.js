$('.btn_delete').off('click').on('click', function () {
    var id = $(this).data('id');

    $.ajax({
        url: '/Manage/Delete_camera',
        data: { id: id },
        type: 'post',
        dataType: 'json',
        success: function (data) {
            if (data.status == true) {
                alert('Xóa camera thành công');
                window.location.href = '/Manage/Index';
            }
            else {
                alert('Xóa không thành công');
            }
        },
        error: function () {
            alert('error: 500 internal server');
        }

    })
})
