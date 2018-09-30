$(".botao-editar-cliente").click(visualizarItemPorId);

function visualizarItemPorId() {
    var t = $(this).parent().parent().parent();
    var idUser = $(t.children()[0]).text();
    console.log(idUser);
    //  $.post("/Usuario/AlterarDadosUsuario", { id: id });
    var dados = { id: idUser };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Usuario/AlterarDadosCliente',
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
