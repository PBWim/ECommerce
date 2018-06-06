"use strict";

class adminSetup {
    constructor() {
        var self = this;
        self.init();
    }
    init() {
        var self = this;
        self.formSubmitValidation();
    }
    formSubmitValidation() {
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
    }
}

let aS = new adminSetup();