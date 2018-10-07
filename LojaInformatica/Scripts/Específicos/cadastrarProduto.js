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

                alert('Cliente adicionado com sucesso.');
                //var marca = '';
                //if (resultado.marca == 0) {
                //    sexo = 'Razer';
                //} else if (resultado.sexo == 1) {
                //    sexo = 'HyperX';
                //} else {
                //    sexo = 'Erro';
                //}


                //outro form dentro do form
                var tr = '<tr>' +
                    '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
                    '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
                    '<td id="descricao' + resultado.id + '">' + resultado.descricao + '</td>' +
                    '<td id="quantidade' + resultado.id + '">' + resultado.quantidade + '</td>' +
                    '<td id="precoUnitario' + resultado.id + '">' + resultado.precoUnitario + '</td>' +
                    '<td id="marca' + resultado.id + '">' + resultado.marca + '</td>' +

                    '<td>' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-cliente " ' +
                    'id="btn-editar' + resultado.id + '"' + ' onclick = "editarClientePorId()" > ' +
                    '<i class="fa fa-pencil"></i> Editar/Visualizar' + '</a>' + '</div >' + '</td >' +
                    '<td>' + '<div class="actions">' + '<a class="btn btn-default btn-sm botao-remover-cliente" id="btn-remover' +
                    resultado.id + '">' + ' <i class="fa fa-pencil"></i> Remover' + '</a>' + '</div>' + '</td>' +
                    '</tr >';







                $('#tabela-clientes').prepend(tr);

                $('#nome-cliente').val('');
                $('#sobrenome-cliente').val('');
                $('#pessoa-cliente > option:selected').val('');
                $('#sexo-cliente > option:selected').val('');
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

