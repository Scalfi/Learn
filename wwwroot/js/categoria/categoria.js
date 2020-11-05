$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true
    });

    new $.fn.dataTable.FixedHeader(table);


    $("#criaCategoria").click(function () {
        chamaModal(0);
    });

    $(".editar").click(function () {
        chamaModal($(this).data('id'));
    });

    $(".remover").click(function () {
        swal({
            title: "Voçê tem certeza que deseja remover esse categoria?",
            text: $(this).data('nome'),
            icon: "warning",
            buttons: true,
        }).then((botao) => {
            if (botao) {
                $.ajax({
                    url: "/api/categoria/" + $(this).data('id'),
                    method: "DELETE",
                }).done(function (data) {
                    swal({
                        title: "Categoria!",
                        text: "Deletada com sucesso!",
                        icon: "success",
                        button: "Ok!",
                    }).then((data) => {
                        location.reload();
                    });

                }).fail(function (error) {
                    swal({
                        title: "Ocorreu um erro interno, Por favor tente novamente",
                        text: error.responseText,
                        icon: "error",
                        button: "Ok!",
                    });
                })
            }
        });

    });
    function chamaModal(id) {
        $.ajax({
            url: "/categoria/"+id,
            method: "GET",
            dataType: "html"
        }).done(function (data) {

            $("#htmlModal").html(data);
            $("#modalCategoriaForm").modal("show");
            submitcategoria();

        }).fail(function (error) {
            swal({
                title: "Ocorreu um erro, Por favor tente novamente",
                text: error,
                icon: "error",
                button: "Ok!",
            });
        })
    }

    function submitcategoria() {

        $("form").on("click", ".enviaCategoria", function () {
            $('body').LoadingOverlay("show");

            $.ajax({
                url: $("#formCategoria").attr('action'),
                method: $("#formCategoria").attr('method'),
                dataType: "json",
                data: $("#formCategoria").serialize()
            }).done(function (data) {
                swal({
                    title: "Categoria "+ data.nome + "!" ,
                    text: "Adicionado com sucesso!",
                    icon: "success",
                    button: "Ok!",
                }).then((data) => {
                    location.reload();
                });
            }).fail(function (error) {
                swal({
                    title: "Ocorreu um error, Por favor tente novamente",
                    text: error.responseText,
                    icon: "error",
                    button: "Ok!",
                });
            }).always(function () {
                $('body').LoadingOverlay("hide");
            })
        });

    }
});