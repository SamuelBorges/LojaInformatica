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
            if (resultado.sucesso) {

                var nomeUser = $('#nome-editar').val();
                nomeUser = resultado.Nome;

                var email = $('#email' + resultado.id).text(resultado.Email);
                alert(resultado.message);

             
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
