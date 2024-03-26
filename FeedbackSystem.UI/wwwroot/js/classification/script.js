function createClassification() {
	var classificationNameEn = document.getElementById('classificationNameEnId').value;
	var classificationNameAr = document.getElementById('classificationNameArId').value;
	var activation = document.getElementById('formGroupDefaultSelect').value;

	if (classificationNameEn === '' || classificationNameAr === '' || activation === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Admin/Classification/Create", data: {
				classificationNameEn: classificationNameEn,
				classificationNameAr: classificationNameAr,
				activation: activation
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Classification Successfully Created!", {
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

		classificationNameEn = '';
		classificationNameAr = '';

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

function editClassification(Id) {
	var classificationNameInEnglish = document.getElementById(`classificationNameEn-${Id}`).value;
	var classificationNameInArabic = document.getElementById(`classificationNameAr-${Id}`).value;
	var classificationActivation = document.getElementById(`activation-${Id}`).value;
	if (classificationNameInEnglish === '' || classificationNameInArabic === '' || classificationActivation === '') {

		document.getElementById('dangerAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Admin/Classification/Edit", data: {
				Id: Id,
				classificationNameInEnglish: classificationNameInEnglish,
				classificationNameInArabic: classificationNameInArabic,
				classificationActivation: classificationActivation
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Classification Successfully Edited!", {
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

function deleteClassificationFunc(Id) {
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
				type: 'POST', url: "/Admin/Classification/Delete", data: {
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