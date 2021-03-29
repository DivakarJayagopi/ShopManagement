$(".AddShopFromSubmit").click(function () {
    AddShop($(this));
});

var GlobalShopStatus = "";
$(".ShopStatus").change(function () {
    GlobalShopStatus = $(this).val();
});

function AddShop(target) {
    var ShopName = $(".ShopName").val().trim();
    var ShopArea = $(".ShopArea").val().trim();
    var ShopManager = $(".ShopManager").val();
    var ShopNotes = $(".ShopNotes").val().trim();
    var ShopMobileNumber = $(".ShopMobileNumber").val().trim();
    var MaxOrderCountForShop = $(".MaxOrderCountForShop").val().trim();
    var ShopStatus = GlobalShopStatus;

    if (ShopName == "" || ShopArea == "" || ShopMobileNumber == "" || MaxOrderCountForShop == "") {

        if (ShopName == "") $(".ShopName").addClass("form-error");
        else $(".ShopName").removeClass("form-error");

        if (ShopArea == "") $(".ShopArea").addClass("form-error");
        else $(".ShopArea").removeClass("form-error");

        if (ShopMobileNumber == "") $(".ShopMobileNumber").addClass("form-error");
        else $(".ShopMobileNumber").removeClass("form-error");

        if (MaxOrderCountForShop == "") $(".MaxOrderCountForShop").addClass("form-error");
        else $(".MaxOrderCountForShop").removeClass("form-error");

        $(".customErrorMessageAddShop").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $(".customErrorMessageAddShop").text("");
        var IsSuccess = true;

        if (ShopMobileNumber.length != 10) {
            $(".ShopMobileNumber").addClass("form-error");
            $(".customErrorMessageAddShop").text("Please enter valid mobile number");
            IsSuccess = false;
        } else {
            $(".ShopMobileNumber").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {
            $(".AddShopFromSubmit").addClass("btn-progress");

            if (ShopStatus == "") {
                ShopStatus = "active";
            }

            var data = '{Name:"' + ShopName + '", ShopArea:"' + ShopArea + '",UserId:"' + ShopManager + '",Image:"' + GlobalShopImage + '",Notes:"' + ShopNotes + '",Status:"' + ShopStatus + '",MobileNumber:"' + ShopMobileNumber + '",MaxOrderCount:"' + MaxOrderCountForShop + '"}';
            handleAjaxRequest(null, true, "/Method/AddShopInfo", data, "CallBackAddShopInfo");
        }
    }
}

function CallBackAddShopInfo(responseData) {
    if (responseData.message.status == "success") {
        $("input[type=\"text\"]").val('');
        $("input[type=\"number\"]").val('');
        $("input[type=\"file\"]").val('');
        swal('User Added Successfully');
    } else {
        swal('Error on Adding shop');
    }
    $(".AddShopFromSubmit").removeClass("btn-progress");
}

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

var GlobalShopImage = "";

function readFile() {
    if (this.files && this.files[0]) {
        var FR = new FileReader();
        FR.addEventListener("load", function (e) {
            GlobalShopImage = e.target.result;
        });
        FR.readAsDataURL(this.files[0]);
    }
}
document.getElementById("ShopImage").addEventListener("change", readFile);