//delete department
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
//delete personal
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
//
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

function date_time(id) {
    date = new Date;
    year = date.getFullYear();
    month = date.getMonth();
    months = new Array('January', 'February', 'March', 'April', 'May', 'June', 'Jully', 'August', 'September', 'October', 'November', 'December');
    d = date.getDate();
    day = date.getDay();
    days = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
    h = date.getHours();
    if (h < 10) {
        h = "0" + h;
    }
    m = date.getMinutes();
    if (m < 10) {
        m = "0" + m;
    }
    s = date.getSeconds();
    if (s < 10) {
        s = "0" + s;
    }
    result = '' + days[day] + ' ' + months[month] + ' ' + d + ' ' + year + ' ' + h + ':' + m + ':' + s;
    document.getElementById(id).innerHTML = result;
    setTimeout('date_time("' + id + '");', '1000');
    return true;
}