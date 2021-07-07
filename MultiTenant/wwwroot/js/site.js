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

            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["accountEdit.Name"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValidation["accountEdit.Name"];
                else
                    document.getElementById("Err_Name").innerHTML = "";

                if (objectValidation["accountEdit.Age"] != undefined)
                    document.getElementById("Err_Age").innerHTML = objectValidation["accountEdit.Age"];
                else
                    document.getElementById("Err_Age").innerHTML = "";
            }
            catch {
                document.getElementById("Err_Name").innerHTML = "";
                document.getElementById("Err_Age").innerHTML = "";
            }
        },

    });
});


$(document).ready(function () {
});


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