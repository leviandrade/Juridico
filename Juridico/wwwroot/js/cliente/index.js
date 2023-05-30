
var colunas = montarColunas();

grid = $('#tabelaClientes').DataTable({
    data: [],
    columns: colunas,
    language: {
        "lengthMenu": "_MENU_ REGISTROS POR PÁGINA",
        "zeroRecords": "NENHUM REGISTRO ENCONTRADO",
        "info": "EXIBINDO _PAGE_ DE _PAGES_",
        "infoEmpty": "NENHUM REGISTRO ENCONTRADO",
        "infoFiltered": "(FILTRADO DE _MAX_ REGISTROS)",
        "search": "PESQUISAR:",
        "sPaginationType": "pagination",
        "paginate": {
            "first": "PRIMEIRO",
            "last": "ÚLTIMO",
            "next": "PRÓXIMO",
            "previous": "ANTERIOR"
        }
    },
    "pagingType": "full_numbers"
});
atualizarGrid();

function montarColunas() {
    var colunas = [
        { title: "Nome", data: "nome", width: "200px" },
        {
            title: "CPF",
            data: "cpf",
            width: "150px",
            render: function (data, type) {
                return adicionarCpfMask(data);
            }
        },
        { title: "E-mail", data: "email", width: "75px" },
        {
            data: "id",
            width: "10px",
            render: function (data, type) {
                if (type === 'display') {

                    var editar = '<a title="Editar" href="/Cliente/Cliente/Editar/' + data + '"' + 'class="fa fa-pencil">&nbsp;</a>';
                    var excluir = '<a href="#" title="Excluir" onclick="Excluir(' + data + ');" class="fa fa-remove">&nbsp;</a>';

                    data = editar + '&nbsp;' + excluir;
                }

                return data;
            }
        }];

    return colunas;
}

function atualizarGrid() {
    var promisse = requisicao("/Cliente/Cliente/Listar/", "GET");
    promisse.done(function (retorno) {
        grid.clear();
        grid.rows.add(retorno.data).draw();
    });
}

//function abrirFormularioAlunos() {
//    $('#formulario').css("display", "block");
//}

//function salvarRegistro(form, event) {
//    event.preventDefault();
//    var objeto = montarObjeto(form);
//    var metodo = 'POST';
//    if (objeto.id == "")
//        objeto.id = 0;
//    else
//        metodo = 'PUT';

//    if (objeto.idPessoa == "")
//        objeto.idPessoa = 0;
//    var promisse = requisicao(servidor.FatecProjeto + "Alunos", metodo, objeto);
//    promisse.done(function (data) {
//        if (!data.valido)
//            alert(data.erros);
//        else {
//            atualizarGrid();
//            LimparDados();
//        }
//    }).fail(function (data) {
//        if (data.status == "403")
//            alert("Usuário sem permissão para esta tarefa.");
//        if (data.status == "401") {
//            alert("Faça o Login no sistema.");
//            window.location.href = "Login/Index"
//        }
//    })
//}

//function Editar(id, event) {
//    event.preventDefault();
//    abrirFormularioAlunos()
//    var promise = requisicao(servidor.FatecProjeto + "Alunos/" + id, 'GET');
//    promise.done(function (data) {
//        var formulario = $('#formulario').find("form");
//        formulario.data("item", data);
//        var aluno = data.objetoRetorno;
//        $.each(aluno, function (prop, valor) {
//            if (prop == "nascimento") {
//                var data = new Date(valor)
//                dataFormatada = data.toLocaleDateString();
//                var dia = dataFormatada.split("/")[0];
//                var mes = dataFormatada.split("/")[1];
//                var ano = dataFormatada.split("/")[2];
//                valor = ano + "-" + mes + "-" + dia;
//            }
//            formulario.find("[name=" + prop + "]").val(valor);
//        });
//    })
//}

//function Excluir(id) {
//    if (confirm("Deseja realmente excluir este registro?")) {
//        var promisse = requisicao(servidor.FatecProjeto + "Alunos/" + id, "DELETE");
//        promisse.done(function () {
//            atualizarGrid();
//        })
//    };
//}