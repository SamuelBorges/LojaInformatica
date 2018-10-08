/// <reference path="../typings/jquery/jquery.d.ts" />
$(document).on("click", "#edit-product", function () {
    var id = $('#id-editar').val();
    var nomeProduct = $('#nome-editar').val();
    var descricaoProduct = $('#descricao-editar').val();
    var quantidadeProduct = $('#quantidade-editar').val();
    var valorProduct = $('#valor-editar').val();


    var dados = {
        Nome: nomeProduct, Descricao: descricaoProduct, Quantidade: quantidadeProduct, PrecoUnitario: valorProduct, Id: id
    };
    console.log(id);
    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Produto/AtualizarProduto',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            console.log(resultado);
            if (resultado.sucesso) {

                $('#nome' + resultado.id).text(resultado.nome);

                $('#descricao' + resultado.id).text(resultado.descricao);

                $('#quantidade' + resultado.id).text(resultado.quantidade);

                $('#preco-unitario' + resultado.id).text(resultado.precoUnitario);

                $('#editarShow').hide();

                alert('Login atualizado com sucesso.');




            } else {
                alert(resultado.message);
            }
        },
        error: function (xml, status, error) {

        }


    })
});


