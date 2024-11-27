//Kaydet Butonuna t�kland���nda �al��an function
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
                alert("Kullan�c� Ba�ar� ile Kaydedildi");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Kullan�c� Kaydedilirken hata ile kar��la��ld�.");
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