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

    $(".remover").click(function () {
        swal({
            title: "Voçê tem certeza que deseja remover esse produto?",
            text: $(this).data('nome'),
            icon: "warning",
            buttons: true,
        }).then((botao) => {
            console.log(botao)
            if (botao) {
                $.ajax({
                    url: "/api/produto/" + $(this).data('id'),
                    method: "DELETE",
                }).done(function (data) {
                    swal({
                        title: "Produto!",
                        text: "Deletado com sucesso!",
                        icon: "success",
                        button: "Ok!",
                    }).then((data) => {
                        location.reload();
                    });

                }).fail(function (error) {
                    swal({
                        title: "Ocorreu um erro, Por favor tente novamente",
                        text: error,
                        icon: "error",
                        button: "Ok!",
                    });
                })
            }
        });

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
            swal({
                title: "Ocorreu um erro, Por favor tente novamente",
                text: error,
                icon: "error",
                button: "Ok!",
            });
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
                    title: "Produto " + data.nome + "!" ,
                    text: "Adicionado com sucesso!",
                    icon: "success",
                    button: "Ok!",
                }).then((data) => {
                    location.reload();
                });
            }).fail(function (error) {
                swal({
                    title: "Ocorreu um erro, Por favor tente novamente",
                    text: error,
                    icon: "error",
                    button: "Ok!",
                });
            }).always(function () {
                $('body').LoadingOverlay("hide");
            })
        });

    }
});