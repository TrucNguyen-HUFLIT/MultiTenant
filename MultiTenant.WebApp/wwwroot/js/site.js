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
            var error = data.responseText;
            if (error == " Email is already ") {
                document.getElementById("emailAlready").innerHTML = data.responseText;
                return;
            }
            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["accountEdit.Name"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValidation["accountEdit.Name"];
                else
                    document.getElementById("Err_Name").innerHTML = "";

                if (objectValidation["accountEdit.Email"] != undefined)
                    document.getElementById("Err_Email").innerHTML = objectValidation["accountEdit.Email"];
                else
                    document.getElementById("Err_Email").innerHTML = "";
            }
            catch {
                document.getElementById("Err_Name").innerHTML = "";
                document.getElementById("Err_Email").innerHTML = "";
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
            var error = data.responseText;
            if (error == " Database is already ") {
                document.getElementById("dataAlready").innerHTML = data.responseText;
                return;
            }
            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["tenantEdit.DbName"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValidation["tenantEdit.DbName"];
                else
                    document.getElementById("Err_Name").innerHTML = "";

            }
            catch {
                document.getElementById("Err_Name").innerHTML = "";
            }
        },

    });
});


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