$(document).ready(function () {
    GetBlock();
    GetCustomer();
    $('#Block').change(function () {
        var id = $(this).val();
        $('#Plot').empty();
        $('#Plot').append(' <option>--Select Plot--</option>')
        $.ajax({
            url: '/Plot/FindPlotByBlockId?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Plot').append('<option value=' + data.id + '>' + data.plotNumber + '</option > ')
                });
            }
        });

    });
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

function GetCustomer() {
    $.ajax({
        url: '/Customer/FindCustomer',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Customer').append('<option value=' + data.id + '>' + data.name + '</option > ')
            });
        }
    });
}
