﻿$(document).ready(function () {
    $('.nTamanho').click(function () {
        $('.nTamanho.active').removeClass("active"); //aqui removemos a class do item anteriormente clicado para que possamos adicionar ao item clicado
        $(this).addClass("active"); //aqui adicionamos a class ao item clicado
    });
});