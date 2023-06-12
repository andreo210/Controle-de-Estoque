//########## mascara de cep  ######################################

const handleCep = (event) => {
    let input = event.target
    input.value = zipCodeMask(input.value)

}

const zipCodeMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d{5})(\d)/, '$1-$2')
    return value
}


//##################### pesquisar cep #################################

function pesquisacep() {
    var cep = document.getElementById("cep").value;
    //Nova variável "cep" somente com dígitos.


    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Cria um elemento javascript.
        url = 'https://servergeo.praiagrande.sp.gov.br/logradouro/cep/' + cep;
        fetch(url).then(response => {
            return response.json();
        })
            .then(data => {
                meu_callback(data);
            })


    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
};

function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('NomeLogradouro').value = ("");
    document.getElementById('Bairro').value = ("");
    document.getElementById('Cidade').value = ("");
    document.getElementById('Estado').value = ("");

}

//preenche os campos 
function meu_callback(data) {
    if (!("resp.status(500)" in data)) {
        document.getElementById('NomeLogradouro').value = (data[0].nomeCompleto);
        document.getElementById('Bairro').value = (data[0].bairros[0]);
        document.getElementById('Cidade').value = (data[0].nomeMunicipio);
        document.getElementById('Estado').value = (data[0].uf);
    } else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}