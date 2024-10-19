function handleDiscontinued(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this action!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, discontinue it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/Product/DiscontinuedProduct?productId=' + id;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'Product is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleContinue(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this action!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, continue it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/Product/ContinueProduct?productId=' + id;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'Product is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleUnlockUser(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you unlock this account?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'User is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleLockUser(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you lock this account?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'User is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleDeactiveSupplier(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you archive this supplier?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/Supplier/DeactiveSupplier?supplierId=' + id;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'Supplier is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleActiveSupplier(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you unarchive this supplier?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/Supplier/ActiveSupplier?supplierId=' + id;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'Supplier is safe for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handlePromoted(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you promoted this user?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'So sad this user can not be promoted for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}

function handleDemoted(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Will you demoted this user?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, just do it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
        if (!result.isConfirmed) {
            Swal.fire({
                title: 'Canceled',
                text: 'So sad this user can not be demoted for now :D',
                icon: 'error',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
        }
    });
}