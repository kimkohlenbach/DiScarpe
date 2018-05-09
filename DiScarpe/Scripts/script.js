
﻿var cProduto = document.getElementById("cProduto");
var dropCor = document.getElementById("dropCor");
var dropCategoria = document.getElementById("dropCategoria");
var dropMarca = document.getElementById("dropMarca");
var dropEstilo = document.getElementById("dropEstilo");
var dropTamanho = document.getElementById("dropTamanho");


$(document).ready(function () {
    $('.nTamanho').click(function () {
        $('.nTamanho.active').removeClass("active");
        $(this).addClass("active");
    });
    window.localStorage.setItem("PrimeiraRodada", "true");

    
  

   
    //dropCategoria.value = localStorage.getItem("Categoria");
    //dropCor.value = localStorage.getItem("Cor");
    //dropMarca.value = localStorage.getItem("Marca");
    //dropTamanho.value = localStorage.getItem("Tamanho");
    //dropEstilo.value = localStorage.getItem("Estilo");

    $("#adCategoria").click(function () {

        prepair("adCategoria");
    })
    $("#adCor").click(function () {
        ToPersiste();

    })
    $("#adMarca").click(function () {
        ToPersiste();

    })
    $("#adEstilo").click(function () {
        ToPersiste();

    })
    $("#adTamanho").click(function () {
        ToPersiste();

    })
    $("#salvaProduto").click(function () {
        ToCleanStorage();

    })
    $("#cancelar").click(function () {
        ToCleanStorage();
    })
})

function showInScreen() {
    if (localStorage.getItem("PrimeiraRodada") == "true") {
        if (localStorage.getItem("Nome") != "") {
            cProduto.value = localStorage.getItem("Nome");
        }
    }
}

function prepair(comand) {
    var guardar = window.localStorage;
    if (cProduto.value != "") {
        guardar.setItem("Nome", $('#cProduto').val());
        alert(guardar.getItem("Nome"));
    }
    else {
        if (cProduto.value != guardar.getItem("Nome")) {
            localStorage.removeItem("Nome");
            guardar.setItem("Nome", $('#cProduto').val());
        }
    }

}


function toCleanStorage() {
    window.localStorage.clear();
    alert("Storage Limpo")
}

//function sentScreen() {


//    var cProduto = document.getElementById("cProduto");
//    var dropCor = document.getElementById("dropCor");
//    var dropCategoria = document.getElementById("dropCategoria");
//    var dropMarca = document.getElementById("dropMarca");
//    var dropEstilo = document.getElementById("dropEstilo");
//    var dropTamanho = document.getElementById("dropTamanho");

//    cProduto.value = localStorage.getItem("Nome");
//    dropCategoria.value = localStorage.getItem("Categoria");
//    dropCor.value = localStorage.getItem("Cor");
//    dropMarca.value = localStorage.getItem("Marca");
//    dropTamanho.value = localStorage.getItem("Tamanho");
//    dropEstilo.value = localStorage.getItem("Estilo");


//}

//function ToPersiste() {
//    var guardar = window.localStorage;
//    
//    guardar.setItem("Cor", $('#dropCor').val());
//    guardar.setItem("Categoria", $('#dropCategoria').val());
//    guardar.setItem("Marca", $('#dropMarca').val());
//    guardar.setItem("Estilo", $('#dropEstilo').val());
//    guardar.setItem("Tamanho", $('#dropTamanho').val());
//}
