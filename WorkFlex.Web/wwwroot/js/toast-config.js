function toast({
    title = '', 
    message = '', 
    type = 'info', 
    duration = 3000
}) {
    const main =document.getElementById('toast');

    const icons = ({
        success: 'fas fa-check-circle',
        info: 'fas fa-info-circle',
        warning: 'fas fa-exclamation-circle',
        danger: 'fas fa-times-circle'
    });

    const icon = icons[type];
    const delay = duration/1000;
    const autoEaseOut = duration + 1000;

    if(main) {
        const toast = document.createElement('div');

        // Auto Remove Toast
        const removeId = setTimeout(function(){
            main.removeChild(toast);
        }, autoEaseOut); 

        // Remove while clicking on Close Icon
        toast.onclick = function(event) {
            if(event.target.closest('.toast__close')) {
                main.removeChild(toast);
                clearTimeout(removeId);
            }
        }   

        toast.classList.add('my-toast', `toast--${type}`);
        toast.style.animation = `fadeIn ease .3s, fadeOut linear .3s ${delay}s forwards`;
        toast.innerHTML = `
                <div class="toast__icon">
                    <i class="${icon}"></i>
                </div>
                <div class="toast__body">
                    <h3 class="toast__title">${title}</h3>
                    <p class="toast__desc">${message}</p>
                </div>
                <div class="toast__close">
                    <i class="far fa-times-circle"></i>
                </div>
            </div>`;

        main.appendChild(toast);
    }
}


