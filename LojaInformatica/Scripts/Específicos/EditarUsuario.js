/// <reference path="../typings/jquery/jquery.d.ts" />

$('#edit-user').click(function () {
    var id = $('#id-editar').val();
    var nomeUser = $('#nome-editar').val();
    var enderecoEmail = $('#email-editar').val();
    var senhaUser = $('#senha-editar').val();
    var nivelAcesso = $('#nivel-editar > option:selected').val();
    var dados = {
        Nome: nomeUser, Email: enderecoEmail, Senha: senhaUser, NivelAcesso: nivelAcesso, Id: id
    };
    

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Usuario/AtualizarUsuario' ,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            console.log(resultado);
            if (resultado.sucesso) {

                $('#nome' + resultado.id).text(resultado.nome);

                $('#email' + resultado.id).text(resultado.email);
                if (resultado.ativo) {
                    $('#estado' + resultado.id).text('Ativo');
                } else {
                    $('#estado' + resultado.id).text('Inativo');
                }
                if (resultado.nivel==0) {
                    $('#nivelAcesso' + resultado.id).text('Administrador');
                } else {
                    $('#nivelAcesso' + resultado.id).text('Funcionario');
                }
                $('#senha-editar').val('');
                alert('Login atualizado com sucesso.');
                
             

             
            } else {
                alert(resultado.message);
            }
        },
        error: function (xml, status, error) {

        }


    })
});








//function atualizarItemPorId() {
//    var t = $(this).parent().parent().parent();
//    var idUser = $(t.children()[0]).text();
//    var idUsuario = $('#id-editar').val();
//    console.log(idUsuario);
//    //  $.post("/Usuario/AlterarDadosUsuario", { id: id });
//    var dados = { id: idUser };
//    $.ajax({
//        type: 'POST',
//        dataType: 'json',
//        url: '/Usuario/AlterarDadosUsuario',
//        contentType: 'application/json; charset=utf-8',
//        data: JSON.stringify(dados),
//        success: function (resultado) {
//            $('#id-editar').val(resultado.Id);
//            $('#nome-editar').val(resultado.Nome);
//            $('#email-editar').val(resultado.Email);
//            $('#nivel-editar > option:select').val(resultado.NivelAcesso);
//            $('#nome-editar').val(resultado.Nome);

//        },
//        error: function (xml, status, error) {

//        }


//    })
//};
