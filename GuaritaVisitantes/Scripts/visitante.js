//Captura de foto
let video = document.querySelector('#video-foto');

navigator.mediaDevices.getUserMedia({ video: true })
    .then(function (mediaStream) {
        video.srcObject = mediaStream;
        video.play();
    })
    .catch(function (err) {
        console.log('Não há permissões para acessar a webcam')
    });

let btnCapturar = document.getElementById('btnCapturar');
let btnUpload = document.getElementById('btnUpload');
let canvas = document.querySelector("#canvas-foto");
let FotoPath = document.getElementById('FotoPath'); if (FotoPath.value !== '' && FotoPath.value !== null && FotoPath.value !== undefined) {
    canvas.style.border = '3px solid black';
    let ctx = canvas.getContext('2d');
    let imgFotoPath = document.createElement('img');
    imgFotoPath.src = FotoPath.value;
    imgFotoPath.id = 'imgFotoPath'
    canvas.height = imgFotoPath.height;
    canvas.width = imgFotoPath.width;
    ctx.drawImage(imgFotoPath, 0, 0);
}

btnCapturar.onclick = () => {
    canvas.height = video.videoHeight;
    canvas.width = video.videoWidth;
    canvas.style.border = '3px solid black';
    let context = canvas.getContext('2d');
    context.drawImage(video, 0, 0);
    btnUpload.style.display = 'inline-block';
}
btnUpload.onclick = () => {
    canvas.toBlob(function (blob) {

        var form = new FormData();
        form.append('image', blob, 'webcam.jpg');

        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Visitantes/Upload', true);
        xhr.onload = function (e) {
            let response = JSON.parse(e.target.response);
            console.log(response);
            if (response.result == true) {           
                FotoPath.value = response.path;
                alert('Upload feito com sucesso!');
            }
            else {
                alert('Erro ao fazer upload da foto!');
            }
        };
        xhr.send(form);

    }, 'image/jpeg');
}