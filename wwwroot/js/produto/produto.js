$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true
    });

    new $.fn.dataTable.FixedHeader(table);


    $("#criaProduto").click(function () {
        $.ajax({
            
        });
    });
});