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
    $('#message').html('Thank you for participating at A Thousand Counts. You can check your recording for five minutes <a href=' + fileName + '>here</a>.<br/><br/>If you know other happy counters like you please invite them!');
    var fileNameNoExtension = fileName.replace(".mp4", "");

}
function onError(errorId, errorMsg) {
    alert(errorMsg);
}

function timeLeft(value) {
    $('#timeLeft').val(value);
}
