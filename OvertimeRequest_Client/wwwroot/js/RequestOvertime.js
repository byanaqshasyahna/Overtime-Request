// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.











function RequestOvertime() {
    event.preventDefault();
    var Email = $('#email').val()

    $.ajax({
        //url didapat dari local client
        url: "../Employees/GetEmployeeByEmail?email=" + Email,
        success: function (result) {
            //console.log(result);
            console.log(result);

            var date = new Date($('#RequestDate').val());
            var timeStart = $('#RequestDate').val() + "T" + $('#StartTime').val() + ":00";
            var timeEnd = $('#RequestDate').val() + "T" + $('#FinishTime').val() + ":00";
            console.log(timeStart);


            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.NIP = result.nip;
            obj.DateRequest = $('#RequestDate').val();
            obj.StartTime = timeStart;
            obj.EndTime = timeEnd;
            obj.Description = $('#Description').val();

            /*obj.NIP = "2022004";
            obj.DateRequest = "05-30-2022";
            obj.StartTime = "2022-05-30T22:00:00";
            obj.EndTime = "2022-05-29T30:00:00";
            obj.Description = "Uji coba";*/

            console.log(obj);

            $.ajax({
                url: '../Employees/RequestOvertime',
                type: 'POST',
                data: obj,
            }).done((result) => {
                //buat alert pemberitahuan jika success
                console.log(result);

                if (result == 200) {
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

    })



}