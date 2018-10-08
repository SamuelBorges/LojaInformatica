/// <reference path="../typings/jquery/jquery.d.ts" />


$(document).on("click", ".botao-deletar-produto", function () {
    var t = $(this).parents('.product-table');
    var ProdutoNome = $(t.children()[1]).text().trim();
    var remove = confirm('Você tem certeza que deseja remover ' + ProdutoNome + ' do sistema?');

    if (remove == true) {
        t.remove();
        var idClient = $(t.children()[0]).text();
        console.log(idClient);
        var dados = { id: idClient };
        $.ajax({


            type: 'POST',
            dataType: 'json',
            url: '/Produto/RemoverProduto',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(dados),
            success: function (resultado) {

                var t = $(this).parents('.product-table');
                t.remove();
                alert(clienteNome + ' ' + clienteSobrenome + ' removido com sucesso.');
                $('#editarShow').hide();


            },
            error: function (xml, status, error) {
                alert('Erro inesperado, tente novamente.');

            }
        })
    } else {
        alert('Remoção cancelada');
    }
});
