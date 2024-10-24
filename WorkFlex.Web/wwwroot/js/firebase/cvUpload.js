/* global firebase */
const firebaseConfig = {
    apiKey: "{firebase_apiKey}",
    authDomain: "{firebase_authDomain}",
    projectId: "{firebase_projectId}",
    storageBucket: "{firebase_storageBucket}",
    messagingSenderId: "905377519184",
    appId: "{firebase_appId}",
    measurementId: "{firebase_measurementId}"
};

firebase.initializeApp(firebaseConfig);

function updateUploadMessage() {
    const $fileInput = $('#file-upload');
    const $message = $('#upload-message');
    const $fileName = $('#file-name');

    if ($fileInput[0].files.length > 0) {
        const selectedFileName = $fileInput[0].files[0].name;
        $message.hide();
        $fileName.show().text(selectedFileName);
    } else {
        $message.show();
        $fileName.hide();
    }
}
function submitForm() {

    if (validateForm()) {
        $('.progress-container').show();
        $('.progress-bar').css('width', '0%');

        uploadFile(function () {
            $('.progress-bar').css('width', '100%');
            setTimeout(() => {
                document.querySelector('form').submit();
            }, 500);
        });
    }
}

function uploadFile(callback) {
    const $fileInput = $('#file-upload');
    if ($fileInput[0].files.length === 0) {
        alert('Please select a file to upload');
        return;
    }

    const file = $fileInput[0].files[0];
    const storageRef = firebase.storage().ref();
    const filename = generateUniqueFilename(file.name);
    const fileRef = storageRef.child('cv/' + filename);

    const uploadTask = fileRef.put(file);

    uploadTask.on('state_changed', (snapshot) => {
        const progress = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
        $('.progress-bar').css('width', progress + '%');
    }, (error) => {
        console.error('Error uploading file', error);
        alert('Error uploading file');
    }, () => {
        uploadTask.snapshot.ref.getDownloadURL().then((downloadURL) => {
            $('#file-url').val(downloadURL);
            if (callback) callback();
        });
    });
}

function generateUniqueFilename(filename) {
    const timestamp = Date.now();
    const hash = Math.random().toString(36).substring(7);
    return `${hash}_${timestamp}_${filename}`;
}
