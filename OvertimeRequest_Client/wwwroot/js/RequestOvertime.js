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

            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.NIP = result.nip;
            obj.DateRequest = $('#RequestDate').val();
            obj.StartTime = $('#StartTime').val();
            obj.EndTime = $('#FinishTime').val();
            obj.Desctription = $('#Description').val();

            console.log(obj);

        }

    })


    /*

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.NIP = getNIP;
    

    console.log(obj);


    $.ajax({
        //from local api
        *//*url: 'https://localhost:56213/api/Accounts/Register',*//*
        //from local client
        url: '../Accounts/Register',
        type: 'POST',
        *//*headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        dataType: 'json',*//*
        *//*data: JSON.stringify(obj),*//*
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
    })*/
}