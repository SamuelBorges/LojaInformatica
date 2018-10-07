/// <reference path="../typings/jquery/jquery.d.ts" />


$('.botao-editar-produto').click(function () {


        $('#editarShow').show();
    $('#cadastrar').hide();


    var t = $(this).parents('.product-table');

    var idProduct = $(t.children()[0]).text();
    console.log(idProduct);

    var dados = { id: idProduct };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Produto/AlterarDadosProduto',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            $('#id-editar').val(resultado.id);
            $('#nome-editar').val(resultado.nome);
            $('#descricao-editar').val(resultado.descricao);
            $('#precoUnitario-editar').val(resultado.precoUnitario);
            $('#marca-editar').val(resultado.marca);
           
        },
        error: function (xml, status, error) {
            alert('Erro inesperado, tente novamente.');

        }
    })
});
