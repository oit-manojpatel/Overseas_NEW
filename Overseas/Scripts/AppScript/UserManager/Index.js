$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});


function Edit(userId) {
    var url = 'Edit';
    $.post(url, { userId: userId }, function (res) {

        $('#datashow').html(res);
    });
    $('#myModal').modal('show')

}
function Create() {
    var url = 'Create';
    $.post(url, {}, function (res) {
        $('#addUser').html(res);
    });
    $('#addmodel').modal('show')
}
function Delete(Id) {

    bootbox.confirm("Are you sure want to delete?", function (res) {
        if (res) {
            $.ajax({
                url: "/UserManager/Delete/" + Id,
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