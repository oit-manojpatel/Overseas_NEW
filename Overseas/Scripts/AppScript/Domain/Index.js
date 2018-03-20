function Create() {
    var url = 'adddomain';
    $.post(url, {}, function (res) {
        $('#addomain').html(res);
    });
    $('#domainmodel').modal('show')
}
function Edit(domainId) {

    var url = 'Editdomain';
    $.post(url, { Id: domainId }, function (res) {
        $('#Editdomain').html(res);
    });
    $('#Editmodel').modal('show')
}
function Delete(Id) {
    bootbox.confirm("Are you sure want to delete?", function () {
        var url = '~/Domain/Delete';
        $.post(url, { Id: Id }, function (data) {
            if (data == 'ok') {
                alert('Record Deleted Successfully');
                window.location = 'Index';
            }
        });
    });
}