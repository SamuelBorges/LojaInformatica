/// <reference path="../typings/jquery/jquery.d.ts" />

$('#cadastrar-cliente').click(function () {
    var nomeClient = $('#nome-cliente').val();
    var sobrenome = $('#sobrenome-cliente').val();
    var pessoa = $('#pessoa > option:selected').val();
    var sexo = $('#sexo > option:selected').val();
    var dados = {
        Nome: nomeClient, Sobrenome: sobrenome, Pessoa: pessoa, Sexo: sexo
    };

    $.ajax({

        type: 'POST',
        dataType: 'json',
        url: '/Cliente/CadastrarCliente',//
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dados),
        success: function (resultado) {
            if (resultado.sucesso) {

                alert('Cliente adicionado com sucesso.');
                var sexo = '';
                if (resultado.sexo==0) {
                    sexo = 'Masculino';
                } else if (resultado.sexo==1) {
                    sexo = 'Feminino';
                } else {
                    sexo = 'Indeterminado';
                }
                var pessoa = resultado.pessoa == 0 ? 'Física' : 'Jurídica';
                var tr = '<tr>' +
                    '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
                    '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
                    '<td id="sobrenome' + resultado.id + '">' + resultado.sobrenome + '</td>' +
                    '<td id="pessoa' + resultado.id + '">' + pessoa + '</td>' +
                    '<td id="sexo' + resultado.sexo + '">' + sexo + '</td>' +
                    '<td>' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-cliente " ' +
                    'id="btn-editar' + resultado.id + '"' + ' onclick = "editarClientePorId()" > ' +
                    '<i class="fa fa-pencil"></i> Editar/Visualizar' + '</a>' + '</div >' + '</td >' +
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

