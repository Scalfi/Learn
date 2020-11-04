$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true
    });

    new $.fn.dataTable.FixedHeader(table);


    $("#criaProduto").click(function () {
        chamaModal(0);
    });
    $(".editar").click(function () {
        chamaModal($(this).data('id'));
    });
    function chamaModal(id) {
        $.ajax({
            url: "/Produto/"+id,
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
    }

    function submitProduto() {

        $("form").on("click", ".enviaProduto", function () {
            $('body').LoadingOverlay("show");

            $.ajax({
                url: $("#formProduto").attr('action'),
                method: $("#formProduto").attr('method'),
                dataType: "json",
                data: $("#formProduto").serialize()
            }).done(function (data) {
                swal({
                    title: "Produto "+ data.Nome + "!" ,
                    text: "Adicionado com sucesso!",
                    icon: "success",
                    button: "Ok!",
                }).then((data) => {
                    location.reload();
                });
            }).fail(function (error) {
                swal({
                    title: "Ocorreu Um erro interno",
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