//Carregar Foto e Nome do Usuário
const CarregarUserInfo = () => {
    $.ajax({
        type: "POST",
        url: "/Home/GetImagem/",
        data: {},
        success: ({ Foto, User }) => {

            var img = document.getElementById('UserImagem');

            if (!(Foto == 'null')) {
                img.setAttribute('src', Foto);
            }

            img.setAttribute('alt', User);

            var h4 = document.getElementById('UserNome');
            h4.innerHTML = User;

        },
        error: (xhr, ajaxOptions, thrownError) => {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

//Ações do menu responsivo
let btnHamb = document.getElementById('btnHamb');
btnHamb.onclick = () => {
    let asideEl = document.getElementById('menu-lateral');
    let logo = document.getElementById('logo-nav');
    let menuNotification = document.getElementById('menuNotification');

    if (asideEl.className == 'reponsive-none' && logo.className == 'logo reponsive-none' && btnHamb.className == 'btnHamb btn-off') {
        asideEl.className = 'reponsive-show';
        logo.className = 'logo reponsive-show';
        menuNotification.className = 'notification-menu notification-none';
        btnHamb.className = 'btnHamb btn-on';
    }
    else {
        asideEl.className = 'reponsive-none';
        logo.className = 'logo reponsive-none';
        btnHamb.className = 'btnHamb btn-off';
    }
}

//Alimentar select com os dados dos usuários
const getUsuarios = () => {

    $.ajax({
        type: "POST",
        url: "/Manage/GetUsers",
        data: {},
        success: function (data) {

            $(".select-users").select2({
                placeholder: 'Selecione o Usuário',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getTipos = () => {
    $(".select-tipo").select2({
        placeholder: 'Selecione o Tipo',
        theme: 'bootstrap',
        allowClear: true,
        width: 'resolve'
    });
}

const getVisitantes = (selected) => {
    $.ajax({
        type: "POST",
        url: "/Visitantes/GetVisitantes",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;  
            }

            $(".select-visitante").select2({
                placeholder: 'Selecione o Visitante',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getEntradas = (selected) => {
    $.ajax({
        type: "POST",
        url: "/Guarita/Entradas/GetEntradas",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;
            }

            $(".select-entrada").select2({
                placeholder: 'Selecione a Entrada',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getSaidasTrans = (selected) => {
    $.ajax({
        type: "POST",
        url: "/Transporte/Saidas/GetSaidas",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;
            }

            $(".select-saida-trans").select2({
                placeholder: 'Selecione a Saida',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getVeiculos = (selected) => {
    $.ajax({
        type: "POST",
        url: "/Veiculos/GetVeiculos",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;
            }

            $(".select-veiculo").select2({
                placeholder: 'Selecione o Veiculo',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getVeiculosVisit = (selected) => {
    $.ajax({
        type: "POST",
        url: "/VeiculoVisitantes/GetVeiculos",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;
            }

            $(".select-veiculo-visitante").select2({
                placeholder: 'Selecione o Veiculo',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const getMotoristas = (selected) => {
    $.ajax({
        type: "POST",
        url: "/Motoristas/GetMotoristas",
        data: {},
        success: function (data) {

            if (selected !== null) {
                data[data.findIndex((obj => obj.id == selected))].selected = true;
            }

            $(".select-motorista").select2({
                placeholder: 'Selecione o Motorista',
                theme: 'bootstrap',
                allowClear: true,
                width: 'resolve',
                data: data
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const loadPhoto = (e) => {  
    let div;
    if (e.target.name == 'CnhRgFile') {
        div = document.getElementById('imgdiv1');
    }
    else if (e.target.name == 'FotoFile') {
        div = document.getElementById('imgdiv2');
    }
    else {
        div = document.getElementById('imgdiv');
    }

    if (!(e.target.files[0] == undefined)) {

        let selectedFile = e.target.files[0];

        let reader = new FileReader();

        reader.onload = (e1) => {        

            addPhoto(div, e1.target.result, selectedFile.name);
        }

        reader.readAsDataURL(selectedFile);
    }
}

const addPhoto = (div,src,title) => {
    div.innerHTML = '';
    div.setAttribute('class', '');
    div.style.marginTop = '10px';
    div.style.backgroundColor = '#e1e1e1';
    div.style.border = '2px solid #4a4a4a';
    div.style.textAlign = 'center';

    let img = document.createElement('img');
    img.setAttribute('id', 'fotoimg');
    img.setAttribute('name', 'fotoimg');
    img.style.width = '120px';

    img.title = title;

    img.src = src;

    div.append(img);
}

let iptFotos = document.querySelectorAll('.foto');
iptFotos.forEach(ipt => {
    ipt.onchange = loadPhoto;
});

const carregarTabelas = () => {
    $('#table_data').DataTable({
        language: {
            url: '/../Content/DataTable/language/Portuguese-Brasil.json'
        }
    });
}

window.onload = () => {
    CarregarUserInfo();
    getUsuarios();
    getTipos();    
    carregarTabelas();

    if (typeof visitanteId !== 'undefined') {
        getVisitantes(visitanteId);
    }
    else {
        getVisitantes(null);
    }

    if (typeof entradaId !== 'undefined') {
        getEntradas(entradaId);
    }
    else {
        getEntradas(null);
    }

    if (typeof veiculoId !== 'undefined') {
        getVeiculos(veiculoId);
    }
    else {
        getVeiculos(null);
    }

    if (typeof motoristaId !== 'undefined') {
        getMotoristas(motoristaId);
    }
    else {
        getMotoristas(null);
    }

    if (typeof saidaId !== 'undefined') {
        getSaidasTrans(saidaId);
    }
    else {
        getSaidasTrans(null);
    }

    if (typeof veiculoVisitanteId !== 'undefined') {
        getVeiculosVisit(veiculoVisitanteId);
    }
    else {
        getVeiculosVisit(null);
    }
}