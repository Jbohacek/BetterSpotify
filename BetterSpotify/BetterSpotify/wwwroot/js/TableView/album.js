
var dataTable


$(document).ready(function () {
    loadDataTable();
});


function loadDataTable()
{
    dataTable = $('#tblData').DataTable(
        {
        "ajax": {
            "url":"/Admin/Album/GetAll"
        },
            "columns": [
            { "data": "idAlbum", "width": "1%" },
            { "data": "idUser", "width": "1%" },
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "20%" },
            { "data": "imageFile", "width": "15%" },
            { "data": "getDateOfPublish", "width": "15%" },
            ]
        },
    );
}