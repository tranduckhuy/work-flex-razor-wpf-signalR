$(document).ready(function () {
    const form = $('#contact-form');

    form.on('submit', function (e) {
        e.preventDefault();

        const data = {
            name: $('#name').val(),
            phone: $('#phone').val(),
            subject: $('#subject').val(),
            message: $('#message').val()
        };

        // Validate the form data
        if (validateForm(data)) {
            postGoogleForm(data);
        }
    });

    function validateForm(data) {
        // Check for empty fields
        for (const [key, value] of Object.entries(data)) {
            if (!value.trim()) {
                Swal.fire({
                    title: "Error!",
                    text: `${key.charAt(0).toUpperCase() + key.slice(1)} cannot be empty!`,
                    icon: "error"
                });
                return false; // Return false if any field is empty
            }
        }

        // Validate phone number format
        const phoneRegex = /([\+84|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})\b/;
        if (!phoneRegex.test(data.phone)) {
            Swal.fire({
                title: "Error!",
                text: "Please enter a valid phone number!",
                icon: "error"
            });
            return false; // Return false if phone number doesn't match the regex
        }

        return true; // All validations passed
    }

    async function postGoogleForm(data) {
        const formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdAGCD4CQm7uk9uihHsLqcoatIhoQt2p7hLSsyjeLzy596Cug/formResponse";
        const formData = new FormData();
        formData.append('entry.318300183', data.name);
        formData.append('entry.1955276459', data.phone);
        formData.append('entry.841977688', data.subject);
        formData.append('entry.2007476714', data.message);

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