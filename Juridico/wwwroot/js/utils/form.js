function montarObjeto(form) {
    form = $(form);
    var valores = form.serializeArray();
    var objeto = {};
    $.each(valores, function (i, item) {
        objeto[item.name] = item.value;
    });

    return objeto;
}