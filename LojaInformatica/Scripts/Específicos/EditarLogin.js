$(".botao-editar-usuario").click(editarItemPorId);

function editarItemPorId() {
    var t = $(this).parent().parent().parent();
    var idUser = $(t.children()[0]).text();
    console.log(idUser);
    //  $.post("/Usuario/AlterarDadosUsuario", { id: id });
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
            $('#nivel-editar > option:select').val(resultado.NivelAcesso);
            $('#nome-editar').val(resultado.Nome);
            
        },
        error: function (xml, status, error) {

        }


    })
};





/// <reference path="../typings/jquery/jquery.d.ts" />


    //var pacientes = document.querySelectorAll(".user-table");

    //var tabela = document.querySelector("#tabela-completa");

    //tabela.addEventListener("dblclick", function (event) {
    //    event.target.parentNode.classList.add("fadeOut");

    //    setTimeout(function () {
    //        event.target.parentNode.remove();
    //    }, 500);

    //});
