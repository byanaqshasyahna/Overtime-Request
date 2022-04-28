$(document).ready(function () {
    $("#ApprovalManager").DataTable({
        "filter": true,
        "orderMulti": false,
        "processing": true,
        "ajax": {
            "url": "../Employees/DataManager",
            "datatype": "json",
            "dataSrc": "",
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
                "data": "roleName[].roleName",
                "audtoWidth": true,

            },
            {
                "autowidth": true,
                "orderable": false,
                "render": function (data, type, row) {
                    return `<button onclick="" class="btn btn-success fas fa-fw fa-thumbs-up"></button>
                            <button onclick="" class="btn btn-danger fas fa-fw fa-thumbs-down"></button>`
                },
            },
        ],
    });
});

function Approve() { }
function Decline() { }
