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
	const dt = $('#add-row').DataTable({
		"pageLength": 5,
	});

	var action = '<td> <div class="form-button-action"> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-primary btn-lg" data-original-title="Edit Task"> <i class="fa fa-edit"></i> </button> <button type="button" data-toggle="tooltip" title="" class="btn btn-link btn-danger" data-original-title="Remove"> <i class="fa fa-times"></i> </button> </div> </td>';

	$(document).on("click", "#filterButton", function (e) {
		var filter = $(this).attr("data-filter");
		
		//dt.column(6).search("").draw();
		dt.column(6).search(filter).draw();

		//console.log(dt.column(6));
	});
});

function editFeedback(Id) {
	var responseType = document.getElementById(`responseType-${Id}`).value;
	var responseNote = document.getElementById(`responseNote-${Id}`).value;


	if (responseType === '' || responseNote === '') {

		document.getElementById('dangerEditAlert').hidden = false;
	} else {
		$.ajax({
			type: 'POST', url: "/Admin/Tickets/Edit", data: {
				responseType: responseType,
				responseNote: responseNote,
				Id: Id
			}, success: function () {
				// Reload the page or update the UI as needed

				swal("Feedback Successfully Updated", {
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

// This will create a single gallery from all elements that have class "gallery-item"
$('.image-gallery').magnificPopup({
	delegate: 'a',
	type: 'image',
	removalDelay: 300,
	gallery: {
		enabled: true,
	},
	mainClass: 'mfp-with-zoom',
	zoom: {
		enabled: true,
		duration: 300,
		easing: 'ease-in-out',
		opener: function (openerElement) {
			return openerElement.is('img') ? openerElement : openerElement.find('img');
		}
	}
});