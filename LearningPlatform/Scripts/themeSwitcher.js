document.addEventListener("DOMContentLoaded", function () {
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme) {
        document.body.className = savedTheme;
    }

    document.querySelectorAll(".theme-button").forEach(button => {
        button.addEventListener("click", function () {
            const theme = this.dataset.theme;
            document.body.className = theme;
            localStorage.setItem("theme", theme);
        });
    });
});
