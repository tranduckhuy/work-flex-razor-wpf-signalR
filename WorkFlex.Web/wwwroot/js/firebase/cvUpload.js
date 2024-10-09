/* global firebase */
const firebaseConfig = {
    apiKey: "{firebase_apiKey}",
    authDomain: "{firebase_authDomain}",
    projectId: "{firebase_projectId}",
    storageBucket: "{firebase_storageBucket}",
    messagingSenderId: "{firebase_messagingSenderId}",
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

    fileRef.put(file).then((snapshot) => {
        let downloadURL = snapshot.downloadURL;
        $('#file-url').val(downloadURL);
        alert('File uploaded successfully');
        if (callback) callback();
    }).catch((error) => {
        console.error('Error uploading file', error);
        alert('Error uploading file');
    });
}

function generateUniqueFilename(filename) {
    const timestamp = Date.now();
    const hash = Math.random().toString(36).substring(7);
    return `${hash}_${timestamp}_${filename}`;
}

function submitForm() {
    uploadFile(function () {
        document.querySelector('form').submit();
    });
}