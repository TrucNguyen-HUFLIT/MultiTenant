$("#edit-acc-form").submit(function (e) {
    e.preventDefault();

    let form = $(this).serializeArray();
    $.ajax({
        url: '/accountmanagement/edit',
        type: 'post',
        contentType: 'application/x-www-form-urlencoded',
        data: form,
        success: function (data) {
            console.log(data);
            window.location.replace("/accountmanagement/edit/" + data);
        },
        error: function (data) {
            console.log(data);
            //var error = data.responseText;
            //if (error == " Email is already ") {
            //    document.getElementById("emailAlready").innerHTML = data.responseText;
            //    return;
            //}
            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["accountEdit.Name"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValidation["accountEdit.Name"];
                else
                    document.getElementById("Err_Name").innerHTML = "";

                //if (objectValidation["accountEdit.Email"] != undefined)
                //    document.getElementById("Err_Email").innerHTML = objectValidation["accountEdit.Email"];
                //else
                //    document.getElementById("Err_Email").innerHTML = "";
            }
            catch {
                document.getElementById("Err_Name").innerHTML = "";
               // document.getElementById("Err_Email").innerHTML = "";
            }
        },

    });
});

$("#edit-tenant-form").submit(function (e) {
    e.preventDefault();

    let formData = new FormData($(this)[0]);
    $.ajax({
        url: '/tenantmanagement/edit',
        type: "post",
        async: false,
        cache: false,
        contentType: false,
        enctype: 'multipart/form-data',
        processData: false,
        data: formData,
        success: function (data) {
            console.log(data);
            window.location.replace("/tenantmanagement/edit/" + data);
        },
        error: function (data) {
            console.log(data);
            //var error = data.responseText;
            //if (error == " Database is already ") {
            //    document.getElementById("dataAlready").innerHTML = data.responseText;
            //    return;
            //}
            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["tenantEdit.DbName"] != undefined)
                    document.getElementById("Err_DbName").innerHTML = objectValidation["tenantEdit.DbName"];
                else
                    document.getElementById("Err_DbName").innerHTML = "";

            }
            catch {
                document.getElementById("Err_DbName").innerHTML = "";
            }
        },

    });
});

$("#create-tenant-form").submit(function (e) {
    e.preventDefault();

    let formData = new FormData($(this)[0]);
    $.ajax({
        url: '/tenantmanagement/create',
        type: "post",
        async: false,
        cache: false,
        contentType: false,
        enctype: 'multipart/form-data',
        processData: false,
        data: formData,
        success: function (data) {
            console.log(data);
            window.location.replace("/tenantmanagement/index");
        },
        error: function (data) {
            console.log(data);
            var errors = data.responseJSON;
            if (errors == undefined)
            {
                document.getElementById("DbNameExist").innerHTML = data.responseText;
                return;
            }
            try
            {
                var objectValidation = data.responseJSON;

                if (objectValidation["tenantCreate.DbName"] != undefined)
                    document.getElementById("Err_DbName").innerHTML = objectValidation["tenantCreate.DbName"];
                else
                    document.getElementById("Err_DbName").innerHTML = "";
            }
            catch
            {
                document.getElementById("Err_DbName").innerHTML = "";
            }
        },
    });
});

$("#add-tenant").submit(function (e) {
    e.preventDefault();

    let formData = new FormData($(this)[0]);
    $.ajax({
        url: '/accounttenant/addtenanttoacc',
        type: "post",
        async: false,
        cache: false,
        contentType: false,
        enctype: 'multipart/form-data',
        processData: false,
        data: formData,
        success: function (data) {
            console.log(data);
            window.location.replace("/accounttenant/detail/" + data.accId);
            
        },
    });
});

$("#create-acc-form").submit(function (e) {
    e.preventDefault();

    let formData = new FormData($(this)[0]);
    $.ajax({
        url: '/accountmanagement/create',
        type: "post",
        async: false,
        cache: false,
        contentType: false,
        enctype: 'multipart/form-data',
        processData: false,
        data: formData,
        success: function () {
            window.location.replace("/accountmanagement/index");
        },
        error: function (data) {
            console.log(data)
            var errors = data.responseJSON;
            if (errors == undefined)
            {
                document.getElementById("UserNameExist").innerHTML = data.responseText;
                return;
            }
            try {

                var objectValid = data.responseJSON;

                if (objectValid["accountCreate.UserName"] != undefined)
                    document.getElementById("Err_UserName").innerHTML = objectValid["accountCreate.UserName"];
                else
                    document.getElementById("Err_UserName").innerHTML = "";

                if (objectValid["accountCreate.Password"] != undefined)
                    document.getElementById("Err_Password").innerHTML = objectValid["accountCreate.UserName"];
                else
                    document.getElementById("Err_Password").innerHTML = "";

                if (objectValid["accountCreate.Name"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValid["accountCreate.Name"];
                else
                    document.getElementById("Err_Name").innerHTML = "";

                if (objectValid["accountCreate.Email"] != undefined)
                    document.getElementById("Err_Email").innerHTML = objectValid["accountCreate.Email"];
                else
                    document.getElementById("Err_Email").innerHTML = "";


            }
            catch {
                document.getElementById("Err_UserName").innerHTML = "";
                document.getElementById("Err_Password").innerHTML = "";
                document.getElementById("Err_Name").innerHTML = "";
                document.getElementById("Err_Email").innerHTML = "";
            }
        },
    });
});

function DeleteAcc() {
    var confirm = prompt('Text "Delete" to Delete this account').toLowerCase();

    if (confirm == "delete") {
        $.ajax({
            url: '/accounttenant/delete',
            type: 'delete',
            contentType: 'application/x-www-form-urlencoded',
            data: form,
            success: function (data) {
                console.log(data);
                ToastDelete();
                setTimeout(() => window.location.replace("/accounttenant/detail" + data.accId), 2000);
            }
        });
    }
    else {
        DeleteAcc();
    }
}

function ToastDelete() {
    // Get the snackbar DIV
    var x = document.getElementById("toastDelete");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
}
$(document).ready(function () {
});

//#region Show button Save when change Img src
function ShowBtnSave() {
    document.getElementById("btn-save-img").style.display = 'block';
}
//#endregion

//#region Change Img 
function ChangeImg(src) {
    document.getElementById('output').src = window.URL.createObjectURL(src.files[0])
}
function Active() {
    var y = document.getElementById("Active").value;

    if (y == "active") {
        var x = document.getElementById("addActive");
        x.classList.add("active");
    }
}

function ActiveProfile() {
    var y = document.getElementById("ActiveProfile").value;

    if (y == "active") {
        var x = document.getElementById("addActiveProfile");
        x.classList.add("active");
    }

};
window.onload = function () {
    Active();
    ActiveProfile();
};

function ChangeImg(src) {
    document.getElementById('output').src = window.URL.createObjectURL(src.files[0])
}