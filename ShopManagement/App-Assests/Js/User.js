$(document).ready(function () {
    UserImage = "";
});

$(".ViewUserInfo").click(function () {
    $("#UserInfo").modal("show");
});

$(".ViewShopInfo").click(function () {
    $("#ViewShopInfo").modal("show");
});

$(".DeleteUser").click(function () {
    var UserId = $(this).attr("data-id");
    var UserName = $(this).attr("data-UserName");
    var UserInfo = [];
    UserInfo.push(UserId);
    UserInfo.push(UserName);
    swal({
        title: 'Are you sure?',
        text: 'Once deleted, you will not be able to recover this User Details!',
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            var data = '{Id:"' + UserId + '"}';
            handleAjaxRequest(null, true, "/Method/DeleteUserById", data, "CallBackDeleteUser", UserInfo);            
        }
    });
});

function CallBackDeleteUser(responseData, UserInfo) {
    if (responseData.message.status == "success") {
        var UserId = UserInfo[0];

        iziToast.success({
            title: 'Poof! ',
            message: UserInfo[1] + ' has been deleted!',
            position: 'topCenter'
        });
        $(".UserInfo[data-id='" + UserId + "']").remove();
    }
}

$(".AddUserFromSubmit").click(function () {
    AddNewUser($(this));
});

var UserStatus = "active";
$(".UserStatus").change(function () {
    UserStatus = $(this).val();
});

var UserImage = "";
function AddNewUser(target) {
    var UserName = $(".UserName").val().trim();
    var UserEmailId = $(".UserEmailId").val().trim();
    var UserMobileNumber = $(".UserMobileNumber").val().trim();
    var UserPassword = $(".UserPassword").val().trim();
    var UserArea = $(".UserArea").val().trim();
    var User_Notes = $(".User_Notes").val().trim();
    var Status = UserStatus;

    if (UserName == "" || UserEmailId == "" || UserMobileNumber == "" || UserPassword == "" || UserArea == "") {

        if (UserName == "") $(".UserName").addClass("form-error");
        else $(".UserName").removeClass("form-error");

        if (UserEmailId == "") $(".UserEmailId").addClass("form-error");
        else $(".UserEmailId").removeClass("form-error");

        if (UserMobileNumber == "") $(".UserMobileNumber").addClass("form-error");
        else $(".UserMobileNumber").removeClass("form-error");

        if (UserPassword == "") $(".UserPassword").addClass("form-error");
        else $(".UserPassword").removeClass("form-error");

        if (UserArea == "") $(".UserArea").addClass("form-error");
        else $(".UserArea").removeClass("form-error");

        $(".customErrorMessageAddUser").text("Validation Failed, recheck the form !");
    }
    else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $(".customErrorMessageAddUser").text("");
        var IsSuccess = true;

        if (UserMobileNumber.length != 10) {
            $(".UserMobileNumber").addClass("form-error");
            $(".customErrorMessageAddUser").text("Please enter valid mobile number");
            IsSuccess = false;
        } else {
            $(".UserMobileNumber").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {

            $(".AddUserFromSubmit").addClass("btn-progress");

            var data = '{Name:"' + UserName + '",EmailId:"' + UserEmailId + '",Password:"' + UserPassword + '",Image:"' + UserImage + '",Status:"' + Status + '",Area:"' + UserArea + '",Notes:"' + User_Notes + '",MobileNumber:"' + UserMobileNumber + '",IsAdmin:"' + 0 + '"}';
            handleAjaxRequest(null, true, "/Method/AddUserInfo", data, "CallBackAddNewUser");
        }
        
    }
}

function CallBackAddNewUser(responseData) {
    if (responseData.message.status == "success") {
        $("input[type=\"text\"]").val('');
        $("input[type=\"number\"]").val('');
        $("input[type=\"password\"]").val('');
        $("input[type=\"email\"]").val('');
        $("input[type=\"file\"]").val('');
        swal('User Added Successfully');
    } else {
        swal('Error on Adding User');
    }
    $(".AddUserFromSubmit").removeClass("btn-progress");
}

$(".EditUserInfo").click(function () {
    var UserId = $(this).attr("data-id");
    var data = '{Id:"' + UserId + '"}';
    handleAjaxRequest(null, true, "/Method/GetUserById", data, "CallBackGetUserInfoById");

});

function CallBackGetUserInfoById(responseData) {
    if (responseData.message.status == "success") {
        var UserInfo = responseData.message.userInfo;
        $(".UserName").val(UserInfo.Name);
        $(".UserEmailId").val(UserInfo.EmailId);
        $(".UserMobileNumber").val(UserInfo.MobileNumber);
        $(".UserPassword").val(UserInfo.Password);
        $(".UserArea").val(UserInfo.Area);
        $(".User_Notes").val(UserInfo.Notes);
        $(".SelectedUserId").val(UserInfo.Id);
        $(".SelectedUserNameModelTitle").text(UserInfo.Name);
        UserStatus = UserInfo.Status;
        if (UserStatus == "active") {
            $(".UserStatus[value=\"active\"]").trigger("click");
        } else {
            $(".UserStatus[value=\"inactive\"]").trigger("click");
        }
        $("#EditUserInfo").modal("show");
    }
}

$(".EditUserFromSubmit").click(function () {
    UpdateUserInfo($(this));
});

function UpdateUserInfo(target) {
    var UserId = $(".SelectedUserId").val();
    var UserName = $(".UserName").val().trim();
    var UserEmailId = $(".UserEmailId").val().trim();
    var UserMobileNumber = $(".UserMobileNumber").val().trim();
    var UserPassword = $(".UserPassword").val().trim();
    var UserArea = $(".UserArea").val().trim();
    var User_Notes = $(".User_Notes").val().trim();
    var Status = UserStatus;

    if (UserName == "" || UserEmailId == "" || UserMobileNumber == "" || UserPassword == "" || UserArea == "") {

        if (UserName == "") $(".UserName").addClass("form-error");
        else $(".UserName").removeClass("form-error");

        if (UserEmailId == "") $(".UserEmailId").addClass("form-error");
        else $(".UserEmailId").removeClass("form-error");

        if (UserMobileNumber == "") $(".UserMobileNumber").addClass("form-error");
        else $(".UserMobileNumber").removeClass("form-error");

        if (UserPassword == "") $(".UserPassword").addClass("form-error");
        else $(".UserPassword").removeClass("form-error");

        if (UserArea == "") $(".UserArea").addClass("form-error");
        else $(".UserArea").removeClass("form-error");

        $(".customErrorMessageAddUser").text("Validation Failed, recheck the form !");
    } else {
        $("input[type=\"text\"]").removeClass("form-error");
        $("input[type=\"number\"]").removeClass("form-error");
        $(".customErrorMessageAddUser").text("");
        var IsSuccess = true;

        if (UserMobileNumber.length != 10) {
            $(".UserMobileNumber").addClass("form-error");
            $(".customErrorMessageAddUser").text("Please enter valid mobile number");
            IsSuccess = false;
        } else {
            $(".UserMobileNumber").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {

            $(".EditUserFromSubmit").addClass("btn-progress");

            var data = '{Id:"' + UserId +'", Name:"' + UserName + '",EmailId:"' + UserEmailId + '",Password:"' + UserPassword + '",Image:"' + UserImage + '",Status:"' + Status + '",Area:"' + UserArea + '",Notes:"' + User_Notes + '",MobileNumber:"' + UserMobileNumber + '",IsAdmin:"' + 0 + '"}';
            handleAjaxRequest(null, true, "/Method/UpdateUserInfo", data, "CallBackUpdateUserInfo");
        }

    }
}

function CallBackUpdateUserInfo(responseData) {
    $(".EditUserFromSubmit").removeClass("btn-progress");
    if (responseData.message.status == "success") {        
        var UserInfo = responseData.message.userInfo;
        var UserId = UserInfo.Id;
        $(".SelectedUserImageExpand[data-id='" + UserId + "']").attr("src", UserInfo.Image);
        $(".SelectedUserImage[data-id='" + UserId + "']").attr("src", UserInfo.Image);
        $(".SelectedUserName[data-id='" + UserId + "']").text(UserInfo.Name);
        $(".SelectedUserEmail[data-id='" + UserId + "']").text(UserInfo.EmailId);
        $(".SelectedUserMobile[data-id='" + UserId + "']").text(UserInfo.MobileNumber);
        $(".UserStatusCard[data-id='" + UserId + "']").removeClass("card-danger");
        $(".UserStatusCard[data-id='" + UserId + "']").removeClass("card-success");
        if (UserInfo.Status == "active")
            $(".UserStatusCard[data-id='" + UserId + "']").addClass("card-success");
        else 
            $(".UserStatusCard[data-id='" + UserId + "']").addClass("card-danger");

        $("#EditUserInfo").modal("hide");

        iziToast.success({
            title: 'success',
            message: 'User Informatino Updated Successfully',
            position: 'topCenter'
        });
    } else {
        $(".customErrorMessageAddUser").text("Error on updating User Details");
    }

}

$("#UserPassword").on('click', function () {
    try {
        var data = {
            field: $(".UserPassword"),            
            icon: {
                field: $(this).find("i"),
                onClass: "fa-eye",
                offClass: "fa-eye-slash"
            }
        };
        var a = document.getElementById("UserPassword");
        switchPasswordVisibility(data);
    } catch (e) {
        console.log(e);
    }
});

function readFile() {    
    if (this.files && this.files[0]) {
        var FR = new FileReader();
        FR.addEventListener("load", function (e) {
            UserImage = e.target.result;
        });
        FR.readAsDataURL(this.files[0]);
    }
}
document.getElementById("UserImage").addEventListener("change", readFile);
