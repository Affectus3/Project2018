$(function () {
    $("#tblDepartments").DataTable();
    $("#tblDepartments").on("click", ".btnDepartmentDelete", function () {
        var btn = $(this);
        bootbox.confirm("Are you sure you want to delete this department?", function (result) {
            if (result) {              
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Department/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                })
            }
        })
    });
});
$(function () {
    $("#tblPersonals").DataTable();
    $("#tblPersonals").on("click", ".btnPersonalDelete", function () {
        var btn = $(this);
        bootbox.confirm("Are you sure you want to delete this personal?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Personal/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                })
            }
        })
    });
});


function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if(value == '')
    {
        $(dateElement).valid("false");
    }
    else
    {
        $(dateElement).valid();
    }
}

