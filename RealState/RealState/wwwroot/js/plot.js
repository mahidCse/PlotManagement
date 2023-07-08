$(document).ready(function () {
    GetBlock();
});

function GetBlock() {
    $.ajax({
        url: '/Block/FindBlockList',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Block').append('<option value=' + data.id + '>' + data.name + '</option > ')
            });
        }
    });
}