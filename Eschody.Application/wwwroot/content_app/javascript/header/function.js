document.querySelector('.icon-menu').addEventListener("click", function openMenu() {
    let MenuMobile = document.querySelector('.mobile-menu');
    if (MenuMobile.classList.contains('open')) {
        MenuMobile.classList.remove('open');
        document.querySelector('.mobile-menu-icon-icon').src = "Assets/content_app/menu_white_36dp.svg";
    }
    else {
        MenuMobile.classList.add('open');
        document.querySelector('.mobile-menu-icon-icon').src = "Assets/content_app/close_white_36dp.svg";
    }
});