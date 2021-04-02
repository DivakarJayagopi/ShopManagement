"use strict";

var dropzone = new Dropzone("#mydropzone", {
    url: "#"
});
var self = this;
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
                    }
                };
            }(file, totalSteps, step), duration);
        }
    }
}

$(".SubmitUploadedImages").click(function () {
    var _FilesInfo = self;
    var FilesList = []
    if (typeof (_FilesInfo) != "undefined" && _FilesInfo != null && _FilesInfo.files.length > 0) {
        var Status = $("ImageStatus").val();
        for (var i = 0; i < _FilesInfo.files.length; i++) {
            FilesList.push(_FilesInfo.files[i].dataURL);
        }
        var _filesList = JSON.stringify(FilesList)
    }

})