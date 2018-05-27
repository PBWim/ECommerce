"use strict";

class admin {
    constructor() {
        a.init();
    }
    init() {
        a.formSubmitValidation();
    }
    formSubmitValidation() {
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
    }
}

let a = new admin();