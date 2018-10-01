/// <reference path="../typings/jquery/jquery.d.ts" />

$('#cadastrar-cliente').click(function () {
    var nomeUser = $('#nome-cliente').val();
    var sobrenome = $('#sobrenome-cliente').val();
    var pessoa = $('#pessoa > option:selected').val();
    var sexo = $('#sexo > option:selected').val();
    var dados = {
        Nome: nomeUser, Sobrenome: sobrenome, Pessoa : pessoa, Sexo: sexo
    };

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Cliente/CadastrarCliente',//
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {
                //foi cadastrado e precisa inserir na tabela
                alert('Cliente adicionado com sucesso.');


            } else {
                var mensagem = resultado.message
                alert(mensagem);

            }
        },
        error: function (xml, status, error) {

        }


    })
});

