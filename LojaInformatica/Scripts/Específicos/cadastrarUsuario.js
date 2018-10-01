/// <reference path="../typings/jquery/jquery.d.ts" />

$('#cadastrar-usuario').click(function () {
    var nomeUser = $('#nome-usuario').val();
    var enderecoEmail = $('#endereco-email').val();
    var senhaUser = $('#senha').val();
    var nivelAcesso = $('#nivel-acesso > option:selected').val();
    var dados = {
        Nome: nomeUser, Email: enderecoEmail, Senha: senhaUser, NivelAcesso: nivelAcesso
    };

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Usuario/CadastrarUsuario',//
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
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
                    '<td>' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-usuario " ' +
                    'id="btn-editar' + resultado.id + '"'+ ' onclick = "editarItemPorId()" > ' +
                    '<i class="fa fa-pencil"></i> Editar' + '</a>' + '</div >' + '</td >'+
                    '</tr >';

                $('#tabela-usuarios').prepend(tr);
                alert('Usuário adicionado com sucesso.');

                $('#nome-usuario').val('');
                $('#endereco-email').val('');
                $('#senha').val('');
                $('#nivel-acesso > option:selected').val('');
                //esconder tem   fazer
                var display = document.getElementById(cadastrarUser).style.display;
                if (display == "none")
                    document.getElementById('cadastrar').style.display = 'block';
                else
                    document.getElementById(cadastrarUser).style.display = 'none';


            } else {
                var mensagem = resultado.message
                alert(mensagem);

            }
        },
        error: function (xml, status, error) {

        }


    })
});

