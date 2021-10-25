let btnNoti = document.getElementById('btnNoti');
btnNoti.onclick = () => {
    let btnHamb = document.getElementById('btnHamb');  
    let menuNotification = document.getElementById('menuNotification');
    let asideEl = document.getElementById('menu-lateral');
    let logo = document.getElementById('logo-nav');
    if (menuNotification.className == 'notification-menu notification-none') {
        menuNotification.className = 'notification-menu notification-show';

        if (asideEl.className == 'reponsive-show' && logo.className == 'logo reponsive-show') {
            asideEl.className = 'reponsive-none';
            logo.className = 'logo reponsive-none';
            btnHamb.className = 'btnHamb btn-off';
        }
    }
    else {
        menuNotification.className = 'notification-menu notification-none';
    }
}

const NotOnClick = (e) => {
    let locationHref = '';

    switch (e.dataset.type) {
        case 'EntradaGuarita':
            locationHref = '/Guarita/Entradas';
            break;

        case 'SaidaGuarita':
            locationHref = '/Guarita/Saidas';
            break;

        case 'EntradaTransporte':
            locationHref = '/Transporte/Entradas';
            break;

        case 'SaidaTransporte':
            locationHref = '/Transporte/Saidas';
            break;

        default:
            locationHref = '/Manage';
            break;
    }

    $.ajax({
        type: "POST",
        url: "/Notification/Read",
        data: { key: e.dataset.key },
        success: function (data) {
            if (data.Sucess == true) {
                window.location.href = locationHref;
            }
            else {
                alert(data.Response);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    }); 
}

const GetNotifications = () => {
    document.getElementById('NotMenuItens').innerHTML = '';
    $.ajax({
        type: "GET",
        url: "/Notification",
        success: function (data) {    

            if (data.length > 0) {
                document.getElementById('notAviso').className = 'aviso-show';
            }

            data.forEach((item) => {
                let divMenuItem = document.createElement('div');
                divMenuItem.className = 'menu-item';
                divMenuItem.dataset.key = item.Id;
                divMenuItem.dataset.type = item.Type;
                divMenuItem.setAttribute('onclick', 'NotOnClick(this)');
                let divMenuItemIcon = document.createElement('div');
                divMenuItemIcon.className = 'menu-item-icon';
                divMenuItem.appendChild(divMenuItemIcon);

                let iIcon = document.createElement('i');
                iIcon.setAttribute('aria-hidden', 'true');
                switch (item.Type) {
                    case 'EntradaGuarita':
                        iIcon.className = 'fas fa-arrow-circle-right';
                        break;

                    case 'SaidaGuarita':
                        iIcon.className = 'fas fa-arrow-circle-left';
                        break;

                    case 'EntradaTransporte':
                        iIcon.className = 'fas fa-arrow-circle-right';
                        break;

                    case 'SaidaTransporte':
                        iIcon.className = 'fas fa-arrow-circle-left';
                        break;

                    default:
                        iIcon.className = 'fas fa-lock';
                        break;
                }
                divMenuItemIcon.appendChild(iIcon);

                let divMenuItemBody = document.createElement('div');
                divMenuItemBody.className = 'menu-item-body';
                divMenuItem.appendChild(divMenuItemBody);

                let spanDesc = document.createElement('span');
                let spanDescTxt = document.createTextNode(item.Message);
                spanDesc.appendChild(spanDescTxt);
                divMenuItemBody.appendChild(spanDesc);

                let spanDate = document.createElement('span');
                spanDate.className = 'menu-item-date';
                let spanDateTxt = document.createTextNode(item.DateTime);
                spanDate.appendChild(spanDateTxt);
                divMenuItemBody.appendChild(spanDate);

                document.getElementById('NotMenuItens').appendChild(divMenuItem);
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Falha: " + xhr.readyState + "\nStatus: " + xhr.status + " \nStatusText: " + xhr.statusText);
        }
    });
}

const setIntervalNotifications = () => {
    GetNotifications();
    setInterval(GetNotifications, 30000);
}

setIntervalNotifications();