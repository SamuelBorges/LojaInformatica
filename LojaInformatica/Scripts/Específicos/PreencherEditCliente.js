$('.botao-editar-cliente').click(function () {
    var t = $(this).parents('.client-table');
    var idUser = $(t.children()[0]).text();
    console.log(idUser);
    //$.post("/Usuario/AlterarDadosUsuario", { id: id });
    var dados = { id: idUser };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Cliente/AlterarDadosCliente',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            $('#id-editar').val(resultado.Id);
            $('#nome-editar').val(resultado.Nome);
            $('#email-editar').val(resultado.Email);
           // $('#nivel-editar').val(resultado.NivelAcesso);
$("#nivel-editar").val();
            $('#nome-editar').val(resultado.Nome);

        },
        error: function (xml, status, error) {

        }
    })
});
