/// <reference path="../typings/jquery/jquery.d.ts" />

$('#edit-user').click(function () {
    var id = $('#id-editar').val();
    var nomeUser = $('#nome-editar').val();
    var enderecoEmail = $('#email-editar').val();
    var senhaUser = $('#senha-editar').val();
    var nivelAcesso = $('#nivel-editar > option:selected').val();
    var dados = {
        Id:id,  Nome: nomeUser, Email: enderecoEmail, Senha: senhaUser, NivelAcesso: nivelAcesso
    };

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Usuario/AtualizarUsuario' ,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {
                //foi atualizado
                
                var texto = $('nome'+resultado.id).text(resultado.Nome);

               
            } else {
                //nao foi validado corretamente
            }
        },
        error: function (xml, status, error) {

        }


    })
});