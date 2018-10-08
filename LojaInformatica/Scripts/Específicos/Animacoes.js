
function ShowForm(cadastrarUser) {
    var display = document.getElementById(cadastrarUser).style.display;
    if (display == "none")
        document.getElementById('cadastrar').style.display = 'block';
    else
        document.getElementById(cadastrarUser).style.display = 'none';
    $('#editarShow').hide();


}
$(document).on("click", "#show-more", function () {
 var vermais = true;
var dados = {
        verMais: vermais
    };


    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Cliente/VerMais' ,
        contentType: 'application/json; charset=utf-8',
        success: function (resultado) {
            if (resultado.sucesso) {

                console.log(resultado.elements[0].Email);
                $.each(resultado.elements, function (i, val) {


                    var sexo = '';
                    if (resultado.elements[i].Sexo == 0) {
                        sexo = 'Masculino';
                    } else if (resultado.sexo == 1) {
                        sexo = 'Feminino';
                    } else {
                        sexo = 'Indeterminado';
                    }
                    var pessoa = resultado.elements[i].Pessoa == 0 ? 'Física' : 'Jurídica';
                    var tr = '<tr class="client-table">' +
                        '<td id="id' + resultado.elements[i].Id + '">' + resultado.elements[i].Id + '</td>' +
                        '<td id="nome' + resultado.elements[i].Id + '">' + resultado.elements[i].Nome + '</td>' +
                        '<td id="sobrenome' + resultado.elements[i].Id + '">' + resultado.elements[i].Sobrenome + '</td>' +
                        '<td id="pessoa' + resultado.elements[i].Id + '">' + pessoa + '</td>' +
                        '<td id="sexo' + resultado.elements[i].Id + '">' + sexo + '</td>' +
                        '<td id="editar' + resultado.elements[i].Id + '">' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-cliente" id="btn-editar' + resultado.elements[i].Id+ '">' +
                        '<i class="fa fa-pencil"></i> Editar/Visualizar' + '</a>' + '</div >' + '</td >' +
                        '<td>' + '<button type="button" class="btn red delete botao-deletar-cliente" id="deletar' + resultado.elements[i].Id+ '">' +
                        ' <i class="fa fa-trash"></i> <span>Delete</span>' + '</a>' + '</td> </button> </td>' +
                        '</tr >';

                                            
                                           
                                        
                                    

//[id^='input']
                    $('#tabela-clientes').append(tr);



                });
                
                

                //$('#tabela-usuarios').append(tr);
            }else {
                alert('Erro interno, tente novamente.');
            }
        },
        error: function (xml, status, error) {

        }
    })
});


$(document).on("click", "#current-user", function () {
    
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Home/Index',
        contentType: 'application/json; charset=utf-8',
        success: function (resultado) {
            if (resultado.sucesso) {

                console.log(resultado.elements[0].Email);
                $.each(resultado.elements, function (i, val) {


                    var sexo = '';
                    if (resultado.elements[i].Sexo == 0) {
                        sexo = 'Masculino';
                    } else if (resultado.sexo == 1) {
                        sexo = 'Feminino';
                    } else {
                        sexo = 'Indeterminado';
                    }
                    var pessoa = resultado.elements[i].Pessoa == 0 ? 'Física' : 'Jurídica';
                    var tr = '<tr class="client-table">' +
                        '<td id="id' + resultado.elements[i].Id + '">' + resultado.elements[i].Id + '</td>' +
                        '<td id="nome' + resultado.elements[i].Id + '">' + resultado.elements[i].Nome + '</td>' +
                        '<td id="sobrenome' + resultado.elements[i].Id + '">' + resultado.elements[i].Sobrenome + '</td>' +
                        '<td id="pessoa' + resultado.elements[i].Id + '">' + pessoa + '</td>' +
                        '<td id="sexo' + resultado.elements[i].Id + '">' + sexo + '</td>' +
                        '<td id="editar' + resultado.elements[i].Id + '">' + ' <div class="actions"> ' + ' <a class="btn btn-default btn-sm botao-editar-cliente" id="btn-editar' + resultado.elements[i].Id + '">' +
                        '<i class="fa fa-pencil"></i> Editar/Visualizar' + '</a>' + '</div >' + '</td >' +
                        '<td>' + '<button type="button" class="btn red delete botao-deletar-cliente" id="deletar' + resultado.elements[i].Id + '">' +
                        ' <i class="fa fa-trash"></i> <span>Delete</span>' + '</a>' + '</td> </button> </td>' +
                        '</tr >';






                    //[id^='input']
                    $('#tabela-clientes').append(tr);



                });



                //$('#tabela-usuarios').append(tr);
            } else {
                alert('Erro interno, tente novamente.');
            }
        },
        error: function (xml, status, error) {

        }
    })
});
