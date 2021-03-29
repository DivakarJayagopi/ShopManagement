$(".ViewUserInfo").click(function () {
    $("#UserInfo").modal("show");
});

$(".EditUserInfo").click(function () {
    $("#EditUserInfo").modal("show");
});

$(".ViewShopInfo").click(function () {
    $("#ViewShopInfo").modal("show");
});

$(".DeleteUser").click(function () {
    swal({
        title: 'Are you sure?',
        text: 'Once deleted, you will not be able to recover this User Details!',
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            swal('Poof! Your User has been deleted!', {
                icon: 'success',
            });
        } else {
            swal('Your User is safe!');
        }
    });
});