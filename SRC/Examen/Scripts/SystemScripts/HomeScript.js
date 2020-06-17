function GetProducts() {
    $.ajax({
        url: "/api/ProductService",
        dataType: 'json',
        type: 'GET',
        success: function (result) {
            $("#listProducts").html("");
            for (var i = 0; i < result.length; i++) {
                var tr = '<tr><td>' + result[i].Id +
                    '</td><td>' + result[i].Description +
                    '</td><td> $' + result[i].Price +
                    '</td><td>' + result[i].Existence +
                    '</td></tr>';
                $("#listProducts").append(tr);
            }
        },
        error: function (request, textStatus, errorThrown) {
            window.alert("Ocurrio un error al obtener los productos de la base de datos");
        }
    });
}

$(document).ready(function () {
    GetProducts();
});