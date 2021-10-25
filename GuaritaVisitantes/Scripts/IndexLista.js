let cks = document.querySelectorAll('input[type="checkbox"]');
let btnDel = document.querySelector('.btn-del');
let avisoDelete = document.getElementById('avisoDelete');
let btnSim = document.querySelector('.btn-aviso-sim');
let btnNao = document.querySelector('.btn-aviso-nao');
cks.forEach(ck => {
    ck.onchange = () => {
        let qtdCheckeds = document.querySelectorAll('input:checked').length;
        if (qtdCheckeds > 0) {
            btnDisplay('50px', btnDel);
        }
        else {
            btnDisplay('-65px', btnDel);
        }
    }
});

const btnDisplay = (right, btn) => {
    btn.style.bottom = right;
}

btnDisplay('-65px', btnDel);

btnDel.onclick = () => {
    avisoDelete.style.display = "inline-flex";
}

btnNao.onclick = () => {
    avisoDelete.style.display = "none";
}

btnSim.onclick = () => {
    document.getElementById('tabela01').submit();
}