$(".AddShopFromSubmit").click(function () {
    AddShop($(this));
});

var GlobalShopStatus = "";
$(".ShopStatus,.SelectedShopStatus").change(function () {
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

    if (ShopName == "" || ShopArea == "" || ShopMobileNumber == "" || MaxOrderCountForShop == "" || ShopManager == "") {

        if (ShopName == "") $(".ShopName").addClass("form-error");
        else $(".ShopName").removeClass("form-error");

        if (ShopArea == "") $(".ShopArea").addClass("form-error");
        else $(".ShopArea").removeClass("form-error");

        if (ShopMobileNumber == "") $(".ShopMobileNumber").addClass("form-error");
        else $(".ShopMobileNumber").removeClass("form-error");

        if (MaxOrderCountForShop == "") $(".MaxOrderCountForShop").addClass("form-error");
        else $(".MaxOrderCountForShop").removeClass("form-error");

        if (ShopManager == "") $(".ShopManager").addClass("form-error");
        else $(".ShopManager").removeClass("form-error");

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
        swal('Shop Added Successfully');
    } else {
        swal('Error on Adding shop');
    }
    $(".AddShopFromSubmit").removeClass("btn-progress");
}

$(".ShopEdit").click(function () {
    var ShopId = $(this).attr("data-id");
    var data = '{Id:"' + ShopId + '"}';
    handleAjaxRequest(null, true, "/Method/GetShopInfoById", data, "CallBackGetShopInfoById");    
});

function CallBackGetShopInfoById(responseData) {
    if (responseData.message.status == "success") {
        var ShopInfo = responseData.message.shopInfo;
        var UsersList = responseData.message.usersList;
        var ShopConnecteduserId = responseData.message.ShopConnecteduserId;
        if (UsersList != null && UsersList.length > 0) {
            var OptionHTML = "";
            $.each(UsersList, function (key, val) {
                OptionHTML += "<option value='"+val.Id+"'>" + val.Name + "</option>";
            });
            $(".SelectedShopManager").html(OptionHTML)
        }
        $(".SelectedShopId").val(ShopInfo.Id);
        $(".SelectedShopName").val(ShopInfo.Name);
        $(".SelectedShopArea").val(ShopInfo.ShopArea);
        $(".SelectedShopMobileNumber").val(ShopInfo.MobileNumber);
        $(".SelectedMaxOrderCountForShop").val(ShopInfo.MaxOrderCount);
        $(".SelectedShopNotes").val(ShopInfo.Notes);

        $(".SelectedShopManager").val(ShopConnecteduserId);

        $(".SelectedShopNameModelTitle").text(ShopInfo.Name);
        if (ShopInfo.Status == "active") {
            $(".SelectedShopStatus[value=\"active\"]").trigger("click");
        } else {
            $(".SelectedShopStatus[value=\"inactive\"").trigger("click");
        }
        $("#EditShop").modal("show");
    }
}

$(".UpdateShopFromSubmit").click(function () {
    UpdateShopInfo($(this));
});

function UpdateShopInfo(target) {
    var ShopId = $(".SelectedShopId").val();
    var ShopName = $(".SelectedShopName").val().trim();
    var ShopArea = $(".SelectedShopArea").val().trim();
    var ShopManager = $(".SelectedShopManager").val();
    var ShopNotes = $(".SelectedShopNotes").val().trim();
    var ShopMobileNumber = $(".SelectedShopMobileNumber").val().trim();
    var MaxOrderCountForShop = $(".SelectedMaxOrderCountForShop").val().trim();
    var ShopStatus = GlobalShopStatus;

    if (ShopName == "" || ShopArea == "" || ShopMobileNumber == "" || MaxOrderCountForShop == "") {

        if (ShopName == "") $(".SelectedShopName").addClass("form-error");
        else $(".SelectedShopName").removeClass("form-error");

        if (ShopArea == "") $(".SelectedShopArea").addClass("form-error");
        else $(".SelectedShopArea").removeClass("form-error");

        if (ShopMobileNumber == "") $(".SelectedShopMobileNumber").addClass("form-error");
        else $(".SelectedShopMobileNumber").removeClass("form-error");

        if (MaxOrderCountForShop == "") $(".SelectedMaxOrderCountForShop").addClass("form-error");
        else $(".SelectedMaxOrderCountForShop").removeClass("form-error");

        $(".customErrorMessageAddShop").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $(".customErrorMessageAddShop").text("");
        var IsSuccess = true;

        if (ShopMobileNumber.length != 10) {
            $(".SelectedShopMobileNumber").addClass("form-error");
            $(".customErrorMessageAddShop").text("Please enter valid mobile number");
            IsSuccess = false;
        } else {
            $(".SelectedShopMobileNumber").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {
            $(".UpdateShopFromSubmit").addClass("btn-progress");

            if (ShopStatus == "") {
                ShopStatus = "active";
            }

            var data = '{Id:"' + ShopId + '", Name:"' + ShopName + '", ShopArea:"' + ShopArea + '",UserId:"' + ShopManager + '",Image:"' + GlobalShopImage + '",Notes:"' + ShopNotes + '",Status:"' + ShopStatus + '",MobileNumber:"' + ShopMobileNumber + '",MaxOrderCount:"' + MaxOrderCountForShop + '"}';
            handleAjaxRequest(null, true, "/Method/UpdateShopInfo", data, "CallBackUpdateShopInfo");
        }
    }
}

function CallBackUpdateShopInfo(responseData) {
    $(".UpdateShopFromSubmit").removeClass("btn-progress");
    if (responseData.message.status == "success") {
        $("#EditShop").modal("hide");
        var ShopInfo = responseData.message.ShopInfo;
        var ShopId = ShopInfo.Id;

        var ShopConnected_UserInfo = responseData.message.ShopConnectedUserInfo;
        $(".ShopImageExpand[data-id='" + ShopId + "']").attr("src", ShopInfo.Image);

        $(".ShopName[data-id='" + ShopId + "']").text(ShopInfo.Name);
        $(".ShopArea[data-id='" + ShopId + "']").text(ShopInfo.ShopArea);
        $(".ShopMobileNumber[data-id='" + ShopId + "']").text(ShopInfo.MobileNumber);
        $(".MaxOrderCountForShop[data-id='" + ShopId + "']").text(ShopInfo.MaxOrderCount);

        $(".ShopListCardStatus[data-id='" + ShopId + "']").removeClass("card-danger");
        $(".ShopListCardStatus[data-id='" + ShopId + "']").removeClass("card-success");
        if (ShopInfo.Status == "active")
            $(".ShopListCardStatus[data-id='" + ShopId + "']").addClass("card-success");
        else
            $(".ShopListCardStatus[data-id='" + ShopId + "']").addClass("card-danger");

        $(".ShopManagerImageExpand[data-id='" + ShopId + "']").attr("href", ShopConnected_UserInfo.Image);
        $(".ShopManagerImage[data-id='" + ShopId + "']").attr("src", ShopConnected_UserInfo.Image);

        $(".ShopManagerName[data-shopId='" + ShopId + "']").text(ShopConnected_UserInfo.Name);

        iziToast.success({
            title: 'success',
            message: 'Shop Informatino Updated Successfully',
            position: 'topCenter'
        });

        
    } else {
        $(".customErrorMessageAddShop").text("Error on updating Shop info");
    }
}

$(".ShopManagerName").click(function () {
    var UserId = $(this).attr("data-id");
    var data = '{Id:"' + UserId + '"}';
    handleAjaxRequest(null, true, "/Method/GetUserById", data, "CallBackGetUserInfoByIdInShopsList");   
});

function CallBackGetUserInfoByIdInShopsList(responseData) {
    if (responseData.message.status == "success") {
        var UserInfo = responseData.message.userInfo;
        $(".ShopOwnerName").text(UserInfo.Name);
        $(".UserEmailId").text(UserInfo.EmailId);
        $(".UserMobileNumber").text(UserInfo.MobileNumber);
        $(".UserArea").text(UserInfo.Area);

        $(".ShopManagerImageInModel").attr("src", UserInfo.Image);

        $("#ViewOwnerInfo").modal("show");
    }
}

$(".DeleteShop").click(function () {
    var ShopId = $(this).attr("data-id");
    var ShopName = $(this).attr("data-UserName");
    var ShopInfo = [];
    ShopInfo.push(ShopId);
    ShopInfo.push(ShopName);
    swal({
        title: 'Are you sure?',
        text: 'Once deleted, you will not be able to recover this Shop Details!',
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            var data = '{Id:"' + ShopId + '"}';
            handleAjaxRequest(null, true, "/Method/DeleteShopById", data, "CallBackDeleteShopById", ShopInfo);            
        }
    });
});

function CallBackDeleteShopById(responseData, ShopInfo) {
    if (responseData.message.status == "success") {
        var ShopId = ShopInfo[0];

        iziToast.success({
            title: 'Poof! ',
            message: ShopInfo[1] + ' has been deleted!',
            position: 'topCenter'
        });

        $(".ShopList[data-id='" + ShopId + "']").remove();

        var ShopsCardList = $(".ShopListCardStatus").length;
        if (ShopsCardList <= 0) {
            var NoData = '<div class="col-md-12"><div class="card card-warning"><div class="card-header"><h4>No Data Found !</h4></div><div class="card-body" style="text-align:center;"><p>Add Shops to see the list here.. <i><b><a href="@Url.Action("AddShop", "Shop")">Add Shop</a></b></i></p></div></div></div>';
            $(".AllShopsList").html(NoData);
        }
    }
}

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