function Login() {
    var userName = $('#Correo').val();
    var pass = $('#contra').val();

    $.ajax({
        url: "/api/AccountService",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        data: JSON.stringify({ Email: userName, Password: pass }),
        success: function (result) {
            window.alert("Login");
            if (result.Url) {
                window.location.href = result.Url;
            }
        },
        error: function (request, textStatus, errorThrown) {
            window.alert("El usuario o la contraseña no son validos");
        }
    });
}

$(document).ready(function () {
    $("#Ingresar").click(function () {
        Login();
    });
});