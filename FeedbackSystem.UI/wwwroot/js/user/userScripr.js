
function createUser() {
    var addForm = document.getElementById('addForm');
    var username = document.getElementById('usernameId').value;
    var email = document.getElementById('emailId').value;
    var password = document.getElementById('passwordId').value;
    var confirmPassword = document.getElementById('confirmPasswordId').value;
    var role = document.getElementById('roleId').value;
    var activation = document.getElementById('formGroupDefaultSelect').value;
    if (addForm.checkValidity()) {
        if (username === '' || email === '' || password === '' || role === '' || confirmPassword === '' || activation === '') {

            document.getElementById('dangerAlert').hidden = false;
        } else {
            if (password != confirmPassword) {
                swal('The password Doesnt matches the confirm password', {
                    icon: "error",
                    buttons: {
                        confirm: {
                            className: 'btn btn-error'
                        }
                    },
                });
            }

            else {

                var registrationForm = document.getElementById('addForm');
                var passwordInput = document.getElementById('passwordId');
                var confirmPasswordInput = document.getElementById('confirmPasswordId');
                var passwordError = document.getElementById('passwordError');
                var confirmPasswordError = document.getElementById('confirmPasswordError');

                var password = passwordInput.value.trim();
                var confirmPassword = confirmPasswordInput.value.trim();

                // Reset errors
                passwordError.textContent = '';
                confirmPasswordError.textContent = '';

                // Check if passwords are empty
                if (password === '') {
                    passwordError.textContent = 'Password is required';
                    return false;
                }
                // Check if password contains at least one digit, one lowercase letter, one uppercase letter, and one special character
                var passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]).{6,}$/;
                if (!passwordPattern.test(password)) {
                    passwordError.textContent = 'Password must contain at least one digit, one lowercase letter, one uppercase letter, and one special character';
                    return false;
                }

                if (confirmPassword === '') {
                    confirmPasswordError.textContent = 'Please confirm your password';
                    return false;
                }

                // Check if passwords match
                if (password !== confirmPassword) {
                    confirmPasswordError.textContent = 'Passwords do not match';
                    return false;
                }

                // Check password length
                if (password.length < 6) {
                    passwordError.textContent = 'Password must be at least 6 characters long';
                    return false;
                }
                $.ajax({
                    type: 'POST', url: "/Admin/Users/Create", data: {
                        username: username,
                        email: email,
                        password: password,
                        role: role,
                        activation: activation
                    }, success: function () {
                        // Reload the page or update the UI as needed

                        swal("User Successfully Created!", {
                            icon: "success",
                            buttons: {
                                confirm: {
                                    className: 'btn btn-success'
                                }
                            },
                        }).then(
                            function () {
                                window.location.reload();
                            });
                    }, error: function (error) {
                        swal('Something Went Wrong!', {
                            icon: "error",
                            buttons: {
                                confirm: {
                                    className: 'btn btn-error'
                                }
                            },
                        }).then(
                            function () {
                                window.location.reload();
                            });
                    }
                });
                return true;

            }


            username = '';
            email = '';
            password = '';
            confirmPassword = '';

        }
    } else {
        addForm.reportValidity();
    };

}
$(document).ready(function () {
    $('#basic-datatables').DataTable({
    });

    $('#multi-filter-select').DataTable({
        "pageLength": 5,
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select class="form-control"><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        }
    });

    // Add Row
    $('#add-row').DataTable({
        "pageLength": 5,
    });

    var action = '<td> <div class="form-button-action"> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-primary btn-lg" data-original-title="Edit Task"> <i class="fa fa-edit"></i> </button> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-danger" data-original-title="Remove"> <i class="fa fa-times"></i> </button> </div> </td>';


});

function editUser(Id) {
    var username = document.getElementById(`username-${Id}`).value;
    var email = document.getElementById(`email-${Id}`).value;
    var role = document.getElementById(`role-${Id}`).value;
    var activation = document.getElementById(`activation-${Id}`).value;
    var editForm = document.getElementById('editForm');
    if (editForm.checkValidity()) {
        if (username === '' || email === '' || role === '' || activation === '') {

            document.getElementById('dangerAlert').hidden = false;
        } else {
            $.ajax({
                type: 'POST', url: "/Admin/Users/Edit", data: {
                    Id: Id,
                    username: username,
                    email: email,
                    role: role,
                    activation: activation
                }, success: function () {
                    // Reload the page or update the UI as needed

                    swal("User Successfully Edited!", {
                        icon: "success",
                        buttons: {
                            confirm: {
                                className: 'btn btn-success'
                            }
                        },
                    }).then(
                        function () {
                            window.location.reload();
                        });
                }, error: function (error) {
                    swal('Something Went Wrong!', {
                        icon: "error",
                        buttons: {
                            confirm: {
                                className: 'btn btn-error'
                            }
                        },
                    }).then(
                        function () {
                            window.location.reload();
                        });
                }
            });

        }
    } else {
        editForm.reportValidity();
    };

}

function deleteUserFunc(Id) {
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        buttons: {
            cancel: {
                visible: true,
                text: 'No, cancel!',
                className: 'btn btn-success'
            },
            confirm: {
                text: 'Yes, delete it!',
                className: 'btn btn-danger'
            }
        }
    }).then((willDelete) => {


        if (willDelete) {
            $.ajax({
                type: 'POST', url: "/Admin/Users/Delete", data: {
                    Id: Id
                }, success: function () {
                    window.location.reload();
                }, error: function (error) {

                }
            });
            swal("Poof! Your imaginary file has been deleted!", {
                icon: "success",
                buttons: {
                    confirm: {
                        className: 'btn btn-success'
                    }
                }
            });
        } else {
            swal("Your imaginary file is safe!", {
                buttons: {
                    confirm: {
                        className: 'btn btn-success'
                    }
                }
            });
        }
    });
}