/// <reference path="../typings/jquery/jquery.d.ts" />


$(document).on("click", ".botao-deletar-servico", function () {
    var t = $(this).parents('.product-table');
    var produtoNome = $(t.children()[2]).text().trim();
    var remove = confirm('Você tem certeza que deseja remover o produto do sistema?');
    
    if (remove == true) {
        t.remove();
        var idClient = $(t.children()[0]).text();
        console.log(idClient);
        var dados = { id: idClient };
        $.ajax({


            type: 'POST',
            dataType: 'json',
            url: '/OrdemServico/DeletarPedido',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(dados),
            success: function (resultado) {

                var t = $(this).parents('.client-table');
                t.remove();
                alert(' Produto removido com sucesso.');
                $('#editarShow').hide();
                location.reload();

            },
            error: function (xml, status, error) {
                alert("Fora de estoque.");


            }
        })
    } else {
        alert('Remoção cancelada');
    }
});
