
$(document).ready(function () {
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

// chọn số lượng
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

// cac button full man hinh dc click

//load = js

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


//button 0
//$('#btn-box0').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 2
//$('#btn-box2').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 3
//$('#btn-box3').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 4
//$('#btn-box4').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 5
//$('#btn-box5').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 6
//$('#btn-box6').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 7
//$('#btn-box7').click(function () {
//    $('#view_camera').empty();

//    var html_camera = "<img style='width: 250px;' class='img-responsive' src='http://169.254.252.253/nphMotionJpeg?Resolution=192x144&Quality=Standard' />";

//    $('#view_camera').append(html_camera);
//})

////button 1
//$('#btn-box1').click(function () {

//    // clear the div
//    $('#view_camera').empty();

//    var html_camera = "<video autoplay='true' id='videoElement_modal' style='max-width:100%;'></video>";

//    $('#view_camera').append(html_camera);

//    var video = document.querySelector("#videoElement_modal");

//    if (navigator.mediaDevices.getUserMedia) {
//        navigator.mediaDevices.getUserMedia({ video: true })
//      .then(function (stream) {
//          video.srcObject = stream;
//      })
//      .catch(function (err0r) {
//          console.log("Something went wrong!");
//      });
//    }
//})