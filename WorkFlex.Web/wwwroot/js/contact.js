$(document).ready(function () {
    const form = $('#contact-form');

    form.on('submit', function (e) {
        e.preventDefault();

        const data = {
            name: $('#name').val(),
            email: $('#email').val(),
            subject: $('#subject').val(),
            message: $('#message').val()
        };

        postGoogleForm(data);
    });

    async function postGoogleForm(data) {
        const formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfG6iGwx187Mv3qiwVAPjxQtwb7LuCoT3TnPR_-tlGdAb3gKA/formResponse";
        const formData = new FormData();
        formData.append('entry.1254723452', data.name);
        formData.append('entry.607270649', data.email);
        formData.append('entry.184926896', data.subject);
        formData.append('entry.1109167841', data.message);

        try {
            await fetch(formURL, {
                method: 'post',
                body: formData,
                mode: 'no-cors'
            });

            // Show success message
            Swal.fire({
                title: "Success!",
                text: "Thank you for reaching out. We will get back to you shortly!",
                icon: "success"
            }).then((result) => {
                if (result.isConfirmed) {
                    form[0].reset();
                }
            });
        } catch (error) {
            // Show error message
            Swal.fire({
                title: "Error!",
                text: "We could not send your message. Please check your internet connection and try again.",
                icon: "error"
            }).then((result) => {
                if (result.isConfirmed) {
                    form[0].reset();
                }
            });
        }
    }
});