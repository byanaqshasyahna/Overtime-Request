// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Register() {

    event.preventDefault();

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.FirstName = $("#FirstName").val();
    obj.LastName = $("#LastName").val();
    obj.Gender = parseInt($("#Gender").val());
    obj.Phone = $("#Phone").val();
    obj.BirthDate = $("#BirthDate").val();
    obj.Salary = $("#Salary").val();
    obj.Email = $("#Email").val();
    obj.Password = $("#Password").val();

    console.log(obj);


    $.ajax({
        
        url: '../Accounts/Register',
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