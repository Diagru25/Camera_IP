//Webcam
//var video = document.querySelector("#videoElement");

//if (navigator.mediaDevices.getUserMedia) {
//    navigator.mediaDevices.getUserMedia({ video: true })
//  .then(function (stream) {
//      video.srcObject = stream;
//  })
//  .catch(function (err0r) {
//      console.log("Something went wrong!");
//  });
//}

// chọn số lượng
$('#number_camera').click(function () {
    var num = $('#select_num_camera :selected').val();
    var i = 0;
    for(i; i < num; i++)
    {
        var id_box = "#box" + i;

        $(id_box).removeClass("hidenbox");
    }

    for (var j = num; j < 8; j++) {
        var id_box = "#box" + j;

        $(id_box).addClass("hidenbox");
    }
})