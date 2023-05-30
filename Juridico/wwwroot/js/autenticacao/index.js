cpfMask();

async function login() {
    let cpf = $("#cpf").val();
    let senha = $("#senha").val();

    let cpfValido = validarCPF(cpf);
    if (!cpfValido) {
        toastr.error('CPF Inválido');
        return;
    }

    cpf = removerCpfMask(cpf);

    try {
        await requisicao("/Autenticacao/Login", "POST", { cpf, senha });
        window.location.href = "/Home/Index";
    } catch (e) {
        console.log(e);
        toastr.error(e.responseJSON.errors.join("<br/>"));
    }
}







