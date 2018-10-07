$(document).on("click", ".botao-editar-usuario", function () {

    $('#editarShow').show();
    $('#cadastrar').hide();
    var t = $(this).parents('.user-table');
    var idUser = $(t.children()[0]).text();
    console.log(idUser);
    //$.post("/Usuario/AlterarDadosUsuario", { id: id });
    var dados = { id: idUser };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Usuario/AlterarDadosUsuario',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            $('#id-editar').val(resultado.Id);
            $('#nome-editar').val(resultado.Nome);
            $('#email-editar').val(resultado.Email);
            $('#nivel-editar').val(resultado.NivelAcesso);
            if (resultado.Ativo) {
                $('#ativo-editar').val(0);
            }
            else {
                $('#ativo-editar').val(1);

            }


            
        },
        error: function (xml, status, error) {

        }
    })
});






//cliente



function editarClientePorId() {

    var t = $(this).parent().parent().parent();
    var idClient = $(t.children()[0]).text();
    var dados = { id: 2 };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Cliente/AlterarDadosCliente',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {

            $('#id-editar').val(resultado.id);
            $('#nome-editar').val(resultado.nome);
            $('sobrenome-editar').val(resultado.sobrenome);
            $('#pessoa-editar > option:select').val(resultado.pessoa);
            $('#sexo-editar > option:select').val(resultado.sexo);

        },
        error: function (xml, status, error) {

        }


    })
};









///// <reference path="../typings/jquery/jquery.d.ts" />


//    var pacientes = document.querySelectorAll(".user-table");

//    var tabela = document.querySelector("#tabela-completa");

//    tabela.addEventListener("dblclick", function (event) {
//        event.target.parentNode.classList.add("fadeOut");

//        setTimeout(function () {
//            event.target.parentNode.remove();
//        }, 500);

//    });
