"use strict";

var dropzone = new Dropzone("#mydropzone", {
    url: "#"
});
var self;
var minSteps = 6,
    maxSteps = 60,
    timeBetweenSteps = 100,
    bytesPerStep = 100000;

dropzone.uploadFiles = function (files) {
    self = this;
    var totalSteps;

    for (var i = 0; i < files.length; i++) {

        var file = files[i];
        totalSteps = Math.round(Math.min(maxSteps, Math.max(minSteps, file.size / bytesPerStep)));

        for (var step = 0; step < totalSteps; step++) {
            var duration = timeBetweenSteps * (step + 1);
            setTimeout(function (file, totalSteps, step) {
                return function () {
                    file.upload = {
                        progress: 100 * (step + 1) / totalSteps,
                        total: file.size,
                        bytesSent: (step + 1) * file.size / totalSteps
                    };

                    self.emit('uploadprogress', file, file.upload.progress, file.upload.bytesSent);
                    if (file.upload.progress == 100) {
                        file.status = Dropzone.SUCCESS;
                        self.emit("success", file, 'success', null);
                        self.emit("complete", file);
                        self.processQueue();
                        $(".SubmitUploadedImages").show();
                    }
                };
            }(file, totalSteps, step), duration);
        }
    }
}



$(".SubmitUploadedImages").click(function () {
    $(".SubmitUploadedImages").addClass("btn-progress");
    var _FilesInfo = self;
    var QualityType = $(".ImageStatus").val();
    if (typeof (_FilesInfo) != "undefined" && _FilesInfo != null && _FilesInfo.files.length > 0) {

        for (var i = 0; i < _FilesInfo.files.length; i++) {
            var SelectedImage = _FilesInfo.files[i].dataURL;
            var data = '{Images:"' + SelectedImage + '",QualityType:"' + QualityType + '"}';
            handleAjaxRequest(null, true, "/Method/AddImage", data, "CallBackAddImage");
        }
    } else {
        $(".SubmitUploadedImages").removeClass("btn-progress");
    }
      
    
});

function CallBackAddImage(responseData) {
    $(".SubmitUploadedImages").removeClass("btn-progress");
    var _FilesInfo = self;
    if (typeof (_FilesInfo) != "undefined" && _FilesInfo != null && _FilesInfo.files.length > 0) {
        for (var i = 0; i < _FilesInfo.files.length; i++) {
            dropzone.removeFile(_FilesInfo.files[i]);
        }        
    }
    $(".SubmitUploadedImages").hide();
    if (responseData.message.status == "success") {
        $("input[type=\"file\"]").val('');
        iziToast.success({
            title: 'success',
            message: 'Images Uploaded Successfully',
            position: 'topCenter'
        });
    } else {
        iziToast.success({
            title: 'danger',
            message: 'Error on uploading Images',
            position: 'topCenter'
        });
    }
}