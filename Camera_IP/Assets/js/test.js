
$(document).ready(function () {

    // chỉnh class active của leftmenu
    $('ul').children().removeClass('active');
    $('#a_monitor').parent().addClass('active');
})


//Webcam
var video = document.querySelector("#videoElement");

if (navigator.mediaDevices.getUserMedia) {
    navigator.mediaDevices.getUserMedia({ video: true })
  .then(function (stream) {
      video.srcObject = stream;
  })
  .catch(function (err0r) {
      console.log("Something went wrong!");
  });
}

// button chọn số lượng
$('#number_camera').click(function () {
    var num_camera = $(this).data('num');
    var num = $('#select_num_camera :selected').val();
    var i = 0;
    for(i; i < num; i++)
    {
        var id_box = "#box" + i;

        $(id_box).removeClass("hidenbox");
    }

    for (var j = num; j <= num_camera; j++) {
        var id_box = "#box" + j;

        $(id_box).addClass("hidenbox");
    }
})


// button phóng to của từng ô
$('.btn_zoom_out').off('click').on('click', function () {
    var src = $(this).data('src');

    $('#view_camera').empty();

    if (src != 'videoElement')
    {
        var html_camera = '<img style="width: 250px;" class="img-responsive" src="' + src + '" />';

        $('#view_camera').append(html_camera);
    }
    else
    {
        var html_camera = "<video autoplay='true' id='videoElement_modal' style='max-width:100%;'></video>";

        $('#view_camera').append(html_camera);

        var video = document.querySelector("#videoElement_modal");

        if (navigator.mediaDevices.getUserMedia) {
            navigator.mediaDevices.getUserMedia({ video: true })
          .then(function (stream) {
              video.srcObject = stream;
          })
          .catch(function (err0r) {
              console.log("Something went wrong!");
          });
        }
    }

})

