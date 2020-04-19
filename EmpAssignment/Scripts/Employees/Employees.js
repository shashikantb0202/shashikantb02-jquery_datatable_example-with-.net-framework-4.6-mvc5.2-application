
//$(".delete-btn").on('click', function () {
//    ("#confirm-delete").modal('toggle');
//})
//$("span").on("click", ".delete-btn", function () {
//    ("#confirm-delete").modal('toggle');
//});
$(".delete-btn").on("click", function () {
    console.log($(this).text());
});
function getEmployeeList() {
    $('#EmployeeListContent').DataTable().clear().destroy();
    var oTable = $('#EmployeeListContent').dataTable({
        "bServerSide": true,
        oLanguage: {
            sProcessing: "<div class='preloader'></div>"
        },
        processing : true,
        "responsive": true,
        "searching": true,
        "ordering": true,
        "sAjaxSource": "/Employee/getEmployeeList",
        "sServerMethod": "POST",
        "aoColumns": [
        //{ "mData": "Id", "name": "Id" },
        { "mData": "Name", "name": "Name",  },
        { "mData": "Age", "name": "Age", },
        { "mData": "MaritalStatus", "name": "MaritalStatus", },
        { "mData": "Salary", "name": "Salary",  },
        { "mData": "Location", "name": "Location",  },


        {
            "mData": function (o) {

                return "<span data-emp-id=" + o.Id + " class='glyphicon glyphicon-trash delete-btn' style='cursor: pointer;' onClick=openConfirmationModal(" + o.Id + ")></span>";

            }, "ordering":false
        }
        ],
        aoColumnDefs: [
          {
              bSortable: false,
              aTargets: [-1]
          }
        ]
    });
}

$(document).ready(function () {
    getEmployeeList();
});

function openConfirmationModal(id) {
    
    $("#confirm-delete").modal('show');
    $("#EmployeeID").val(id);
}


