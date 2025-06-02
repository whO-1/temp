$(document).ready(function () {
    console.log("dataTable users")
    try {
        loadDataTable();

    }
    catch (err) {
        console.error(err);
    }
});

let dataTable;

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "serverSide": true,
        "processing": true,
        "ajax": {
            url: employeeDataUrl,
            dataSrc: 'data'
        },
        "columns": [
            { data: 'department'},
            { data: 'fullName' },
            { data: 'birthday' },
            { data: 'employedFrom' },
            { data: 'salary' },
            {
                data: 'id',
                "render": function (data) {
                    return (`
                        <div class="btn-group " role="group">
                            <button  type="button" class="edit-btn btn btn-warning" data-bs-toggle="modal" data-bs-target="#updateEmployeeModal" data-id="${data}">
                                Edit
                            </button>
                            <button  class="delete-btn btn btn-danger" data-id="${data}">Delete</button>
                        </div>
                    `);
                },
            }
        ]
    });
}

$('#tblData').on('click', '.delete-btn', function () {
    var token = $('input[name="__RequestVerificationToken"]').val();
    var employeeId = $(this).data('id');
    if (confirm('Are you sure you want to delete this employee?')) {
        $.ajax({
            url: employeeDeleteUrl,
            method: 'POST',
            contentType: 'application/json',
            headers: {
                'RequestVerificationToken': token
            },
            data: JSON.stringify({ id: employeeId }),
            success: function (response) {
                if (response.success) {
                    alert('Deleted successfully!');
                    $('#tblData').DataTable().ajax.reload();
                } else {
                    alert('Delete failed: ' + response.message);
                }
            }
        });
    }
}); 


