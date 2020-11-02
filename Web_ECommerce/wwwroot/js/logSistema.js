var objetojson = {};

var jsonView = new JSONViewer();

function ConfiguraJson() {
    var json = $("#JsonInformacao").val();

    if (json != undefined && json != null && json != "") {

        objetojson = JSON.parse(json);

        jsonView.showJSON(objetojson);

        document.querySelector("#json").appendChild(jsonView.getContainer());
    }
}
$(function () {
    ConfiguraJson();
});