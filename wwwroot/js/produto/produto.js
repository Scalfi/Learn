$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true
    });

    new $.fn.dataTable.FixedHeader(table);


    $("#criaProduto").click(function () {
        $.ajax({
            url: "/Produto/0",
            method: "GET",
            dataType: "html"
        }).done(function (data) {

            $("#htmlModal").html(data);
            $("#valor").maskMoney();
            $("#modalProdutoForm").modal("show");
            submitProduto();

        }).fail(function (error) {
            console.log(error)
            alert("Data Saved: " + error);
        })
    });

    function submitProduto() {
        $("form").on("click", ".enviaProduto", function () {
            $.ajax({
                url: "/api/produto",
                method: "post",
                dataType: "json",
                data: $("#formProduto").serialize()
            }).done(function (data) {

            }).fail(function (error) {
                console.log(error)
                alert("Data Saved: " + error);
            })
        });
    }
});