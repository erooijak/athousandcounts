$(function () {
    var thisCount = $("#count").text();
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

                if ((steps < 0 && from >= to) || (steps > 0 && to >= from)) {
                    clearInterval(counter);
                };

                if (to === 0)
                {
                    self.text('COUNT ' + thisCount + '!');
                }
            };

            counter = setInterval(step, time || 100);
        }
    });
 
});
function startRecordingWithCounter(callback) {
    $('#messageNextToButton').animateCount(0, 3, 1000);
    setTimeout(callback, 3000);
}
function showRecord() {
    $("#recordStartButton").attr("disabled", false);
}
function startRecording() {
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
    $('#message').html('Thank you for participating at A Thousand Counts. Your clip will be processed into a video once we have received 1000 counts.<br/><br/>If you know other happy counters like you please invite them!');
    var fileNameNoExtension = fileName.replace(".mp4", "");
    completeCount();
}
function onError(errorId, errorMsg) {
    alert(errorMsg);
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
