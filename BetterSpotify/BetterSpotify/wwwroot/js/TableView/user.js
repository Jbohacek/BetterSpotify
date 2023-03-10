

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

        },
    );
}