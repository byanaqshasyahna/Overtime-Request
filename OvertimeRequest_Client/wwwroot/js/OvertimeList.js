$(document).ready(function () {
    $("#OvertimeList").DataTable({
        "filter": true,
        "orderMulti": false,
        "processing": true,
        "ajax": {
            "url": " ",
            "datatype": "json",
            "dataSrc": " "
        },
        "columns": [
            {
                "data": null,
                "name": "no",
                "autoWidth": true,
                "render": function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            {
                "data": 'fullname',
                "autoWidth": true,

            },
            {
                "data": "role",
                "audtoWidth": true,

            },
            {
                "autowidth": true,
                "orderable": false,
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" data-toggle="modal" onclick="fungsi" data-target="#StatusWindow">Status</button>`
                }.
            }]
    });
});