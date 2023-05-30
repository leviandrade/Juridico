cpfMask();
cepMask();
obterCliente();
visibilidadeAbaArquivos();

function visibilidadeAbaArquivos() {
    if ($("#Cliente_Id").val() == "") {
        $("#divArquivos").addClass("d-none");
    }
    else {
        $("#divArquivos").removeClass("d-none");
    }
}

function preencherId(id) {
    $("#Cliente_Id").val(id);
    visibilidadeAbaArquivos();
}

$("#imgInp").on("change", function () {
    const [file] = $(this)[0].files
    if (file) {
        let obj = {
            idClienteArquivo: 0,
            src: URL.createObjectURL(file)
        }
        $("#tmpl-arquivo").tmpl(obj).appendTo($("#divArquivos"));
        //$("#imagens").append(`
        //    <div style="width:48%">
        //    <img class="arquivoAdicionado" src="#" alt="your image" style="height: 250px;heigth:250px;border: 2px solid black;padding: 1px;margin:2px "/>
        //    <br/>
        //    <input type="text" class="form-control" placeholder="Digite uma descrição para o arquivo" /></div> `);
        //$(".arquivoAdicionado").last()[0].src = URL.createObjectURL(file)
    }
})

function salvar(event) {
    event.preventDefault();

    let form = $("#frmCliente");
    var objeto = montarObjeto(form);

    objeto['cpf'] = removerCpfMask(objeto['cpf']);
    objeto['cep'] = removerCepMask(objeto['cep']);

    objeto['arquivos'] = obterArquivos();

    if (objeto['id'] == "") {
        incluir(objeto);
    }
    else
        atualizar(objeto);
}

function obterArquivos() {
    let arquivos = [];
    let arquivosAdicionados = $("#divArquivos").find(".divArquivo");
    for (let i = 0; i < arquivosAdicionados.length; i++) {
        arquivos.push({
            idClienteArquivo: $(arquivosAdicionados[i]).find(".idClienteArquivo").val(),
            arquivo: "",
            descricao: $(arquivosAdicionados[i]).find(".descricaoArquivo").val()
        })
    }

    return arquivos;
}

function incluir(objeto) {
    var promisse = requisicao("/Cliente/Cliente/Incluir/", "POST", objeto);
    promisse.done(function (retorno) {
        toastr.success("Cliente inserido com sucesso.");
        preencherId(retorno.data);
    }).fail(function (retorno) {
        console.log(retorno);
    })
}
function atualizar(objeto) {
    var promisse = requisicao("/Cliente/Cliente/Atualizar/" + objeto['Cliente.Id'], "PUT", objeto);
    promisse.done(function (retorno) {
        toastr.success("Cliente atualizado com sucesso.");
    }).fail(function (retorno) {
        console.log(retorno);
    })
}

$("#Cliente_CEP").blur(function () {
    var cep = $(this).val().replace(/\D/g, '');

    if (cep != "") {
        var validacep = /^[0-9]{8}$/;
        if (validacep.test(cep)) {
            requisicao("https://viacep.com.br/ws/" + cep + "/json", "get").done(function (dados) {
                $("#Cliente_Endereco").val(dados.logradouro);
                $("#Cliente_Bairro").val(dados.bairro);
                $("#Cliente_Cidade").val(dados.localidade);
                $("#Cliente_Estado").val(dados.uf);
            });
        }
        else {
            toastr.error("Formato de CEP inválido.");
        }
    }
});

async function obterCliente() {
    let id = window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1);
    if (id != "") {
        try {
            let promise = await requisicao("/Cliente/Cliente/ObterCliente/" + id, "GET");
            let cliente = promise.data;
            let formulario = $("#frmCliente");
            $.each(cliente, function (prop, valor) {
                //if (prop == "nascimento") {
                //    var data = new Date(valor)
                //    dataFormatada = data.toLocaleDateString();
                //    var dia = dataFormatada.split("/")[0];
                //    var mes = dataFormatada.split("/")[1];
                //    var ano = dataFormatada.split("/")[2];
                //    valor = ano + "-" + mes + "-" + dia;
                //}
                formulario.find("[name=" + prop + "]").val(valor);
            });
        }
        catch (ex) {
            console.log(ex);
        }
    }
}

function preencherValoresFormulario(cliente) {

}