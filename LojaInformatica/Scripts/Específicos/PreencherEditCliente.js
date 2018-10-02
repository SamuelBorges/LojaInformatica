/// <reference path="../typings/jquery/jquery.d.ts" />


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
            $('#id-editar').val(resultado.id);
            $('#nome-editar').val(resultado.nome);
            $('#sobrenome-editar').val(resultado.sobrenome);
            $('#sexo-editar').val(resultado.sexo);
            $('#pessoa-editar').val(resultado.pessoa);
            //if (resultado.Sexo == 0) {
            //    $('#sexo-editar > option:selected').text('Masculino');
            //} else if (resultado.Sexo == 1) {
            //    $('#sexo-editar > option:selected').text('Indeterminado');
            //} else {
            //    $('#sexo-editar > option:selected').text('Feminino');

            //}
            //if (resultado.Pessoa == 0) {
            //    $('#pessoa-editar > option:selected').text('Física');
            //} else {
            //    $('#pessoa-editar > option:selected').text('Jurídica');
            //} 
        },
        error: function (xml, status, error) {
            alert('Erro inesperado, tente novamente.');
        }
    })
});
