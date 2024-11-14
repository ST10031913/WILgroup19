// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Preloader functionality
window.addEventListener("load", function () {
    const preloader = document.getElementById("preloader");
    setTimeout(() => {
        preloader.style.opacity = 0;
        setTimeout(() => {
            preloader.style.display = "none";
        }, 500);
    }, 1000);
});


// Media type toggle for Create and Edit views
document.addEventListener("DOMContentLoaded", function () {
    const mediaTypeDropdown = document.getElementById("mediaTypeDropdown");
    const videoUrlSection = document.getElementById("videoUrlSection");
    const imageUploadSection = document.getElementById("imageUploadSection");

    // Function to toggle the visibility based on selected media type
    function toggleMediaFields() {
        const isImage = mediaTypeDropdown.value === "Image";
        videoUrlSection.style.display = isImage ? "none" : "block";
        imageUploadSection.style.display = isImage ? "block" : "none";
    }

    // Initial toggle based on the current value
    toggleMediaFields();

    // Add event listener for dropdown change
    mediaTypeDropdown.addEventListener("change", toggleMediaFields);
});

function toggleMenu() {
    const sidebarMenu = document.getElementById("sidebarMenu");
    sidebarMenu.classList.toggle("show");
}

// Close sidebar when clicking outside
document.addEventListener('click', function (event) {
    const sidebarMenu = document.getElementById("sidebarMenu");
    const toggleButton = document.querySelector(".navbar-toggler");
    if (!sidebarMenu.contains(event.target) && !toggleButton.contains(event.target)) {
        sidebarMenu.classList.remove("show");
    }
});

