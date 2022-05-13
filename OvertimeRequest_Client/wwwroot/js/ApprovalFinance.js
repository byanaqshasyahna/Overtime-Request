var span = document.getElementById('nameLogin');
var name = $("#nickName").val();

while (span.firstChild) {
    span.removeChild(span.firstChild);
}
span.appendChild(document.createTextNode(name));

$(document).ready(function () {
    $("#ApprovalFinance").DataTable({
        "filter": true,
        "orderMulti": false,
        "processing": true,
        "ajax": {
            "url": "../Employees/DataFinance",
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
                                <div class="col-sm-2"><button onclick ="DetailActivityFinance('${row["overtimeId"]}')" class="btn btn-secondary" data-toggle="modal" data-target="#modalDetailOvertime" >Detail</button></div>
                            </div> `;
                }

            },
            {
                "autowidth": true,
                "orderable": false,
                "render": function (data, type, row) {
                    return `<button onclick="ApproveFinance('${row["overtimeId"]}',  '${row["dateOvertime"]}', '${row["dateRequest"]}')" class="btn btn-success fas fa-fw fa-thumbs-up"></button>
                            <button onclick="DeclineFinance('${row["overtimeId"]}',  '${row["dateOvertime"]}', '${row["dateRequest"]}')" class="btn btn-danger fas fa-fw fa-thumbs-down"></button>`
                },
            },
        ],
    });
});


function DetailActivityFinance(overtimeId) {
    console.log(overtimeId);

    $.ajax({
        url: "../Employees/GetActivityList?overtimeId=" + overtimeId,
        success: function (result) {
            console.log(result);
            var text = "cobain";
            var hasil = 0;
            $.each(result, function (key, val) {
                text += `<tr>
                      <th scope="row">${key+1}</th>
                      <td>${moment(val.startTime).format('LT')}</td>
                      <td>${moment(val.finishTime).format('LT')}</td>
                      <td>${val.description}</td>
                    </tr>`;

                var start = new Date(val.startTime)
                var end = new Date(val.finishTime);

                hasil += diff_hours(start, end)
                

            });

            console.log("hasilnya adalah :" + hasil);

            $("#activityList").html(text);


        }

    })

}

function diff_hours(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60);
    return Math.abs(Math.round(diff));

}


function ApproveFinance(id, overtimeDate, createDate) {
    console.log(id + " " + overtimeDate + " " + createDate);


    $.ajax({
        url: "../Employees/GetActivityList?overtimeId=" + id,
        success: function (result) {
            console.log(result);

            var waktuKerja = 0;
            $.each(result, function (key, val) {
                

                var start = new Date(val.startTime)
                var end = new Date(val.finishTime);

                waktuKerja += diff_hours(start, end)
                

            });
            var gaji = parseInt($("#salary").val());
            var upahLembur = 1 / 173 * gaji

            if (waktuKerja > 1) {
                var waktuLebih = waktuKerja - 1
                var totalgajiLembur = parseInt(waktuLebih * 2 * upahLembur + (1 * 1.5 * upahLembur));
            } else {
                var totalgajiLembur = parseInt(1 * 1.5 * upahLembur)
            }

            console.log("gaji lembur" + totalgajiLembur)
            console.log("gajinya : " + gaji)
            console.log("hasilnya adalah :" + waktuKerja)

            var obj = new Object();
            obj.Id = id;
            obj.OvertimeDate = overtimeDate;
            obj.CreateDate = createDate;
            obj.FinanceApprove = 1;
            obj.ManagerApprove = 1;
            obj.Paid = totalgajiLembur;

            console.log(obj);

             $.ajax({

                url: '../overtimes/put',
                type: 'PUT',

                data: obj,
            }).done((result) => {
                //buat alert pemberitahuan jika success
                console.log(result);

                console.log("Sukses");
                setTimeout(location.reload(), 10000);
            }).fail((error) => {
                //alert pemberitahuan jika gagal
                console.log("gabisa bro");
            })

        }

    })



    

   
}
function DeclineFinance(id, overtimeDate, createDate) {
    console.log(id + " " + overtimeDate + " " + createDate);
    var obj = new Object();
    obj.Id = id;
    obj.OvertimeDate = overtimeDate;
    obj.CreateDate = createDate;
    obj.FinanceApprove = 2;
    obj.ManagerApprove = 2;

    console.log(obj);

    $.ajax({

        url: '../overtimes/put',
        type: 'PUT',

        data: obj,
    }).done((result) => {
        //buat alert pemberitahuan jika success
        console.log(result);

        console.log("Sukses");
        setTimeout(location.reload(), 10000);
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        console.log("gabisa bro");
    })
}
