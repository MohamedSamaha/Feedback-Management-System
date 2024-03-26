function createFloor() {
	var floorNameEn = document.getElementById('floorNameEnId').value;
	var floorNameAr = document.getElementById('floorNameArId').value;
	var activation = document.getElementById('formGroupDefaultSelect').value;

	if (floorNameEn === '' || floorNameAr === '' || activation === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Admin/Floor/Create", data: {
				floorNameEn: floorNameEn,
				floorNameAr: floorNameAr,
				activation: activation
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Floor Successfully Created!", {
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

		floorNameEn = '';
		floorNameAr = '';

	}
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

function editFloor(Id) {
	var floorNameInEnglish = document.getElementById(`floorNameEn-${Id}`).value;
	var floorNameInArabic = document.getElementById(`floorNameAr-${Id}`).value;
	var floorActivation = document.getElementById(`activation-${Id}`).value;
	if (floorNameInEnglish === '' || floorNameInArabic === '' || floorActivation === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Admin/Floor/Edit", data: {
				Id: Id,
				floorNameInEnglish: floorNameInEnglish,
				floorNameInArabic: floorNameInArabic,
				floorActivation: floorActivation
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Floor Successfully Edited!", {
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
}

function deleteFloorFunc(Id) {
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
				type: 'POST', url: "/Admin/Floor/Delete", data: {
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