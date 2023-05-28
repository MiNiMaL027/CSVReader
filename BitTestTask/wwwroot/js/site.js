$(document).ready(function () {
    var table = $('#myTable').DataTable({
        ajax: {
            url: '/Home/GetAllPerson',
            method: 'GET',
            dataSrc: ''
        },
        columns: [
            { data: null, defaultContent: '', className: 'select-checkbox' },
            { data: 'name' },
            { data: 'dateOfBirth' },
            { data: 'married' },
            { data: 'phone' },
            { data: 'salary' },
            {
                data: null,
                defaultContent: '<button class="btn btn-primary btn-light editBtn"><i class="fas fa-pencil-alt"></i></button> <button class="btn btn-danger btn-light deleteBtn"><i class="fas fa-trash-alt"></i></button>'
            }
        ],
        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        searching: true,
        paging: true,
        ordering: true
    });

    $('#myTable tbody').on('click', '.editBtn', function () {
        rowData = table.row($(this).closest('tr')).data();
        openEditModal(rowData);
    });

    function openEditModal(rowData) {

        $('#nameInput').val(rowData.name);
        $('#dobInput').val(rowData.dateOfBirth);
        $('#marriedInput').prop('checked', rowData.married);
        $('#phoneInput').val(rowData.phone);
        $('#salaryInput').val(rowData.salary);

        $('#editModal').modal('show');
    }

    $('#editModal .close').click(function () {
        $('#editModal').modal('hide');
    });

    $('#editModal .modal-footer .btn-secondary').click(function () {
        $('#editModal').modal('hide');
    });

    $('#myTable tbody').on('click', '.deleteBtn', function () {
        var rowData = table.row($(this).closest('tr')).data();

        console.log('Delete row:', rowData);

        deleteRowOnServer(rowData);
    });

    $('#editModal').on('hidden.bs.modal', function () {

        $('#nameInput').val('');
        $('#dobInput').val('');
        $('#marriedInput').prop('checked', false);
        $('#phoneInput').val('');
        $('#salaryInput').val('');
    });

    $('#saveChangesModal').click(function () {
        var editedData = {
            id: rowData.id,
            name: $('#nameInput').val(),
            dateOfBirth: $('#dobInput').val(),
            married: $('#marriedInput').prop('checked'),
            phone: $('#phoneInput').val(),
            salary: $('#salaryInput').val(),
        };

        editRowOnServer(editedData);
    });

    function editRowOnServer(rowData) {
        $.ajax({
            url: '/Home/UpdatePerson',
            method: 'POST',
            data: rowData,
            success: function (response) {
                console.log('Row edited successfully:', response);
                table.ajax.reload();
            },
            error: function (error) {
                console.error('Error editing row:', error);
            }
        });
    }

    function deleteRowOnServer(rowData) {
        $.ajax({
            url: '/Home/DeletePerson',
            method: 'POST',
            data: { id: rowData.id },
            success: function (response) {
                console.log('Row deleted successfully:', response);
                table.ajax.reload();
            },
            error: function (error) {
                console.error('Error deleting row:', error);
            }
        });
    }
});
