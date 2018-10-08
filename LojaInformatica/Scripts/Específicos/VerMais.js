/// <reference path="typings/jquery/jquery.d.ts" />

$(document).on("click", "#sshow-more", function () {
    
    $.getJSON("/Home/MostrarMais", function (data) {
            employees = data;

            for (var i = 0; i < employees.length; i++) {
                if (i < 100) {
                    var ativo = resultado.ativo === true ? 'Ativo' : 'Inativo';

                    var nivelAc = resultado.nivel == 0 ? 'Administrador' : 'Funcionário';
                    var tr = '<tr>' +
                        '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
                        '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
                        '<td id="email' + resultado.id + '">' + resultado.email + '</td>' +
                        '<td id="estado' + resultado.id + '">' + ativo + '</td>' +
                        '<td id="nivelAcesso' + resultado.id + '">' + nivelAc + '</td>' +
                        '<td>' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-usuario "' +
                        'id="btn-editar' + resultado.id + '" onclick = "editarItemPorId()" > ' +
                        '<i class="fa fa-pencil"></i> Editar' + '</a>' + '</div >' + '</td >' +
                        '</tr >';

                    $('#tabela-usuarios').prepend(tr);
}
                else
                    break;
            }
        });
    });

})
//var nivelAc = resultado.nivel == 0 ? 'Administrador' : 'Funcionário';
//var tr = '<tr>' +
//    '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
//    '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
//    '<td id="email' + resultado.id + '">' + resultado.email + '</td>' +
//    '<td id="estado' + resultado.id + '">' + ativo + '</td>' +
//    '<td id="nivelAcesso' + resultado.id + '">' + nivelAc + '</td>' +
//    '</tr >';

//$('#tabela-usuarios').prepend(tr);
            
//        },
//error: function (xml, status, error) {

//}


//    })
//});