/// <reference path="typings/jquery/jquery.d.ts" />
$('#ver-mais').click(function () {
  
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Usuario/ListarUsuarios',
        contentType: 'application/json; charset=utf-8',
       
        success: function (resultado) {
            if (resultado.sucesso) {
                //foi cadastrado e precisa inserir na tabela

                var ativo = resultado.ativo === true ? 'Ativo' : 'Inativo';

                var nivelAc = resultado.nivel == 0 ? 'Administrador' : 'Funcionário';
                var tr = '<tr>' +
                    '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
                    '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
                    '<td id="email' + resultado.id + '">' + resultado.email + '</td>' +
                    '<td id="estado' + resultado.id + '">' + ativo + '</td>' +
                    '<td id="nivelAcesso' + resultado.id + '">' + nivelAc + '</td>' +
                    '</tr >';

                $('#tabela-usuarios').prepend(tr);
            } else {
                //nao foi validado corretamente
            }
        },
        error: function (xml, status, error) {

        }


    })
});