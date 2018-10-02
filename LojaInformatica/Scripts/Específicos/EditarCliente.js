/// <reference path="../typings/jquery/jquery.d.ts" />

$('#edit-client').click(function () {
    var id = $('#id-editar').val();
    var nomeClient = $('#nome-editar').val();
    var sobrenomeClient = $('#sobrenome-editar').val();
    var sexoClient = $('#sexo-editar').val();
    var pessoaClient = ('#pessoa-editar').val();
    var dados = {
        Nome: nomeClient, Sobrenome: sobrenomeClient, Sexo: sexoClient, Pessoa: pessoaClient, Id: id
    };


    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Cliente/AtualizarCliente',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            console.log(resultado);
            if (resultado.sucesso) {

                $('#nome' + resultado.id).text(resultado.nome);

                $('#sobrenome' + resultado.id).text(resultado.sobrenome);
                if (resultado.Sexo == 0) {
                    $('#sexo' + resultado.id).text('Masculino');
                } else {
                    $('#sexo' + resultado.id).text('Feminino');
                }
                if (resultado.Pessoa == 0) {
                    $('#pessoa' + resultado.id).text('Física');
                } else {
                    $('#pessoa' + resultado.id).text('Jurídica');
                }
                alert('Login atualizado com sucesso.');




            } else {
                alert(resultado.message);
            }
        },
        error: function (xml, status, error) {

        }


    })
});

