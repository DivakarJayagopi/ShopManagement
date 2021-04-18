$(".ViewOrderInfo").click(function () {
    var OrderId = $(this).attr("data-id");
    var data = '{Id:"' + OrderId + '"}';
    handleAjaxRequest(null, true, "/Method/GetOrderInfoById", data, "CallBackViewOrderInfoById");
});

function CallBackViewOrderInfoById(responseData) {
    if (responseData.message.status == "success") {
        var OrderInfo = responseData.message.orderInfo;
        $(".CustomerName").text(OrderInfo.CustomerName);

    }
}

$(".EditOrderInfo").click(function () {
    var OrderId = $(this).attr("data-id");
    var data = '{Id:"' + OrderId + '"}';
    handleAjaxRequest(null, true, "/Method/GetOrderInfoById", data, "CallBackGetOrderInfoById");
    
});

function CallBackGetOrderInfoById(responseData) {
    if (responseData.message.status == "success") {
        $("input[type=\"text\"]").val('');
        $("textarea").val('');
        var OrderInfo = responseData.message.orderInfo;
        $(".CustomerName").text(OrderInfo.CustomerName);
        $(".OrderId").val(OrderInfo.Id);
        $("#CustomerName").val(OrderInfo.CustomerName);
        $("#CustomerMobileNumber").val(OrderInfo.CustomerMobileNumber);
        $("#SelctedShopId").val(OrderInfo.ShopId);
        $("#OrderAmount").val(OrderInfo.Amount);
        $("#OrderNotes").val(OrderInfo.Notes);
        $("#OrderStartDate").attr("value", OrderInfo.StartDateInString);
        $("#OrderEndDate").attr("value", OrderInfo.EndDateInString);
        Global_OrderStatus = OrderInfo.Status;
        switch (OrderInfo.Status) {
            case "awaiting":
                $(".awaiting.OrderStatus").trigger("click");
                break;
            case "inprogress":
                $(".inprogress.OrderStatus").trigger("click");
                break;
            case "completed":
                $(".completed.OrderStatus").trigger("click");
                break;
            case "dropped":
                $(".dropped.OrderStatus").trigger("click");
                break;
        }

        var SafariInfo = OrderInfo.SafariInfo;
        var PantInfo = OrderInfo.PantInfo;
        var ShirtInfo = OrderInfo.ShirtInfo;

        $(".AddSafariInfoButton,.AddPantInfoButton,.AddShirtInfoButton").removeClass("btn-success");
        $(".AddSafariInfoButton,.AddPantInfoButton,.AddShirtInfoButton").addClass("disabled");
        $(".AddSafariInfoButton,.AddPantInfoButton,.AddShirtInfoButton").addClass("btn-warning");

        if (typeof (SafariInfo) != "undefined" && SafariInfo != null && typeof (SafariInfo.Id) != "undefined" && SafariInfo.Id != null) {
            $("#SafariLength").val(SafariInfo.Length);
            $("#SafariShoulder").val(SafariInfo.Shoulder);
            $("#SafariS_Length").val(SafariInfo.S_Length);
            $("#SafariS_Loose").val(SafariInfo.S_Loose);
            $("#SafariChest").val(SafariInfo.Chest);
            $("#SafariWaist").val(SafariInfo.Waist);
            $("#SafariHip").val(SafariInfo.Hip);
            $("#SafariCollar").val(SafariInfo.Collar);
            $("#SafariCollar_Style").val(SafariInfo.Collar_Style);
            $("#SafariButtons").val(SafariInfo.Buttons);
            $("#SafariSide_Vent").val(SafariInfo.Side_Vent);
            $("#SafariS_Breast").val(SafariInfo.S_Breast);
            $("#SafariD_Breast").val(SafariInfo.D_Breast);
            $("#SafariBreast").val(SafariInfo.Breast);
            $("#Safari_Notes").val(SafariInfo.Notes);

            $(".AddSafariInfoButton").removeClass("disabled");
            $(".AddSafariInfoButton").removeClass("btn-warning");
            $(".AddSafariInfoButton").addClass("btn-success");
        }

        if (typeof (PantInfo) != "undefined" && PantInfo != null && typeof (PantInfo.Id) != "undefined" && PantInfo.Id != null) {
            $("#PantInfoLength").val(PantInfo.Length);
            $("#PantInfoSeat").val(PantInfo.Seat);
            $("#PantInfoHip").val(PantInfo.Hip);
            $("#PantInfoInSeen").val(PantInfo.InSeen);
            $("#PantInfoThigh").val(PantInfo.Thigh);
            $("#PantInfoKnee").val(PantInfo.Knee);
            $("#PantInfoBottom").val(PantInfo.Bottom);
            $("#PantInfoBackPocket").val(PantInfo.BackPocket);
            $("#PantInfoWatchPocket").val(PantInfo.WatchPocket);
            $("#PantInfoIron").val(PantInfo.Iron);
            $("#PantInfoEmming").val(PantInfo.Emming);
            $("#PantInfoBottomFold").val(PantInfo.BottomFold);
            $("#PantInfoBuckleModel").val(PantInfo.BuckleModel);
            $("#PantInfoHookButton").val(PantInfo.HookButton);
            $("#PantInfoButton").val(PantInfo.Button);
            $("#PantInfo_Notes").val(PantInfo.Notes);

            $(".AddPantInfoButton").removeClass("disabled");
            $(".AddPantInfoButton").removeClass("btn-warning");
            $(".AddPantInfoButton").addClass("btn-success");
        }

        if (typeof (ShirtInfo) != "undefined" && ShirtInfo != null && typeof (ShirtInfo.Id) != "undefined" && ShirtInfo.Id != null) {
            $("#ShirtInfoLength").val(ShirtInfo.Length);
            $("#ShirtInfoShoulder").val(ShirtInfo.Shoulder);
            $("#ShirtInfoS_Length").val(ShirtInfo.S_Length);
            $("#ShirtInfoS_Loose").val(ShirtInfo.S_Loose);
            $("#ShirtInfoChest").val(ShirtInfo.Chest);
            $("#ShirtInfoWaist").val(ShirtInfo.Waist);
            $("#ShirtInfoHip").val(ShirtInfo.Hip);
            $("#ShirtInfoCollar").val(ShirtInfo.Collar);
            $("#ShirtInfoCollar_Size").val(ShirtInfo.Collar_Size);
            $("#ShirtInfoCollar_Style").val(ShirtInfo.Collar_Style);
            $("#ShirtInfoCuf_Size").val(ShirtInfo.Cuf_Size);
            $("#ShirtInfoCuf_Style").val(ShirtInfo.Cuf_Style);
            $("#ShirtInfoCollar_Button").val(ShirtInfo.Collar_Button);
            $("#ShirtInfoPatti").val(ShirtInfo.Patti);
            $("#ShirtInfoPocket").val(ShirtInfo.Pocket);
            $("#ShirtInfoInnerPocket").val(ShirtInfo.InnerPocket);
            $("#ShirtInfoKneePatch").val(ShirtInfo.KneePatch);
            $("#ShirtInfoFit").val(ShirtInfo.Fit);
            $("#ShirtInfo_Notes").val(ShirtInfo.Notes);

            $(".AddShirtInfoButton").removeClass("disabled");
            $(".AddShirtInfoButton").removeClass("btn-warning");
            $(".AddShirtInfoButton").addClass("btn-success");
        }

        $("#EditOrder").modal("show");
    }
}

$("#UpdateOrderFromSubmit").click(function () {
    var OrderId = $(".OrderId").val();

    var CustomerName = $("#CustomerName").val();
    var Image = Global_OrderImage;
    var ShopId = $("#SelctedShopId").val();
    var Amount = $("#OrderAmount").val();
    var CustomerMobileNumber = $("#CustomerMobileNumber").val();
    var Status = Global_OrderStatus;
    var Notes = $("#OrderNotes").val();
    var StartDate = $("#OrderStartDate").val();
    var EndDate = $("#OrderEndDate").val();


    if ((CustomerName == "" || CustomerMobileNumber == "" || Amount == "" || StartDate == "" || EndDate == "")) {
        if (CustomerName == "") $("#CustomerName").addClass("form-error");
        else $("#CustomerName").removeClass("form-error");

        if (CustomerMobileNumber == "") $("#CustomerMobileNumber").addClass("form-error");
        else $("#CustomerMobileNumber").removeClass("form-error");

        if (Amount == "") $("#OrderAmount").addClass("form-error");
        else $("#OrderAmount").removeClass("form-error");

        if (StartDate == "") $("#OrderStartDate").addClass("form-error");
        else $("#OrderStartDate").removeClass("form-error");

        if (EndDate == "") $("#OrderEndDate").addClass("form-error");
        else $("#OrderEndDate").removeClass("form-error");

        $(".customErrorMessageAddOrder").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $("input[type=\"date\"]").removeClass("form-error");

        var IsSuccess = true;
        if (IsSuccess) {
            if (CustomerMobileNumber.length != 10) {
                $("#CustomerMobileNumber").addClass("form-error");
                $(".customErrorMessageAddOrder").text("Please enter valid mobile number");
                IsSuccess = false;
            } else {
                $("#CustomerMobileNumber").removeClass("form-error");
                IsSuccess = true;
            }
        }

        if (IsSuccess) {

            $("#UpdateOrderFromSubmit").addClass("btn-progress");

            if (Global_SafariInfo == "") {
                Global_SafariInfo = null;
            }

            if (Global_PantInfo == "") {
                Global_PantInfo = null;
            }

            if (Global_ShirtInfo == "") {
                Global_ShirtInfo = null;
            }

            var data = '{Id:"' + OrderId + '", CustomerName:"' + CustomerName + '",Image:"' + Image + '",ShopId:"' + ShopId + '",Amount:' + Amount + ',CustomerMobileNumber:"' + CustomerMobileNumber + '",Status:"' + Status + '",Notes:"' + Notes + '",StartDate:"' + StartDate + '",EndDate:"' + EndDate + '",safariInfo:' + Global_SafariInfo + ',pantInfo:' + Global_PantInfo + ',shirtInfo:' + Global_ShirtInfo + '}';
            handleAjaxRequest(null, true, "/Method/UpdateOrderInfo", data, "CallBackUpdateOrderInfo");
        }
    }
});

function CallBackUpdateOrderInfo(responseData) {
    if (responseData.message.status == "success") {
        window.location.reload();
    }
}

$(".SelectedShopName").click(function () {
    $("#ViewShopInfo").modal("show");
});

$(".DeleteOrder").click(function () {
    var OrderId = $(this).attr("data-id");
    swal({
        title: 'Are you sure?',
        text: 'Once deleted, you will not be able to recover this User Details!',
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            var data = '{Id:"' + OrderId + '"}';
            handleAjaxRequest(null, true, "/Method/DeleteOrderById", data, "CallBackDeleteOrderById");            
        }
    });
});

function CallBackDeleteOrderById(responseData) {
    if (responseData.message.status == "success") {
        window.location.reload();
    }
}

var Global_OrderStatus = "awaiting";
var Global_OrderImage = "";
var Global_SafariInfo = "";
var Global_ShirtInfo = "";
var Global_PantInfo = "";

$(".awaiting.OrderStatus").click(function () {
    Global_OrderStatus = "awaiting";
});

$(".inprogress.OrderStatus").click(function () {
    Global_OrderStatus = "inprogress";
});

$(".completed.OrderStatus").click(function () {
    Global_OrderStatus = "completed";
});

$(".dropped.OrderStatus").click(function () {
    Global_OrderStatus = "dropped";
});

$("#OrderInfoFromSubmit").click(function () {
    var CustomerName = $("#CustomerName").val();
    var Image = Global_OrderImage;
    var ShopId = $("#SelctedShopId").val();
    var Amount = $("#OrderAmount").val();
    var CustomerMobileNumber = $("#CustomerMobileNumber").val();
    var Status = Global_OrderStatus;
    var Notes = $("#OrderNotes").val();
    var StartDate = $("#OrderStartDate").val();
    var EndDate = $("#OrderEndDate").val();


    if ((CustomerName == "" || CustomerMobileNumber == "" || Amount == "" || StartDate == "" || EndDate == "")) {
        if (CustomerName == "") $("#CustomerName").addClass("form-error");
        else $("#CustomerName").removeClass("form-error");

        if (CustomerMobileNumber == "") $("#CustomerMobileNumber").addClass("form-error");
        else $("#CustomerMobileNumber").removeClass("form-error");

        if (Amount == "") $("#OrderAmount").addClass("form-error");
        else $("#OrderAmount").removeClass("form-error");

        if (StartDate == "") $("#OrderStartDate").addClass("form-error");
        else $("#OrderStartDate").removeClass("form-error");

        if (EndDate == "") $("#OrderEndDate").addClass("form-error");
        else $("#OrderEndDate").removeClass("form-error");

        $(".customErrorMessageAddOrder").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $("input[type=\"date\"]").removeClass("form-error");

        var IsSuccess = false;
        if (Global_SafariInfo == "" && Global_ShirtInfo == "" && Global_PantInfo == "") {
            $(".customErrorMessageAddOrder").text("Add atleast any one Order Info !");
        } else {           
            $(".customErrorMessageAddOrder").text("");
            IsSuccess = true;
        }     

        if (IsSuccess) {
            if (CustomerMobileNumber.length != 10) {
                $("#CustomerMobileNumber").addClass("form-error");
                $(".customErrorMessageAddOrder").text("Please enter valid mobile number");
                IsSuccess = false;
            } else {
                $("#CustomerMobileNumber").removeClass("form-error");
                IsSuccess = true;
            }
        }

        if (IsSuccess) {

            $("#OrderInfoFromSubmit").addClass("btn-progress");

            if (Global_SafariInfo == "") {
                Global_SafariInfo = null;
            }

            if (Global_PantInfo == "") {
                Global_PantInfo = null;
            }

            if (Global_ShirtInfo == "") {                
                Global_ShirtInfo = null;
            }

            var data = '{CustomerName:"' + CustomerName + '",Image:"' + Image + '",ShopId:"' + ShopId + '",Amount:' + Amount + ',CustomerMobileNumber:"' + CustomerMobileNumber + '",Status:"' + Status + '",Notes:"' + Notes + '",StartDate:"' + StartDate + '",EndDate:"' + EndDate + '",safariInfo:' + Global_SafariInfo + ',pantInfo:' + Global_PantInfo + ',shirtInfo:' + Global_ShirtInfo + '}';
            handleAjaxRequest(null, true, "/Method/AddOrderInfo", data, "CallBackAddOrderInfo");
        }
    }
});

function CallBackAddOrderInfo(responseData) {
    if (responseData.message.status == "success") {
        $("input[type=\"text\"]").val('');
        $("input[type=\"number\"]").val('');
        $("input[type=\"file\"]").val('');
        swal('Order Added Successfully');
    } else {
        swal('Error on Adding User');
    }
    $("#OrderInfoFromSubmit").removeClass("btn-progress");
}


$("#SafariInfoFromSubmit").click(function () {
    var Length = $("#SafariLength").val();
    var Shoulder = $("#SafariShoulder").val();
    var S_Length = $("#SafariS_Length").val();
    var S_Loose = $("#SafariS_Loose").val();
    var Chest = $("#SafariChest").val();
    var Waist = $("#SafariWaist").val();
    var Hip = $("#SafariHip").val();
    var Collar = $("#SafariCollar").val();
    var Collar_Style = $("#SafariCollar_Style").val();
    var Buttons = $("#SafariButtons").val();
    var Side_Vent = $("#SafariSide_Vent").val();
    var S_Breast = $("#SafariS_Breast").val();
    var D_Breast = $("#SafariD_Breast").val();
    var Breast = $("#SafariBreast").val();
    var Notes = $("#Safari_Notes").val();

    if (Length == "" || Shoulder == "" || S_Length == "" || S_Loose == "" || Chest == "" || Waist == "" || Hip == "" || Collar == "" || Collar_Style == "" || Buttons == "" || Side_Vent == "" || S_Breast == "" || D_Breast == "" || Breast == "") {

        if (Length == "") $("#SafariLength").addClass("form-error");
        else $("#SafariLength").removeClass("form-error");

        if (Shoulder == "") $("#SafariShoulder").addClass("form-error");
        else $("#SafariShoulder").removeClass("form-error");

        if (S_Length == "") $("#SafariS_Length").addClass("form-error");
        else $("#SafariS_Length").removeClass("form-error");

        if (S_Loose == "") $("#SafariS_Loose").addClass("form-error");
        else $("#SafariS_Loose").removeClass("form-error");

        if (Chest == "") $("#SafariChest").addClass("form-error");
        else $("#SafariChest").removeClass("form-error");

        if (Waist == "") $("#SafariWaist").addClass("form-error");
        else $("#SafariWaist").removeClass("form-error");

        if (Hip == "") $("#SafariHip").addClass("form-error");
        else $("#SafariHip").removeClass("form-error");

        if (Collar == "") $("#SafariCollar").addClass("form-error");
        else $("#SafariCollar").removeClass("form-error");

        if (Collar_Style == "") $("#SafariCollar_Style").addClass("form-error");
        else $("#SafariCollar_Style").removeClass("form-error");

        if (Buttons == "") $("#SafariButtons").addClass("form-error");
        else $("#SafariButtons").removeClass("form-error");

        if (Side_Vent == "") $("#SafariSide_Vent").addClass("form-error");
        else $("#SafariSide_Vent").removeClass("form-error");

        if (S_Breast == "") $("#SafariS_Breast").addClass("form-error");
        else $("#SafariS_Breast").removeClass("form-error");

        if (D_Breast == "") $("#SafariD_Breast").addClass("form-error");
        else $("#SafariD_Breast").removeClass("form-error");

        if (Breast == "") $("#SafariBreast").addClass("form-error");
        else $("#SafariBreast").removeClass("form-error");

        $(".customErrorMessageAddSafariInfo").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $(".customErrorMessageAddSafariInfo").text("");

        var _safariInfo = {};

        _safariInfo.Id = "";
        _safariInfo.OrderId = "";
        _safariInfo.CreatedDate = new Date();
        _safariInfo.Length = Length;
        _safariInfo.Shoulder = Shoulder;
        _safariInfo.S_Length = S_Length;
        _safariInfo.S_Loose = S_Loose;
        _safariInfo.Chest = Chest;
        _safariInfo.Waist = Waist;
        _safariInfo.Hip = Hip;
        _safariInfo.Collar = Collar;
        _safariInfo.Collar_Style = Collar_Style;
        _safariInfo.Buttons = Buttons;
        _safariInfo.Side_Vent = Side_Vent;
        _safariInfo.S_Breast = S_Breast;
        _safariInfo.D_Breast = D_Breast;
        _safariInfo.Breast = Breast;
        _safariInfo.Notes = Notes;
        _safariInfo.ModifiedDate = new Date();

        Global_SafariInfo = JSON.stringify(_safariInfo);

        $("#SafariInfo").modal("hide");

        $(".AddSafariInfoButton").removeClass("disabled");
        $(".AddSafariInfoButton").removeClass("btn-warning");
        $(".AddSafariInfoButton").addClass("btn-success");
    }

});

$("#PantInfoFromSubmit").click(function () {
    var Length = $("#PantInfoLength").val();
    var Seat = $("#PantInfoSeat").val();
    var Hip = $("#PantInfoHip").val();
    var InSeen = $("#PantInfoInSeen").val();
    var Thigh = $("#PantInfoThigh").val();
    var Knee = $("#PantInfoKnee").val();
    var Bottom = $("#PantInfoBottom").val();
    var BackPocket = $("#PantInfoBackPocket").val();
    var WatchPocket = $("#PantInfoWatchPocket").val();
    var Iron = $("#PantInfoIron").val();
    var Emming = $("#PantInfoEmming").val();
    var BottomFold = $("#PantInfoBottomFold").val();
    var BuckleModel = $("#PantInfoBuckleModel").val();
    var HookButton = $("#PantInfoHookButton").val();
    var Button = $("#PantInfoButton").val();
    var Notes = $("#PantInfo_Notes").val();

    if (Length == "" || Seat == "" || Hip == "" || InSeen == "" || Thigh == "" || Knee == "" || Bottom == "" || BackPocket == "" || WatchPocket == "" || Iron == "" || Emming == "" || BottomFold == "" || BuckleModel == "" || HookButton == "" || Button == "") {

        if (Length == "") $("#PantInfoLength").addClass("form-error");
        else $("#PantInfoLength").removeClass("form-error");

        if (Seat == "") $("#PantInfoSeat").addClass("form-error");
        else $("#PantInfoSeat").removeClass("form-error");

        if (Hip == "") $("#PantInfoHip").addClass("form-error");
        else $("#PantInfoHip").removeClass("form-error");

        if (InSeen == "") $("#PantInfoInSeen").addClass("form-error");
        else $("#PantInfoInSeen").removeClass("form-error");

        if (Thigh == "") $("#PantInfoThigh").addClass("form-error");
        else $("#PantInfoThigh").removeClass("form-error");

        if (Knee == "") $("#PantInfoKnee").addClass("form-error");
        else $("#PantInfoKnee").removeClass("form-error");

        if (Bottom == "") $("#PantInfoBottom").addClass("form-error");
        else $("#PantInfoBottom").removeClass("form-error");

        if (BackPocket == "") $("#PantInfoBackPocket").addClass("form-error");
        else $("#PantInfoBackPocket").removeClass("form-error");

        if (WatchPocket == "") $("#PantInfoWatchPocket").addClass("form-error");
        else $("#PantInfoWatchPocket").removeClass("form-error");

        if (Iron == "") $("#PantInfoIron").addClass("form-error");
        else $("#PantInfoIron").removeClass("form-error");

        if (Emming == "") $("#PantInfoEmming").addClass("form-error");
        else $("#PantInfoEmming").removeClass("form-error");

        if (BottomFold == "") $("#PantInfoBottomFold").addClass("form-error");
        else $("#PantInfoBottomFold").removeClass("form-error");

        if (BuckleModel == "") $("#PantInfoBuckleModel").addClass("form-error");
        else $("#PantInfoBuckleModel").removeClass("form-error");

        if (HookButton == "") $("#PantInfoHookButton").addClass("form-error");
        else $("#PantInfoHookButton").removeClass("form-error");

        if (Button == "") $("#PantInfoButton").addClass("form-error");
        else $("#PantInfoButton").removeClass("form-error");

        $(".customErrorMessageAddPantInfo").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $(".customErrorMessageAddSafariInfo").text("");

        var _pantInfo = {};

        _pantInfo.Id = "";
        _pantInfo.OrderId = "";
        _pantInfo.CreatedDate = new Date();
        _pantInfo.Length = Length;
        _pantInfo.Seat = Seat;
        _pantInfo.Hip = Hip;
        _pantInfo.InSeen = InSeen;
        _pantInfo.Thigh = Thigh;
        _pantInfo.Knee = Knee;
        _pantInfo.Bottom = Bottom;
        _pantInfo.BackPocket = BackPocket;
        _pantInfo.WatchPocket = WatchPocket;
        _pantInfo.Iron = Iron;
        _pantInfo.Emming = Emming;
        _pantInfo.BottomFold = BottomFold;
        _pantInfo.BuckleModel = BuckleModel;
        _pantInfo.HookButton = HookButton;
        _pantInfo.Button = Button;
        _pantInfo.Notes = Notes;
        _pantInfo.ModifiedDate = new Date();

        Global_PantInfo = JSON.stringify(_pantInfo);

        $("#PantInfo").modal("hide");

        $(".AddPantInfoButton").removeClass("disabled");
        $(".AddPantInfoButton").removeClass("btn-warning");
        $(".AddPantInfoButton").addClass("btn-success");
    }
});

$("#ShirtInfoFromSubmit").click(function () {
    var Length = $("#ShirtInfoLength").val();
    var Shoulder = $("#ShirtInfoShoulder").val();
    var S_Length = $("#ShirtInfoS_Length").val();
    var S_Loose = $("#ShirtInfoS_Loose").val();
    var Chest = $("#ShirtInfoChest").val();
    var Waist = $("#ShirtInfoWaist").val();
    var Hip = $("#ShirtInfoHip").val();
    var Collar = $("#ShirtInfoCollar").val();
    var Collar_Size = $("#ShirtInfoCollar_Size").val();
    var Collar_Style = $("#ShirtInfoCollar_Style").val();
    var Cuf_Size = $("#ShirtInfoCuf_Size").val();
    var Cuf_Style = $("#ShirtInfoCuf_Style").val();
    var Collar_Button = $("#ShirtInfoCollar_Button").val();
    var Patti = $("#ShirtInfoPatti").val();
    var Pocket = $("#ShirtInfoPocket").val();
    var InnerPocket = $("#ShirtInfoInnerPocket").val();
    var KneePatch = $("#ShirtInfoKneePatch").val();
    var Fit = $("#ShirtInfoFit").val();
    var Notes = $("#ShirtInfo_Notes").val();

    if (Length == "" || Shoulder == "" || S_Length == "" || S_Loose == "" || Chest == "" || Waist == "" || Hip == "" || Collar == "" || Collar_Size == "" || Collar_Style == "" || Cuf_Size == "" || Cuf_Style == "" || Collar_Button == "" || Patti == "" || Pocket == "" || InnerPocket == "" || KneePatch == "" || Fit == "") {

        if (Length == "") $("#ShirtInfoLength").addClass("form-error");
        else $("#ShirtInfoLength").removeClass("form-error");

        if (Shoulder == "") $("#ShirtInfoShoulder").addClass("form-error");
        else $("#ShirtInfoShoulder").removeClass("form-error");

        if (S_Length == "") $("#ShirtInfoS_Length").addClass("form-error");
        else $("#ShirtInfoS_Length").removeClass("form-error");

        if (S_Loose == "") $("#ShirtInfoS_Loose").addClass("form-error");
        else $("#ShirtInfoS_Loose").removeClass("form-error");

        if (Chest == "") $("#ShirtInfoChest").addClass("form-error");
        else $("#ShirtInfoChest").removeClass("form-error");

        if (Waist == "") $("#ShirtInfoWaist").addClass("form-error");
        else $("#ShirtInfoWaist").removeClass("form-error");

        if (Hip == "") $("#ShirtInfoHip").addClass("form-error");
        else $("#ShirtInfoHip").removeClass("form-error");

        if (Collar == "") $("#ShirtInfoCollar").addClass("form-error");
        else $("#ShirtInfoCollar").removeClass("form-error");

        if (Collar_Size == "") $("#ShirtInfoCollar_Size").addClass("form-error");
        else $("#ShirtInfoCollar_Size").removeClass("form-error");

        if (Collar_Style == "") $("#ShirtInfoCollar_Style").addClass("form-error");
        else $("#ShirtInfoCollar_Style").removeClass("form-error");

        if (Cuf_Size == "") $("#ShirtInfoCuf_Size").addClass("form-error");
        else $("#ShirtInfoCuf_Size").removeClass("form-error");

        if (Cuf_Style == "") $("#ShirtInfoCuf_Style").addClass("form-error");
        else $("#ShirtInfoCuf_Style").removeClass("form-error");

        if (Collar_Button == "") $("#ShirtInfoCollar_Button").addClass("form-error");
        else $("#ShirtInfoCollar_Button").removeClass("form-error");

        if (Patti == "") $("#ShirtInfoPatti").addClass("form-error");
        else $("#ShirtInfoPatti").removeClass("form-error");

        if (Pocket == "") $("#ShirtInfoPocket").addClass("form-error");
        else $("#ShirtInfoPocket").removeClass("form-error");

        if (InnerPocket == "") $("#ShirtInfoInnerPocket").addClass("form-error");
        else $("#ShirtInfoInnerPocket").removeClass("form-error");

        if (KneePatch == "") $("#ShirtInfoKneePatch").addClass("form-error");
        else $("#ShirtInfoKneePatch").removeClass("form-error");

        if (Fit == "") $("#ShirtInfoFit").addClass("form-error");
        else $("#ShirtInfoFit").removeClass("form-error");

        $(".customErrorMessageAddShirtInfo").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $(".customErrorMessageAddShirtInfo").text("");

        var _shirtInfo = {};

        _shirtInfo.Id = "";
        _shirtInfo.OrderId = "";
        _shirtInfo.CreatedDate = new Date();
        _shirtInfo.Length = Length;
        _shirtInfo.Shoulder = Shoulder;
        _shirtInfo.S_Length = S_Length;
        _shirtInfo.S_Loose = S_Loose;
        _shirtInfo.Chest = Chest;
        _shirtInfo.Waist = Waist;
        _shirtInfo.Hip = Hip;
        _shirtInfo.Collar = Collar;
        _shirtInfo.Collar_Size = Collar_Size;
        _shirtInfo.Collar_Style = Collar_Style;
        _shirtInfo.Cuf_Size = Cuf_Size;
        _shirtInfo.Cuf_Style = Cuf_Style;
        _shirtInfo.Collar_Button = Collar_Button;
        _shirtInfo.Patti = Patti;
        _shirtInfo.Pocket = Pocket;
        _shirtInfo.InnerPocket = InnerPocket;
        _shirtInfo.KneePatch = KneePatch;
        _shirtInfo.Fit = Fit;
        _shirtInfo.Notes = Notes;
        _shirtInfo.ModifiedDate = new Date();

        Global_ShirtInfo = JSON.stringify(_shirtInfo);

        $("#ShirtInfo").modal("hide");

        $(".AddShirtInfoButton").removeClass("disabled");
        $(".AddShirtInfoButton").removeClass("btn-warning");
        $(".AddShirtInfoButton").addClass("btn-success");
    }

});


$(".SubmitVisualDataForm").click(function () {
    var Date = $("#datepickerNew").val();
    if (Date == "") {
        $("#datepickerNew").addClass("form-error");
    } else {
        $("#datepickerNew").removeClass("form-error");
        $(".VisualInfo").show();


    }    
});





function readFile() {
    if (this.files && this.files[0]) {
        var FR = new FileReader();
        FR.addEventListener("load", function (e) {
            Global_OrderImage = e.target.result;
        });
        FR.readAsDataURL(this.files[0]);
    }
}
document.getElementById("OrderImage").addEventListener("change", readFile);