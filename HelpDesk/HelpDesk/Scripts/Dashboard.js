$("#ProdutoAdd").click(function () {

    if ($("#IDProduto").val() == "") {
        AlertError("Informe o código do produto.");
        return;
    }
    if ($("#NomeProduto").val() == "") {
        AlertError("Informe o nome do produto.");
        return;
    }

    var data = {
        Cod_Cliente: usuario,
        Cod_Produto: $("#IDProduto").val(),
        Desc_Produto: $("#NomeProduto").val()
    }

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "/api/produto",
        "method": "POST",
        "headers": {
            "content-type": "application/json",
            "cache-control": "no-cache"
        },
        "processData": false,
        "data": JSON.stringify(data),
        "success": function () {
            AlertSuccess("Produto adicionado.")
            location.reload();
        },
        "erro":function () {
            AlertError("Erro ao criar o produto tente mais tarde")
        },
        
    }

    $.ajax(settings).done(function (response) {
        console.log(response);
    });
});


$("#chamadoAdd").click(function () {

    if ($("#AtendimentoAssunto").val() == "") {
        AlertError("Informe o assunto.");
        return;
    }
    if ($("#AtendimentoPrioridade").val() == "") {
        AlertError("Informe a prioridade.");
        return;
    }
    if ($("#AtendimentoPrioridade").val() < 0) {
        AlertError("A prionidade deve ser maior ou igual 0");
        return;
    }
    if ($("#ChamadoDescricao").val() == "") {
        AlertError("Informe uma descrição para o chamdo.");
        return;
    }
    

    var data = {
        Cod_Atendimento: null,
        Descricao: $("#AtendimentoAssunto").val(),
        Prioridade: null,
        Data: null
    }


    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "/api/TipoAtendimento",
        "method": "POST",
        "headers": {
            "content-type": "application/json",
            "cache-control": "no-cache"
        },
        "processData": false,
        "data": JSON.stringify(data),
        "success": function (response) {            
            console.log(response);
            CriarChamado(response.Cod_Atendimento);
            AlertSuccess("Novo atentimento salvo.")

            if (document.getElementById("FileUpload").files.length) {
                upload()
            }
            location.reload();
        },
        "erro": function () {
            AlertError("Erro ao criar, tente mais tarde")
        },

    }

    $.ajax(settings).done(function (response) {
        console.log(response);
    });
 
});


function CriarChamado(Cod_Atendimento) {

    var _data = {
        Cod_Atendimento: Cod_Atendimento,
        Cod_Chamado : null,
        Desc_Chamado: $("#ChamadoDescricao").val(),
        Cod_Produto: $("#IDProd").val(),
        Data: null
    }

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "/api/Chamados",
        "method": "POST",
        "headers": {
            "content-type": "application/json",
            "cache-control": "no-cache"
        },
        "processData": false,
        "data": JSON.stringify(_data),
        "success": function (response) {
            console.log(response);
            AlertSuccess("Chamado Criado com sucesso.")
            location.reload();
        },
        "erro": function () {
            AlertError("Erro ao criar, tente mais tarde")
        },

    }

    $.ajax(settings).done(function (response) {
        console.log(response);
    });

}



function upload() {
    var formData = new FormData();
    var totalFiles = document.getElementById("FileUpload").files.length;

    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("FileUpload").files[i];
        
        formData.append("FileUpload", file);
    }

    $.ajax({
        type: 'post',
        url: '/api/UploadFile',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
    });
}