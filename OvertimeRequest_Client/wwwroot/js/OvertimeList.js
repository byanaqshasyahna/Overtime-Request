var nipPribadi = $('#nip').val();
$(document).ready(function () {
    $("#OvertimeList").DataTable({
        "filter": true,
        "orderMulti": false,
        "processing": true,
        "ajax": {
            "url": "https://localhost:44308/api/Employees/DataPribadi/" + nipPribadi ,
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
                "data": 'fullName',
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
                    var accManager = row["managerApprove"]
                    var accFinance = row["financeApprove"]
                    if (accManager == 1 && accFinance == 0) {
                        return "Waiting Approved by Finance"
                    } else if (accManager == 1 && accFinance == 1) {
                        return "Approved"
                    } else if (accManager == 2 || accFinance == 2) {
                        return "Declined"
                    } else {
                        return "On Riview"
                    }
                    
                },
            },
            {
                "data": null,
                "autoWidth": true,
                "render": function (data, type, row, meta) {
                    return "Rp. " + row["paidOvertime"];
                }

            }
        ],
    });
});