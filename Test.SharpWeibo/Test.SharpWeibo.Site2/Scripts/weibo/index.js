/// <reference path="../_references.js" />
var btn = $("#btnLoad").click(function () {
    $.ajax("weibo/api/acount/Login/zhxiaog/1", {
        accepts: "application/xml",
        success: onSuccess,
        error: onError
    });
});

function onSuccess(data) {
    var e = data;
    btn[0].innerText = data.NeckName;
 }
function onError(data) { }