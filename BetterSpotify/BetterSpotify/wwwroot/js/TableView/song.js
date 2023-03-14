

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
                { "data": "idAlbum", "width": "25-%" },
                { "data": "idUser", "width": "15%" },
                { "data": "idCategory", "width": "15%" },
                { "data": "title", "width": "25%" },
                { "data": "discNo", "width": "15%" },
                { "data": "trackNo", "width": "10%" },
                { "data": "duration", "width": "10%" },
                { "data": "imageFile", "width": "15%" },
                { "data": "songFile", "width": "15%" },
                { "data": "getDateOfRelease", "width": "15%" },
            ]

        },
    );
}