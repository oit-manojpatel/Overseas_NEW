

$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});
function Create() {
    var url = '@Url.Action("AddEmail","Email")';
    $.post(url, {}, function (res) {
        $('#EmailAdd').html(res);
    });
    $('#EmailModal').modal('show')

}
function Edit(ID) {
    var url = '@Url.Action("Edit", "Email")';
    $.post(url, { Id: ID }, function (res) {
        $('#EmailEdit').html(res);
    });
    $('#EmailEditModal').modal('show')
}
function Delete(Id) {
    bootbox.confirm("Are you sure want to delete?", function (result) {
        var url = '@Url.Action("Delete","Email")';
        $.post(url, { Id: Id }, function (data) {
            if (data == 'ok') {
                alert('Record Deleted Successfully');
                window.location = '@Url.Action("Index","Email")';
            }
        });
    });
}
