﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

var span = document.getElementById('nameLogin');
var name = $("#nickName").val();

while (span.firstChild) {
    span.removeChild(span.firstChild);
}
span.appendChild(document.createTextNode(name));


var counter = 1;
function addMoreRequest() {
    counter += 1;
    html = `<div id="aktivitas` + counter +`" class="form-row">

        <div class="form-group col-md-4">
            <label for="FirstName ">Start Time</label>
            <input type="time" class="form-control" id="StartTime`+counter+`" placeholder="Start Time" required>
            <div class="invalid-feedback">
                Insert Start Time
            </div>
        </div>

        <div class="form-group col-md-4">
            <label for="FirstName">Finish Time</label>
            <input type="Time" class="form-control" id="FinishTime`+counter+`" placeholder="End Time" required>
            <div class="invalid-feedback">
                Insert Start Time
            </div>
        </div>

        <div class="form-group col-md-4">
            <label for="FirstName"> Description</label>
            <input type="text" class="form-control" id="Description`+counter+`" placeholder="Description" required>
            <div class="invalid-feedback">
                Insert Start Time
            </div>
        </div>
        </div>`

    //menyisipkan
    $(".test").append(html)
    /*var form = document.getElementById('Overtime');
    form.innerHTML += html;*/

    
    
}

function deleteMoreRequest() {
    console.log(counter);
    var colom = document.getElementById('aktivitas'+ counter +'');
    colom.remove();
    counter -= 1;
}









function RequestOvertime() {
    console.log("disini counter =" + counter)
    event.preventDefault();
    var Email = $('#email').val();
    var NIP = $('#nip').val();
    
    let daftar = []

    for (var i = 1; i <= counter; i++) {


        console.log("hitungan loop : " + i)


        var date = new Date($('#RequestDate').val());
        var timeStart = $('#RequestDate').val() + "T" + $('#StartTime' + (i) + '').val() + ":00";
        var timeEnd = $('#RequestDate').val() + "T" + $('#FinishTime' + (i) + '').val() + ":00";
        console.log(timeStart);

        var obj = new Object();
        obj.DateRequest = $('#RequestDate').val();
        obj.StartTime = timeStart;
        obj.EndTime = timeEnd;
        obj.Description = $('#Description' + (i) + '').val();
        obj.NIP = NIP
        console.log(NIP)

        
        console.log(obj)
        daftar.push(obj)
        

                

        
           

    }

    console.log(daftar)


    $.ajax({
                 url:'https://localhost:44308/api/Employees/OvertimeRequest',
                    type: 'POST',
                    data: JSON.stringify(daftar),
                    headers: {
                        Accept: 'application/json',
                        'Content-Type': 'application/json',
                    }
                    
                }).done((result) => {
                    //buat alert pemberitahuan jika success
                    console.log(result);

                    if (result.status == 200) {
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            title: 'Your work has been saved',
                            showConfirmButton: false,
                            timer: 1500
                        }).then((result) => {
                            setTimeout(location.reload(), 5000);
                        })
                    } else {
                        Swal.fire({
                            position: 'center',
                            icon: 'error',
                            title: 'Fail to register',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    }
                    console.log("Sukses");
                }).fail((error) => {
                    //alert pemberitahuan jika gagal
                    console.log("gabisa bro");
                })
}