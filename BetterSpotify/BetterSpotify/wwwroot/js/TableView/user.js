

var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#tblData').DataTable(
        {
        "ajax": {
            "url":"/Admin/User/GetAll"
        },
            "columns": [
                { "data": "idUser", "width": "1%" },
                {
                    "data": "idUser",
                    "render": function (data) {
                        return `<div class="btn-group" role="group">
                                <a class="btn btn-secondary mx-1" href="/Admin/User/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
                                <a class="btn btn-danger mx-1" onClick=Delete('/Admin/User/Delete/${data}')><i class="bi bi-eraser"></i></a>
                                </div>`
                    },
                    "width": "15%"
                },
                { "data": "nickName", "width": "25%" },
                { "data": "firstName", "width": "15%" },
                { "data": "lastName", "width": "15%" },
                { "data": "email", "width": "25%" },
                { "data": "country", "width": "15%" },
                { "data": "getDateOfBirth", "width": "10%" },
                { "data": "getDateOfRegistration", "width": "10%" },
                { "data": "activeAccount", "width": "15%" },
                { "data": "verified", "width": "15%" },
                ]

        }
    );
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            console.log('Uspech');
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    console.log("neco");
                    if (data.success) {
                        $('#tblData').DataTable().ajax.reload();
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success');
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Something went wrong!'
                        })
                    }
                }
            })

        }
    })
}