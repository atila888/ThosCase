var datatable = "";
$(document).ready(function () {
    bindDatatable();
});
function bindDatatable() {
    datatable = $('#user-datatables')
        .DataTable({
            "sAjaxSource": "/User/Get",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "url": 'https://cdn.datatables.net/plug-ins/2.1.8/i18n/tr.json'
            },
            columnDefs: {
                "defaultContent": "-",
                "targets": "_all"
            },
            "columns": [
                {
                    "data": 'userid',
                    "render": function (data, type, full, meta) {
                        var content = "";
                        content += '<a class="btn btn-info" data-bs-toggle="modal" onclick=Update(' + data + ',"' + full.name + '","' + full.surname + '","' + full.username + '","' + full.hashpassword + '"); data-bs-id=' + data + ' data-bs-target="#updateUserModal">Duzenle</a>';
                        content += "<a href='#' class='btn btn-danger'  onclick=Delete('" + data + "'); >Sil</a>";
                        return content;
                    }
                },
                { "data": "name", "name": "Ad", "autoWidth": true },
                { "data": "surname", "name": "Soyad", "autoWidth": true },
                { "data": "username", "title": "Kullan�c� Ad�", "autoWidth": true },
                { "data": "hashpassword", "name": "Hash �ifre", "autoWidth": true }
            ]
        });
}
function Delete(id) {
    $.ajax({
        type: "POST",
        async: true,
        url: "/User/Delete",
        data: {
            id: id
        },
        success: function (res) {
            datatable.ajax.reload();
            alert("Kullan�c� Ba�ar� ile Silindi");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Kullan�c� Silinirken hata ile kar��la��ld�.");
        }
    });
}

function Update(id, name, surname, username, password) {
    $('#userid').val(id);
    $('#name').val(name) == name;
    $('#surname').val(surname) == surname;
    $('#username').val(username) == username;
    $('#password').val(password) == password;
}

//Kaydet Butonuna t�kland���nda �al��an function
function btnUpdateClick() {
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/User/Update",
            data: {
                userid: $('#userid').val(),
                name: $('#name').val(),
                surname: $('#surname').val(),
                username: $('#username').val(),
                password: $('#password').val()
            },
            success: function (res) {
                $('#updateUserModal').modal('toggle');
                datatable.ajax.reload();
                alert("Kullan�c� Ba�ar� ile G�ncellendi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kullan�c� G�ncellenirken hata ile kar��la��ld�.");
            }
        });
    }
}
//Kaydetmek i�in gerekli validasyon
function btnSaveClickValidation() {

    if ($('#name').val() == null) {
        alert("Ad alan� Bo� Olamaz.");
        return false;
    }
    else if ($('#surname').val() == null) {
        alert("Soyad alan� Bo� Olamaz.");
        return false;
    }
    else if ($('#username').val() == null) {
        alert("Kullan�c� Ad� alan� Bo� Olamaz.");
        return false;
    }
    else {
        return true;
    }
}