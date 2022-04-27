$(document).ready(function () {
    $("#ApprovalManager").DataTable({
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
                    return `<button onclick="" class="btn btn-danger"></button>
                            <button onclick="" class="btn btn-success"></button>`
                }.
            }]
    });
});

function Approve() { }
function Decline() { }
