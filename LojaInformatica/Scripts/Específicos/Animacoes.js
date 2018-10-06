function ShowForm(cadastrarUser) {
    var display = document.getElementById(cadastrarUser).style.display;
    if (display == "none")
        document.getElementById('cadastrar').style.display = 'block';
    else
        document.getElementById(cadastrarUser).style.display = 'none';
    $('#editarShow').hide();


}
function VerMais() {
    
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Usuario/ListarUsuarios',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(text),
        success: function (resultado) {
            if (resultado.sucesso) {
                //all right

               

                var nivelAc = resultado.nivel == 0 ? 'Administrador' : 'Funcionário';
                var tr = '<tr>' +
                    '<td id="id' + resultado.id + '">' + resultado.id + '</td>' +
                    '<td id="nome' + resultado.id + '">' + resultado.nome + '</td>' +
                    '<td id="email' + resultado.id + '">' + resultado.email + '</td>' +
                    '<td id="estado' + resultado.id + '">' + ativo + '</td>' +
                    '<td id="nivelAcesso' + resultado.id + '">' + nivelAc + '</td>' +
                    '</tr >';

                $('#tabela-usuarios').prepend(tr);
            } else {
                //nao foi validado corretamente
            }
        },
        error: function (xml, status, error) {

        }


    })
}