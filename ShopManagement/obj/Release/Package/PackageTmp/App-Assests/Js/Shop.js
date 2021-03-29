$(".ShopView").click(function () {
    $("#ShopInfo").modal("show");
});

$(".ShopEdit").click(function () {
    $("#EditShop").modal("show");
});

$(".ViewOwnerInfo").click(function () {
    $("#ViewOwnerInfo").modal("show");
});

$(".DeleteShop").click(function () {
    swal({
        title: 'Are you sure?',
        text: 'Once deleted, you will not be able to recover this Shop Details!',
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            swal('Poof! Your Shop has been deleted!', {
                icon: 'success',
            });
        } else {
            swal('Your Shop is safe!');
        }
    });
});