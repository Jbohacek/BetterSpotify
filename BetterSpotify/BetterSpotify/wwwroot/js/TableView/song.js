

var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#tblData').DataTable(
        {
        "ajax": {
            "url":"/Admin/Song/GetAll"
        },
            "columns": [
                { "data": "idSong", "width": "1%" },
                {
                    "data": "idSong",
                    "render": function (data) {
                        return `<div class="btn-group" role="group">
                                <a class="btn btn-secondary mx-1" href="/Admin/Song/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
                                <a class="btn btn-danger mx-1" onClick=Delete('/Admin/Song/Delete/${data}')><i class="bi bi-eraser"></i></a>
                                </div>`
                    },
                    "width": "5%"
                },
                { "data": "title", "width": "20%" },
                
            ]

        }
    );
}

function Delete(url) {
    console.log('Fired');
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