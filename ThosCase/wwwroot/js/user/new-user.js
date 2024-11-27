//Kaydet Butonuna týklandýðýnda çalýþan function
function btnSaveClick() {
    if (btnSaveClickValidation()) {
        $.ajax({
            type: "POST",
            async: false,
            url: "/User/Save",
            data: {
                name: $('#name').val(),
                surname: $('#surname').val(),
                username: $('#username').val(),
                password: $('#password').val()
            },
            success: function (res) {
                alert("Kullanýcý Baþarý ile Kaydedildi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kullanýcý Kaydedilirken hata ile karþýlaþýldý.");
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