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
                /*"render": function (data, type, row, meta) {
                    return row["roleName[]"];
                }*/

            },
            {
                "data": null,
                "autoWidth": true,
                "render": function (data, type, row, meta) {
                    return moment(row["dateRequest"]).format('LL');
                }

            },
            {
                "data": null,
                "autoWidth": true,
                "render": function (data, type, row, meta) {
                    return ` <div class="row">
                                <div class="col-sm-5">${moment(row["dateOvertime"]).format('LL')}</div>
                                <div class="col-sm-2"><button onclick ="DetailActivity('${row["overtimeId"]}')" class="btn btn-secondary" data-toggle="modal" data-target="#modalDetailOvertime" >Detail</button></div>
                            </div> `;
                }

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

function DetailActivity(overtimeId) {
    console.log(overtimeId);

    $.ajax({
        url: "../Employees/GetActivityList?overtimeId=" + 7,
        success: function (result) {
            console.log(result);
            var text = "cobain";

            $.each(result, function (key, val) {
                text += `<tr>
                      <th scope="row">${val.id}</th>
                      <td>${moment(val.startTime).format('LT')}</td>
                      <td>${moment(val.finishTime).format('LT') }</td>
                      <td>${val.description}</td>
                    </tr>`
            });


            $("#activityList").html(text);


        }

    })

}

function Approve() { }
function Decline() { }
