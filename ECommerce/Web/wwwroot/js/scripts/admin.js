var admin = /** @class */ (function () {
    function admin() {
        this.init();
    }
    admin.prototype.init = function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    };
    return admin;
}());
var a = new admin();