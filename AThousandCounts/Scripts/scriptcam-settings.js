$(document).ready(function () {
    $("#webcam").scriptcam({
        width: 520,
        height: 360,
        path: '/ScriptCam/',
        fileReady: fileReady,
        cornerRadius: 20,
        cornerColor: 'e3e5e2',
        onError: onError,
        showMicrophoneErrors: false,
        timeLeft: timeLeft,
        fileName: 'athousandcounts',
        connected: showRecord
    });

});

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
    $('#message').html('Please wait for the file conversion to finish...');
}
function fileReady(fileName) {
    $('#recorder').hide();
    $('#message').html('This file is now dowloadable for five minutes over <a href=' + fileName + '>here</a>.');
    var fileNameNoExtension = fileName.replace(".mp4", "");

}
function onError(errorId, errorMsg) {
    alert(errorMsg);
}

function timeLeft(value) {
    $('#timeLeft').val(value);
}
