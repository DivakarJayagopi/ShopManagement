$(".ValidateOldPassword").click(function () {
    var Password = $(".OldPassword").val();

    if (Password == "") {

        if (Password == "") $(".OldPassword").addClass("form-error");
        else $(".OldPassword").removeClass("form-error");

        $(".customErrorMessageCheckPassword").text("Validation Failed, recheck the form !");
    }
    else {
        $("input[type=\"text\"]").removeClass("form-error");
        $(".customErrorMessageCheckPassword").text("");

        $(".ValidateOldPassword").addClass("btn-progress");

        var data = '{UserPassword:"' + Password + '"}';
        handleAjaxRequest(null, true, "/Method/ValidateOldPassword", data, "CallBackValidateOldPassword");
    }
});

function CallBackValidateOldPassword(responseData) {
    $(".ValidateOldPassword").removeClass("btn-progress");
    if (responseData.message.status == "success") {
        $("input[type=\"text\"]").val('');
        $(".ValidateOldPassword,.OldPasswordDiv").hide();
        $(".ResetPassword,.UpdatePassword").show();
    } else {
        $(".customErrorMessageCheckPassword").text("Incorrect old password");
    }
}

$(".ResetPassword").click(function () {
    var NewPassword = $(".NewPassword").val();
    var ConfirmPassword = $(".ConfirmPassword").val();

    if (NewPassword == "" || ConfirmPassword == "") {

        if (NewPassword == "") $(".NewPassword").addClass("form-error");
        else $(".NewPassword").removeClass("form-error");

        if (ConfirmPassword == "") $(".ConfirmPassword").addClass("form-error");
        else $(".ConfirmPassword").removeClass("form-error");

        $(".customErrorMessageCheckPassword").text("Validation Failed, recheck the form !");
    }
    else {
        $("input[type=\"text\"]").removeClass("form-error");
        $(".customErrorMessageCheckPassword").text("");

        var IsSuccess = false;

        if (NewPassword.length < 8) {
            $(".NewPassword").addClass("form-error");
            $(".customErrorMessageCheckPassword").text("Password length should be more than 8 characters");
        } else {
            $(".NewPassword").removeClass("form-error");
            IsSuccess = true;
        }

        if (ConfirmPassword.length < 8) {
            $(".ConfirmPassword").addClass("form-error");
            $(".customErrorMessageCheckPassword").text("Password length should be more than 8 characters");
            IsSuccess = false;
        } else {
            $(".ConfirmPassword").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {
            if (NewPassword != ConfirmPassword) {
                $(".customErrorMessageCheckPassword").text("Password did not match");
                $(".NewPassword").addClass("form-error");
                $(".ConfirmPassword").addClass("form-error");
            } else {
                $(".ValidateOldPassword").addClass("btn-progress");

                var data = '{UserPassword:"' + NewPassword + '"}';
                handleAjaxRequest(null, true, "/Method/UpdateUserPassword", data, "CallBackUpdateUserPassword");
            }
        }
    }
});

function CallBackUpdateUserPassword(responseData) {
    if (responseData.message.status == "success") {
        $("input[type=\"password\"]").val('');
        $("input[type=\"text\"]").val('');

        iziToast.success({
            title: 'Poof!',
            message: 'Password Changed successfully',
            position: 'topCenter'
        });
    }
}

$("#OldPassword").on('click', function () {
    try {
        var data = {
            field: $(".OldPassword"),
            icon: {
                field: $(this).find("i"),
                onClass: "fa-eye",
                offClass: "fa-eye-slash"
            }
        };
        var a = document.getElementById("OldPassword");
        switchPasswordVisibility(data);
    } catch (e) {
        console.log(e);
    }
});

$("#NewPassword").on('click', function () {
    try {
        var data = {
            field: $(".NewPassword"),
            icon: {
                field: $(this).find("i"),
                onClass: "fa-eye",
                offClass: "fa-eye-slash"
            }
        };
        var a = document.getElementById("NewPassword");
        switchPasswordVisibility(data);
    } catch (e) {
        console.log(e);
    }
});

$("#ConfirmPassword").on('click', function () {
    try {
        var data = {
            field: $(".ConfirmPassword"),
            icon: {
                field: $(this).find("i"),
                onClass: "fa-eye",
                offClass: "fa-eye-slash"
            }
        };
        var a = document.getElementById("ConfirmPassword");
        switchPasswordVisibility(data);
    } catch (e) {
        console.log(e);
    }
});

$(".ForgotPassowrdFromSubmit").click(function () {
    var MobileNumber = $(".UserMobileNumber").val();
    var IsSuccess = false;
    if (MobileNumber == "") {
        $(".UserMobileNumber").addClass("form-error");
        $(".customErrorMessageForgotPassowrd").text("Validation Failed, recheck the form !");
    } else {
        $(".UserMobileNumber").removeClass("form-error");
        $(".customErrorMessageForgotPassowrd").text("");
        IsSuccess = true;
        if (MobileNumber.length != 10) {
            $(".UserMobileNumber").addClass("form-error");
            $(".customErrorMessageForgotPassowrd").text("Invalid Mobile number, Enter valid mobile number!");
            IsSuccess = false;
        } else {
            $(".UserMobileNumber").removeClass("form-error");
            $(".customErrorMessageForgotPassowrd").text("");
            IsSuccess = true;
        }
    }

    if (IsSuccess) {
        $(".ForgotPassowrdFromSubmit").addClass("btn-progress");

        var data = '{MobileNumber:"' + MobileNumber + '"}';
        handleAjaxRequest(null, true, "/Method/ForgotPassowrd", data, "CallBackForgotPassowrd");
    }
});

function CallBackForgotPassowrd(responseData) {
    $(".ForgotPassowrdFromSubmit").removeClass("btn-progress");
    if (responseData.message.status == "success") {
        iziToast.success({
            title: 'success',
            message: 'Your password has been send to your mobile number',
            position: 'topCenter'
        });
    } else {
        $(".customErrorMessageForgotPassowrd").text("Invalid Mobile Number, Enter a registerd mobile number");
    }
}