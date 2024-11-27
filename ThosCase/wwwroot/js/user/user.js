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
                { "data": "username", "title": "Kullanýcý Adý", "autoWidth": true },
                { "data": "hashpassword", "name": "Hash Þifre", "autoWidth": true }
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
            alert("Kullanýcý Baþarý ile Silindi");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Kullanýcý Silinirken hata ile karþýlaþýldý.");
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

//Kaydet Butonuna týklandýðýnda çalýþan function
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
                alert("Kullanýcý Baþarý ile Güncellendi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kullanýcý Güncellenirken hata ile karþýlaþýldý.");
            }
        });
    }
}
//Kaydetmek için gerekli validasyon
function btnSaveClickValidation() {

    if ($('#name').val() == null) {
        alert("Ad alaný Boþ Olamaz.");
        return false;
    }
    else if ($('#surname').val() == null) {
        alert("Soyad alaný Boþ Olamaz.");
        return false;
    }
    else if ($('#username').val() == null) {
        alert("Kullanýcý Adý alaný Boþ Olamaz.");
        return false;
    }
    else {
        return true;
    }
}