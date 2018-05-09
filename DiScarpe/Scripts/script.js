$(document).ready(function () {
    $('.nTamanho').click(function () {
        $('.nTamanho.active').removeClass("active");
        $(this).addClass("active");
    });

    var firstTime = localStorage.getItem("first_time");
    if (!firstTime) {
        // first time loaded!
        toCleanStorage();
        localStorage.setItem("first_time", "1");

    }
    else {
        RecoveryData();
    }
   
})

function RecoveryData() {
    cProduto.value = window.localStorage.getItem("Nome");
    dropCategoria.value = window.localStorage.getItem("Categoria");
    dropCor.value = window.localStorage.getItem("Cor");
    dropMarca.value = window.localStorage.getItem("Marca");
    dropEstilo.value = window.localStorage.getItem("Estilo");
    dropTamanho.value = window.localStorage.getItem("Tamanho");

}

function SaveElements() {
    window.localStorage.setItem("Nome", document.getElementById("cProduto").value);
    window.localStorage.setItem("Categoria", document.getElementById("dropCategoria").value);
    window.localStorage.setItem("Cor", document.getElementById("dropCor").value);
    window.localStorage.setItem("Marca", document.getElementById("dropMarca").value);
    window.localStorage.setItem("Estilo", document.getElementById("dropEstilo").value);
    window.localStorage.setItem("Tamanho", documento.getElementById("dropTamanho").value);
}

function toCleanStorage() {
    window.localStorage.clear();
  
}

