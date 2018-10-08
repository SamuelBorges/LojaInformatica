/// <reference path="../typings/jquery/jquery.d.ts" />

$(document).on("click", "#cadastrar-servico", function () {
    var dataService = $('#data-servico').val();
    var produtoService = $('#nome-produto  option:selected').val();
    var clienteService = $('#cliente-selecionado  option:selected').val();
    var quantidadeService = $('#quantidade').val();
    var observacaoService = $('#observacao').val();
    //get date
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //Janeiro!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    today = dd + '/' + mm + '/' + yyyy;
    //TERMINOU DATE

    var dados = {
        DataDoPedido: today, clienteId: clienteService, produtoId: produtoService, Quantidade: quantidadeService,
        Observacao: observacaoService
    };

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/OrdemServico/CadastrarPedido',//
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {
                alert('Pedido adicionado com sucesso.');
                location.reload();



            }
        },
        error: function (xml, status, error) {

        }


    })
});

