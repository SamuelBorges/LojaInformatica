/// <reference path="../typings/jquery/jquery.d.ts" />

$(document).on("click", "#cadastrar-produto" ,function () {
    var nomeProduct = $('#nome-produto').val();
    var descricao = $('#descricao-produto').val();
    var precoUnitario = $('#preco-unitario').val();
    var quantidade = $('#quantidade-produto').val();
    var marca = $('#marca > option:selected').val();
    var dados = {
        Nome: nomeProduct, Descricao: descricao, PrecoUnitario: precoUnitario, Quantidade: quantidade
    };  
    $.ajax({
      
        type: 'POST',
        dataType: 'json',
        url: '/Produto/CadastrarProduto',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {

                alert('Produto adicionado com sucesso.');


                location.reload();




                
                //esconder tem   fazer
                //var display = document.getElementById(cadastrarCliente).style.display;
                //if (display == "none")
                //    document.getElementById('cadastrar').style.display = 'block';
                //else
                //    document.getElementById(cadastrarUser).style.display = 'none';

            } else {
                var mensagem = resultado.message
                alert(mensagem);

            }
        },
        error: function (xml, status, error) {

        }




    })
});

