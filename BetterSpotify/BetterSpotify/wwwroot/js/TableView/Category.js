

var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#tblData').DataTable(
        {
        "ajax": {
            "url":"/Admin/Category/GetAll"
        },
            "columns": [
                { "data": "idCategory", "width": "1%" },
                { "data": "name", "width": "25%" },
                { "data": "colorHex", "width": "15%" },
                { "data": "imageFile", "width": "100%" },
            ]

        },
    );
}