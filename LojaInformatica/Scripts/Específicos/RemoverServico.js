/// <reference path="../typings/jquery/jquery.d.ts" />


$(document).on("click", ".botao-deletar-cliente",function () {
    var t = $(this).parents('.client-table');
    var clienteNome = $(t.children()[1]).text().trim();
    var clienteSobrenome = $(t.children()[2]).text().trim();
    var remove = confirm('Você tem certeza que deseja remover ' + clienteNome + ' ' + clienteSobrenome+' do sistema?');
    
    if (remove == true) {
        t.remove();
        var idClient = $(t.children()[0]).text();
        console.log(idClient);
        var dados = { id: idClient };
        $.ajax({


            type: 'POST',
            dataType: 'json',
            url: '/Cliente/RemoverCliente',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(dados),
            success: function (resultado) {

                var t = $(this).parents('.client-table');
                t.remove();
                alert(clienteNome + ' ' + clienteSobrenome+' removido com sucesso.');
                $('#editarShow').hide();


            },
            error: function (xml, status, error) {
                alert('Erro inesperado, tente novamente.');

            }
        })
    } else {
        alert('Remoção cancelada');
    }
});
