$(document).ready(function () {
    getCategory();
});
//categoryList selectine verilerin y�klenmesi
function getCategory() {
    $.ajax({
        type: "GET",
        url: "/category/GetAllCategory",
        async: false,
        success: function (data) {
            if (data.length > 0) {
                var $categoryList = $("#categoryList");
                $categoryList.empty(); // Veriler Y�kleniyor ibaresinin kald�r�lmas�
                $categoryList.append($("<option value='0'>Ust Kategori Yok</option>"))
                $.each(data, function (index, element) {
                    $categoryList.append($("<option value=" + element.categoryid + ">" + element.categoryname + "</option>"))
                });
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Veriler getirilirken hata ile kar��la��ld�.");
        }

    });
}
//Kaydet Butonuna t�kland���nda �al��an function
function btnSaveClick() {
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/category/Save",
            data: {
                categoryname: $('#categoryName').val(),
                parentcategoryid: $('#categoryList').find(":selected").val()
            },
            success: function (res) {
                alert("Kategori Ba�ar� ile Kaydedildi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kategori Kaydedilirken hata ile kar��la��ld�.");
            }
        });
    }
}
//Kaydetmek i�in gerekli validasyon
function btnSaveClickValidation() {

    if ($('#categoryName').val()==null) {
        alert("Kategori Ad� Bo� Olamaz.");
        return false;
    }
    else if ($('#categoryList').find(":selected").val() == null) {
        alert("�st Kategori Bo� Olamaz.");
        return false;
    }
    else {
        return true;
    }
}