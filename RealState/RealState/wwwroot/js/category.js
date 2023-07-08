
$(document).ready(function () {
    GetCategory();
});

function GetCategory() {
    $('#tb').DataTable({
        searching: false,
        processing: true,
        serverSide: true,
        lengthChange: false,
        ordering: false,

        ajax: {
            url: "/Category/GetCategory",
            type: "GET"
        },

        columnDefs: [
            {
                "targets": 0,
                "render": function (data, type, row) {
                    return ` <button type="submit" class="btn btn-outline-success btn-sm" onclick="window.location.href='/Category/Edit/${data}'" value=''>
                                                       <i class="fas fa-pencil-alt"></i>
                                                       Edit
                                                   </button>
                                                  <button type="submit" class="ml-sm-2 btn btn-outline-danger btn-sm" onclick="window.location.href='/Category/Delete/${data}'" value=''>
                                                     <i class="fas fa-minus-circle"></i>
                                                     Delete
                                                  </button>

                                 `;
                }
            }
        ]
    });
}