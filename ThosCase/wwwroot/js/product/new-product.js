$(document).ready(function () {
    getCategory();
});
//categoryList selectine verilerin yüklenmesi
function getCategory() {
    $.ajax({
        type: "GET",
        url: "/category/GetAllCategory",
        async: false,
        success: function (data) {
            if (data.length > 0) {
                var $categoryList = $("#categoryList");
                $categoryList.empty(); // Veriler Yükleniyor ibaresinin kaldýrýlmasý
                $categoryList.append($("<option value='0'>Lutfen Seciniz</option>"))
                $.each(data, function (index, element) {
                    $categoryList.append($("<option value=" + element.categoryid + ">" + element.categoryname + "</option>"))
                });
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Veriler getirilirken hata ile karþýlaþýldý.");
        }

    });
}
//Kaydet Butonuna týklandýðýnda çalýþan function
function btnSaveClick() {
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/Product/Save",
            data: {
                producname: $('#producname').val(),
                categoryid: $('#categoryList').find(":selected").val(),
                price: $('#price').val().replace('.',','),
                imagepath: $('#imagepath').val()
            },
            success: function (res) {
                alert("Kategori Baþarý ile Kaydedildi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kategori Kaydedilirken hata ile karþýlaþýldý.");
            }
        });
    }
}
//Kaydetmek için gerekli validasyon
function btnSaveClickValidation() {
    if ($('#producname').val() == null) {
        alert("Ürün Adý Boþ Olamaz.");
        return false;
    }
    else if ($('#categoryList').find(":selected").val() == null) {
        alert("Üst Kategori Boþ Olamaz.");
        return false;
    }
    else if ($('#price').val() == null || $('#price').val()==0) {
        alert("Fiyat Bilgisi boþ veya 0 olamaz");
        return false;
    }
    else if ($('#imagepath').val() == null) {
        alert("Resim Boþ Olamaz.");
        return false;
    }
    else {
        return true;
    }
}