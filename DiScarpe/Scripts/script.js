$(document).ready(function () {
    $('.nTamanho').click(function () {
        $('.nTamanho.active').removeClass("active");
        $(this).addClass("active");
    });

})

function RecoveryData() {

    if (window.localStorage.getItem("Nome")) {
        document.getElementById("cProduto").value = window.localStorage.getItem("Nome");
    }
    if (window.localStorage.getItem("Categoria")) {
        dropCategoria.value = window.localStorage.getItem("Categoria");
    }

    if (window.localStorage.getItem("Cor")) {
        dropCor.value = window.localStorage.getItem("Cor");
    }
    if (window.localStorage.getItem("Marca")) {
        dropMarca.value = window.localStorage.getItem("Marca");
    }
    if (window.localStorage.getItem("Estilo")) {
        dropEstilo.value = window.localStorage.getItem("Estilo");
    }

    if (window.localStorage.getItem("Tamanho")) {
        dropTamanho.value = window.localStorage.getItem("Tamanho");
    }



}

function SaveElements() {
    if (document.getElementById("cProduto").value) {
        window.localStorage.setItem("Nome", document.getElementById("cProduto").value);
    }
    if (document.getElementById("dropCategoria").value) {
        window.localStorage.setItem("Categoria", document.getElementById("dropCategoria").value);
    }

    if (document.getElementById("dropCor").value) {
        window.localStorage.setItem("Cor", document.getElementById("dropCor").value);

    }

    if (document.getElementById("dropMarca").value) {
        window.localStorage.setItem("Marca", document.getElementById("dropMarca").value);
    }

    if (document.getElementById("dropEstilo").value) {
        window.localStorage.setItem("Estilo", document.getElementById("dropEstilo").value);

    }

    if (document.getElementById("dropTamanho").value) {
        window.localStorage.setItem("Tamanho", documento.getElementById("dropTamanho").value);

    }
}

function toCleanStorage() {
    window.localStorage.clear();

}


$("#adicionarCarrinho").click(function () {

    var nomeUsuario = $("#nomeUsuario").text();

    if (nomeUsuario == "") {
        $("#mensagemLogin").append('<div class="alert alert-danger" role="alert">'
            + '<span class="glyphicon glyphicon-exclamation-sign" aria- hidden="true"></span >'
            + '<span class="sr-only"></span> Você deve fazer o login primeiro!</div>');
    }
    else {
        console.log("ok");
        alert("Ok");
    }
});

function ComprarAgora() {
    Alert("Comprado");
}

