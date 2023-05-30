function cpfMask(){
    $(".cpf").mask('000.000.000-00', { reverse: true });
}

function cepMask() {
    $(".cep").mask("99999-999");
}

function adicionarCpfMask(cpf) {
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3\-\$4");
}


function removerCpfMask(cpf) {
    return cpf.replace(/\D/g, '');
}

function removerCepMask(cep) {
    return cep.replace(/\D/g, '');
}