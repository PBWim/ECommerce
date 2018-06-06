"use strict";
var adminSetup = /** @class */ (function () {
    function adminSetup() {
        var self = this;
        self.init();
    }
    adminSetup.prototype.init = function () {
        var self = this;
        self.formSubmitValidation();
    };
    adminSetup.prototype.formSubmitValidation = function () {
        var forms = $('.needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            $('#addNewAdminForm').submit(function (ev) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            });
        });
    };
    return adminSetup;
}());
var aS = new adminSetup();
