// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('selectAll').addEventListener('change', function () {
    var checkboxes = document.querySelectorAll('#hobbies input[type="checkbox"]');
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = this.checked;
    }
});

document.getElementById('hobbies').addEventListener('click', function (event) {
    var dropdownList = this.querySelector('.dropdown-list');
    if (!dropdownList.contains(event.target)) {
        dropdownList.style.display = 'none';
        this.classList.remove('open');
    }
});

document.getElementById('hobbies').addEventListener('focusin', function () {
    this.classList.add('open');
});

document.getElementById('hobbies').addEventListener('focusout', function () {
    this.classList.remove('open');
});
