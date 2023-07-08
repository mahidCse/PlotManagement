

$(document).ready(function () {
    $.ajax({
        url: '/Department/FindDepartmentList',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#account').append('<option value=' + data.id + '>' + data.name + '</option > ')
            });
        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: '/Category/FindCategoryList',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#category').append('<option value=' + data.id + '>' + data.name + '</option > ')
            });
        }
    });
});