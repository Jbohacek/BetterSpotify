
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
            { "data": "IdAlbum", "width": "1%" },
            { "data": "IdUser", "width": "1%" },
            { "data": "Title", "width": "15%" },
            { "data": "Description", "width": "15%" },
            { "data": "ImageFile", "width": "25%" },
            { "data": "DateOfPublish", "width": "15%" },
            ]
        },
    );
}