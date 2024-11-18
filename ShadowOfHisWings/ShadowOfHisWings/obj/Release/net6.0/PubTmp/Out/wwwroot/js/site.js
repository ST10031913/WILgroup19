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


/// Media type toggle for Create and Edit views
document.addEventListener("DOMContentLoaded", function () {
    const mediaTypeDropdown = document.getElementById("mediaTypeDropdown");
    const videoUrlSection = document.getElementById("urlField");
    const imageUploadSection = document.getElementById("imageField");
    const categoryField = document.getElementById("categoryField");

    if (mediaTypeDropdown && videoUrlSection && imageUploadSection && categoryField) {
        function toggleMediaFields() {
            const isImage = mediaTypeDropdown.value === "Image";
            const isVideo = mediaTypeDropdown.value === "Video";

            // Adjust visibility of sections based on the selected media type
            videoUrlSection.style.display = isVideo ? "block" : "none";
            imageUploadSection.style.display = isImage || isVideo ? "block" : "none";
            categoryField.style.display = isImage ? "block" : "none";
        }

        // Initial field state
        toggleMediaFields();

        // Listen for changes in the dropdown
        mediaTypeDropdown.addEventListener("change", toggleMediaFields);
    }
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

