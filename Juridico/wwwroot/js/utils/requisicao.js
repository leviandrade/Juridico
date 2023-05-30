function requisicao(endereco, tipo, dados = null) {
    $(".loading").fadeIn();

    var promise = $.ajax({
        cache: false,
        url: endereco,
        type: tipo,
        data: dados
    }).always(function () {
        $(".loading").fadeOut();
    });

    return promise;
}