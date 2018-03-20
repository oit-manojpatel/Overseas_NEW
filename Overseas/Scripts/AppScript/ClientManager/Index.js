$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

function Save() {
    var url = 'add';
    $.post(url, {}, function (res) {
        $('#clientadd').html(res);
    });
    $('#AddModal').modal('show');
}
function Edit(clientId) {
    var url = 'Edit';
    $.post(url, { Id: clientId }, function (res) {
        $('#clientEdit').html(res);
    });
    $('#EditModal').modal('show');
}

function Details(clientId) {
    var url = 'Details';
    $.post(url, { Id: clientId }, function (res) {
        $('#clientDetails').html(res);
    });
    $('#DetailModal').modal('show');
}

function Delete(Id) {

    bootbox.confirm("Are you sure want to delete?", function (res) {
        if (res) {
            $.ajax({
                url: "/ClientManager/Delete/" + Id,
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (res) {
                    if (res == "ok") {
                      //  alert("Record is deleted");                        
                    }
                    window.location.href = "Index";
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });

        }
    });
}