"use strict";
var admin = /** @class */ (function () {
    function admin() {
        var self = this;
        self.init();
    }
    admin.prototype.init = function () {
        var self = this;
        self.formSubmitValidation();
    };
    admin.prototype.formSubmitValidation = function () {
        var forms = $('.needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            $('#adminLogin').submit(function (ev) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            });
        });
    };
    return admin;
}());
var a = new admin();
