function createPlace() {
    var createPlaceForm = document.getElementById('createPlaceForm');
    var building = document.getElementById('building').value;
    var wing = document.getElementById('wing').value;
    var placeType = document.getElementById('placeType').value;
    var floorNumber = document.getElementById('floorNumber').value;
    var placeCode = document.getElementById('placeCode').value;
    var activation = document.getElementById('formGroupDefaultSelect').value;
    var placeDescription = document.getElementById('placeDescription').value;
    if (createPlaceForm.checkValidity()) {
        if (building === '' || wing === '' || placeType === '' || floorNumber === '' || placeCode === '' || activation === '' || placeDescription === '') {

            document.getElementById('dangerAlert').hidden = false;
        } else {

            $.ajax({
                type: 'POST', url: "/Admin/Places/Create", data: {
                    building: building,
                    wing: wing,
                    placeType: placeType,
                    floorNumber: floorNumber,
                    placeCode: placeCode,
                    placeDescription: placeDescription,
                    activation: activation
                }, success: function () {
                    // Reload the page or update the UI as needed

                    swal("Place Successfully Created!", {
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
                    swal('Something Went Wrong! Please insure that place name is unique', {
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

            building = '';
            wing = '';
            placeType = '';
            floorNumber = '';
            placeCode = '';
            activation = '';
            placeDescription = '';
        }
    } else {
        createPlaceForm.reportValidity();
    };
}

function editPlaceFunc(Id) {
    var createPlaceForm = document.getElementById(`createPlaceForm-${Id}`);
    var building = document.getElementById(`building-${Id}`).value;
    var wing = document.getElementById(`wing-${Id}`).value;
    var placeType = document.getElementById(`placeType-${Id}`).value;
    var floorNumber = document.getElementById(`floorNumber-${Id}`).value;
    var placeCode = document.getElementById(`placeCode-${Id}`).value;
    var activation = document.getElementById(`formGroupDefaultSelect-${Id}`).value;
    var placeDescription = document.getElementById(`placeDescription-${Id}`).value;
    if (createPlaceForm.checkValidity()) {
        if (building === '' || wing === '' || placeType === '' || floorNumber === '' || placeCode === '' || activation === '' || placeDescription === '') {

            document.getElementById('dangerAlert').hidden = false;
        } else {

            $.ajax({
                type: 'POST', url: "/Admin/Places/Edit", data: {
                    Id: Id,
                    building: building,
                    wing: wing,
                    placeType: placeType,
                    floorNumber: floorNumber,
                    placeCode: placeCode,
                    placeDescription: placeDescription,
                    activation: activation
                }, success: function () {
                    // Reload the page or update the UI as needed

                    swal("Place Successfully Created!", {
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
        createPlaceForm.reportValidity();
    };
};
function deletePlaceFunc(Id) {
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
                type: 'POST', url: "/Admin/Places/Delete", data: {
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

function printQrFunc(Id) {
    /*var qr = new QRCode(document.getElementById("qrcode"), `https://localhost:44343/feedback/${Id}/create`);*/
    //console.log(`${window.location.protocol}//${window.location.host}/feedback/${Id}/create`);
    generate(`${window.location.protocol}//${window.location.host}/feedback/${Id}/create`, Id)
}


function generate(user_input, Id) {

    document.querySelector(`.qr-code-${Id}`).style = "";
    var qrcode = new QRCode(document.querySelector(`.qr-code-${Id}`), {
        text: `${user_input}`,
        width: 180, //128
        height: 180,
        colorDark: "#000000",
        colorLight: "#ffffff",
        correctLevel: QRCode.CorrectLevel.H
    });
    

    /*document.querySelector(".qr-code").appendChild(download);*/

    let download_link = document.getElementById("downloadQr");
    download_link.setAttribute("download", "qr_code_linq.png");
    download_link.innerText = "Download Qr";
    

    if (document.querySelector((`.qr-code-${Id} img`)).getAttribute("src") == null) {
        setTimeout(() => {
            download_link.setAttribute("href", `${document.querySelector("canvas").toDataURL()}`);
        }, 300);
    } else {
        setTimeout(() => {
            download_link.setAttribute("href", `${document.querySelector(".qr-code img").getAttribute("src")}`);
        }, 300);
    }

}
