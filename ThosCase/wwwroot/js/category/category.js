var datatable = "";
$(document).ready(function () {
    bindDatatable();
});
function bindDatatable() {
    datatable = $('#category-datatables')
        .DataTable({
            "sAjaxSource": "/Category/Get",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "url": 'https://cdn.datatables.net/plug-ins/2.1.8/i18n/tr.json'
            },
            "columns": [
                {
                    "data":'categoryid',
                    "render": function (data, type, full, meta) {
                        var content = "";
                        content += '<a class="btn btn-info" data-bs-toggle="modal" onclick=Update(' + data + ',"' + full.categoryname +'","'+full.parentcategoryid+'"); data-bs-id=' + data + ' data-bs-target="#updateCategoryModal">Düzenle</a>';
                        content += "<a href='#' class='btn btn-danger'  onclick=Delete('" + data + "'); >Sil</a>";
                        return content;
                    }
                },
                { "data": "categoryid", "name": "Kategori Id", "autoWidth": true },
                { "data": "categoryname", "name": "Kategori Adı", "autoWidth": true },
                { "data": "parentcategoryid", "title": "Üst Kategori İd", "autoWidth": true },
                { "data": "createddate", "name": "Oluşturma Tarihi", "autoWidth": true },
                { "data": "creatoruserid", "name": "Oluşturan Kullanıcı Id", "autoWidth": true },

            ]
        });
}
function Delete(id) {
    $.ajax({
        type: "POST",
        async: true,
        url: "/category/Delete",
        data: {
            id: id
        },
        success: function (res) {
            datatable.ajax.reload();
            alert("Kategori Başarı ile Silindi");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Kategori Silinirken hata ile karşılaşıldı.");
        }
    });
}

function Update(id, categoryname, parentid) {
    getCategory();
    $('#categoryId').val(id);
    $('#categoryName').val(categoryname) == categoryname;
    $('#categoryList').val(parentid);
    
}

//categoryList selectine verilerin yüklenmesi
function getCategory() {
    $.ajax({
        type: "GET",
        url: "/category/GetAllCategory",
        async: false,
        success: function (data) {
            if (data.length > 0) {
                var $categoryList = $("#categoryList");
                $categoryList.empty(); // Veriler Yükleniyor ibaresinin kaldırılması
                $categoryList.append($("<option value='0'>Ust Kategori Yok</option>"))
                $.each(data, function (index, element) {
                    $categoryList.append($("<option value=" + element.categoryid + ">" + element.categoryname + "</option>"))
                });
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Veriler getirilirken hata ile karşılaşıldı.");
        }

    });
}
//Kaydet Butonuna tıklandığında çalışan function
function btnUpdateClick() {
    console.log("test");
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/category/Update",
            data: {
                categoryid: $('#categoryId').val(),
                categoryname: $('#categoryName').val(),
                parentcategoryid: $('#categoryList').find(":selected").val()
            },
            success: function (res) {
                $('#updateCategoryModal').modal('toggle');
                datatable.ajax.reload();
                alert("Kategori Başarı ile Güncellendi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kategori Güncellenirken hata ile karşılaşıldı.");
            }
        });
    }
}
//Kaydetmek için gerekli validasyon
function btnSaveClickValidation() {

    if ($('#categoryName').val() == null) {
        alert("Kategori Adı Boş Olamaz.");
        return false;
    }
    else if ($('#categoryList').find(":selected").val() == null) {
        alert("Üst Kategori Boş Olamaz.");
        return false;
    }
    else {
        return true;
    }
}