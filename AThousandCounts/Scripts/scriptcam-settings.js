$(function () {
    var thisCount = $("#count").text();
    var countsLeft = $("#countsLeft").text().toString();
    var theFileName = ('athousandcounts' + thisCount).toString();

    $("#webcam").scriptcam({
        width: 520,
        height: 360,
        path: '/ScriptCam/',
        fileReady: fileReady,
        cornerRadius: 20,
        cornerColor: 'e3e5e2',
        onError: onError,
        showMicrophoneErrors: true,
        useMicrophone: true,
        timeLeft: timeLeft,
        fileName: theFileName,
        connected: showRecord,
        maximumTime: 10
    });
    jQuery.fn.extend({
        animateCount: function (from, to, time) {
            var steps = 1,
                self = this,
                counter;

            if (to - from > 0) {
                steps = -1;
            };

            to -= steps;

            function step() {
                self.text(to += steps);

                if (to === 4) {
                    self.text('COUNT ' + thisCount + '!');
                }

                if ((steps < 0 && from >= to) || (steps > 0 && to >= from)) {
                    clearInterval(counter);
                };

                if (to === 0) {
                    self.text('COUNT!');
                }

            };

            counter = setInterval(step, time || 100);
        }
    });

});
function startRecordingWithCounter(callback) {
    $('#popup').show();
    $('#popupText').animateCount(0, 4, 1000);
    setTimeout(callback, 5200);
}
function showRecord() {
    $("#recordStartButton").attr("disabled", false);
}
function startRecording() {
    $('#popup').hide();
    $("#recordStartButton").attr("disabled", true);
    $("#recordStopButton").attr("disabled", false);
    $("#recordPauseResumeButton").attr("disabled", false);
    $.scriptcam.startRecording();
}
function closeCamera() {
    $("#slider").slider("option", "disabled", true);
    $("#recordPauseResumeButton").attr("disabled", true);
    $("#recordStopButton").attr("disabled", true);
    $.scriptcam.closeCamera();
    setMessage();
}
function fileReady(fileName) {
    $('#recorder').hide();
    $('#message').fadeOut();
    var finalMessage = 'Thank you for participating at A Thousand Counts. Your clip will be processed into a video once we have received the last ' + countsLeft + ' counts.<br/><br/>If you know other happy counters like you please invite them!';
    $('#finalMessage').text(finalMessage);
    var fileNameNoExtension = fileName.replace(".mp4", "");
    completeCount();
}
function onError(errorId, errorMsg) {
    $('#message').html('Please wait for the file conversion to finish...');
}

function timeLeft(value) {
    $('#timeLeft').val(value);
}

function setMessage() {
    $('#message').html('Please wait for the file conversion to finish...');
}

function completeCount() {
    var id = $("#count").text();
    $.post('/Count/CompleteCount/' + id, null);
}
