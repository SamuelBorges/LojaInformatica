/// <reference path="../typings/jquery/jquery.d.ts" />


$('.botao-deletar-cliente').click(function () {

    var t = $(this).parents('.client-table');
    t.remove();
    var idClient = $(t.children()[0]).text();
    console.log(idClient);
    var dados = { id: idClient };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Cliente/RemoverCliente',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {

            var t = $(this).parents('.client-table');

            t.remove();


        },
        error: function (xml, status, error) {
            alert('Erro inesperado, tente novamente.');

        }
    })
});
