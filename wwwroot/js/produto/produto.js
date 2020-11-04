﻿$(document).ready(function () {
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
            $('body').LoadingOverlay("show");

            $.ajax({
                url: "/api/produto",
                method: "post",
                dataType: "json",
                data: $("#formProduto").serialize()
            }).done(function (data) {
                swal({
                    title: "Produto "+ data.Nome + "!" ,
                    text: "Adicionado com sucesso!",
                    icon: "success",
                    button: "Ok!",
                });
            }).fail(function (error) {
                swal({
                    title: "Não foi possivel adicionar o produto",
                    text: error.errors,
                    icon: "error",
                    button: "Ok!",
                });
            }).always(function () {
                $('body').LoadingOverlay("hide");
            })
        });

    }
});