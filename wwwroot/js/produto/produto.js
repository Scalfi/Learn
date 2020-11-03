$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true
    });

    new $.fn.dataTable.FixedHeader(table);


    $("#criaProduto").click(function () {
        console.log("oi")
        $.ajax({
            url: "/Produto/0",
            method: "GET",
            dataType: "html"
        }).done(function (data) {
            $("#htmlModal").html(data);
            $("#modalProdutoForm").modal("show");
        }).fail(function (error) {
            console.log(error)
            alert("Data Saved: " + error);
        })
    });
});