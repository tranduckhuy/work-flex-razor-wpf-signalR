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

// Get elements
const fileInputAvatar = $('#avatar-file');
const avtInputHidden = $('#avatar-hidden');
if (fileInputAvatar.length && avtInputHidden.length) {
    fileInputAvatar.on('change', function (e) {
        avatarImage(e, "avatar-image");
    });
}

// Check for elements exist or not
const fileInputBackground = $('#background-file');
const bgrInputHidden = $('#background-hidden');
if (fileInputBackground.length && bgrInputHidden.length) {
    fileInputBackground.on('change', function (e) {
        backgroundImage(e, "background-image");
    });
}

function avatarImage(e, imageId) {
    var file = e.target.files[0];
    const storageRef = firebase.storage().ref();
    const uniqueFilename = generateUniqueFilename(file.name);
    var uploadTask = storageRef.child('avatar/' + uniqueFilename).put(file);

    uploadTask.on(firebase.storage.TaskEvent.STATE_CHANGED,
        function () { /* Optional progress handling */ },
        function (error) {
            switch (error.code) {
                case 'storage/unauthorized':
                    console.error("Unauthorized access.");
                    break;
                case 'storage/canceled':
                    console.error("Upload canceled.");
                    break;
                case 'storage/unknown':
                    console.error("Unknown error occurred.");
                    break;
            }
        },
        function () {
            uploadTask.snapshot.ref.getDownloadURL().then(function (downloadURL) {
                $('#' + imageId).attr('src', downloadURL);
                avtInputHidden.val(downloadURL);

                // Submit form
                $('#profileImageForm').submit();
            });
        });
}

function backgroundImage(e, imageId) {
    var file = e.target.files[0];
    const storageRef = firebase.storage().ref();
    const uniqueFilename = generateUniqueFilename(file.name);
    var uploadTask = storageRef.child('background/' + uniqueFilename).put(file);

    uploadTask.on(firebase.storage.TaskEvent.STATE_CHANGED,
        function () { /* Optional progress handling */ },
        function (error) {
            switch (error.code) {
                case 'storage/unauthorized':
                    console.error("Unauthorized access.");
                    break;
                case 'storage/canceled':
                    console.error("Upload canceled.");
                    break;
                case 'storage/unknown':
                    console.error("Unknown error occurred.");
                    break;
            }
        },
        function () {
            uploadTask.snapshot.ref.getDownloadURL().then(function (downloadURL) {
                $('#' + imageId).attr('src', downloadURL);
                bgrInputHidden.val(downloadURL);

                // Submit form
                $('#profileImageForm').submit();
            });
        });
}

function generateUniqueFilename(filename) {
    const timestamp = Date.now();
    const hash = Math.random().toString(36).substring(7);
    return `${hash}_${timestamp}_${filename}`;
}
