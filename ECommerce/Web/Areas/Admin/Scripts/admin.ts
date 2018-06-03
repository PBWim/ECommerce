"use strict";

class admin {
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
            $('#adminLogin').submit(function (ev) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                else {
                    $('#emailVal').val($('#inputEmail').val());
                    $('#passwordVal').val($('#inputPassword').val());
                }
                form.classList.add('was-validated');
            });
        });
    }
}

let a = new admin();