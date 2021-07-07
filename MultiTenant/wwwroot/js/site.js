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

                if (objectValidation["Name"] != undefined)
                    document.getElementById("Err_Name").innerHTML = objectValidation["Name"];
                else
                    document.getElementById("Err_Name").innerHTML = "";
                if (objectValidation["Age"] != undefined)
                    document.getElementById("Err_Age").innerHTML = objectValidation["Age"];
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
