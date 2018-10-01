/// <reference path="../typings/jquery/jquery.d.ts" />

$('#edit-user').click(function () {
    var id = $('#id-editar').val();
    var nomeClient = $('#nome-editar').val();
    var sobrenomeClient = $('#sobrenome-editar').val();
    var pessoaClient = $('#pessoa-editar > option:selected').val();
    var sexoClient = $('#sexo-editar > option:selected').val();
    var dados = {
        Nome: nomeClient, Sobrenome: sobrenomeClient, Pessoa: pessoaClient, Sexo: sexoClient, Id: id
    };


    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Cliente/AlterarDadosCliente',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {

                var nomeUser = $('#cliente-editar').val();
                nomeUser = resultado.Nome;

                var email = $('#cliente' + resultado.id).text(resultado.Email);
                alert(resultado.message);


            } else {
                alert(resultado.message);
            }
        },
        error: function (xml, status, error) {

        }


    })
});
