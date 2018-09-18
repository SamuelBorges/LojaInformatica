function ShowForm(cadastrarUser) {
    var display = document.getElementById(cadastrarUser).style.display;
    if (display == "none")
        document.getElementById('cadastrar').style.display = 'block';
    else
        document.getElementById(cadastrarUser).style.display = 'none';
}