var datatable = "";
$(document).ready(function () {
    bindDatatable();
});
function bindDatatable() {
    datatable = $('#product-datatables')
        .DataTable({
            "sAjaxSource": "/Product/Get",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "url": 'https://cdn.datatables.net/plug-ins/2.1.8/i18n/tr.json'
            },
            "columns": [
                {
                    "data":'productid',
                    "render": function (data, type, full, meta) {
                        var content = "";
                        content += '<a class="btn btn-info" data-bs-toggle="modal" onclick=Update(' + data + ',"' + full.producname + '","' + full.categoryid + '","' + full.price + '","' + full.imagepath + '"); data-bs-id=' + data + ' data-bs-target="#updateProductModal">Düzenle</a>';
                        content += "<a href='#' class='btn btn-danger'  onclick=Delete('" + data + "'); >Sil</a>";
                        return content;
                    }
                },
                { "data": "productid", "name": "Ürün Id", "autoWidth": true },
                { "data": "producname", "name": "Ürün Adı", "autoWidth": true },
                { "data": "categoryid", "title": "Kategori İd", "autoWidth": true },
                { "data": "price", "title": "Fiyat", "autoWidth": true },
                {
                    "data": "imagepath",
                    "title": "Resim",
                    "autoWidth": true,
                    "render": function (data, type, full, meta) {
                        var content = "";
                        content += "<img class='category-icon' width='60' id='catImg2' src='" + data +"'>";
                        return content;
                    }
                },
                { "data": "createddate", "name": "Oluşturma Tarihi", "autoWidth": true },
                { "data": "creatoruserid", "name": "Oluşturan Kullanıcı Id", "autoWidth": true },

            ]
        });
}
function Delete(id) {
    $.ajax({
        type: "POST",
        async: true,
        url: "/Product/Delete",
        data: {
            id: id
        },
        success: function (res) {
            datatable.ajax.reload();
            alert("Ürün Başarı ile Silindi");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ürün Silinirken hata ile karşılaşıldı.");
        }
    });
}

function Update(id, producname, categoryid, price, imagepath) {
    getCategory();
    $('#productId').val(id);
    $('#producname').val(producname) == producname;
    $('#categoryList').val(categoryid);
    $('#price').val(price) == price;
    $('#imagepath').val(imagepath) == imagepath;
    
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
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/Product/Update",
            data: {
                productid: $('#productId').val(),
                producname: $('#producname').val(),
                categoryid: $('#categoryList').find(":selected").val(),
                price: $('#price').val().replace('.', ','),
                imagepath: $('#imagepath').val()
            },
            success: function (res) {
                $('#updateProductModal').modal('toggle');
                datatable.ajax.reload();
                alert("Ürün Başarı ile Güncellendi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Ürün Güncellenirken hata ile karşılaşıldı.");
            }
        });
    }
}
//Kaydetmek için gerekli validasyon
function btnSaveClickValidation() {
    if ($('#producname').val() == null) {
        alert("Ürün Adı Boş Olamaz.");
        return false;
    }
    else if ($('#categoryList').find(":selected").val() == null) {
        alert("Üst Kategori Boş Olamaz.");
        return false;
    }
    else if ($('#price').val() == null || $('#price').val() == 0) {
        alert("Fiyat Bilgisi boş veya 0 olamaz");
        return false;
    }
    else if ($('#imagepath').val() == null) {
        alert("Resim Boş Olamaz.");
        return false;
    }
    else {
        return true;
    }
}