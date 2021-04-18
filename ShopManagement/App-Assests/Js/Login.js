function ValidateLogin(MobileNumber, Password, IsRemember) {
    if (MobileNumber == "" || Password == "") {

        if (MobileNumber == "") $(".MobileNumber").addClass("form-error");
        else $(".MobileNumber").removeClass("form-error");

        if (Password == "") $(".Password").addClass("form-error");
        else $(".Password").removeClass("form-error");
        $(".customErrorMessageLogin").text("Validation Failed, recheck the form !");
    }
    else {
        $("input[type=\"number\"]").removeClass("form-error");
        $("input[type=\"password\"]").removeClass("form-error");
        $(".customErrorMessageLogin").text("");
        var IsSuccess = true;

        if (MobileNumber.length != 10) {
            $(".MobileNumber").addClass("form-error");
            $(".customErrorMessageLogin").text("Please enter valid mobile number");
            IsSuccess = false;
        } else {
            $(".MobileNumber").removeClass("form-error");
            IsSuccess = true;
        }

        if (IsSuccess) {

            $("#LoginFormSubmit").addClass("btn-progress");

            var data = '{MobileNumber:"' + MobileNumber + '",Password:"' + Password + '",IsRemember:' + IsRemember + '}';
            handleAjaxRequest(null, true, "/Method/ValidateUserLogin", data, "CallBackValidateLogin");
        }

    }
    
}