
window.onload = function () {
    //get the dropdown 
    alert("onload");
    var select = document.getElementById("Drop1");
    $("#Drop1").empty();
    $.ajax({
        type: "POST",
        url: "DropDownWS.asmx/Dropdown",
        data: "{}", // here we are specifing the data as a JSON object, not a string in JSON format
        // this will be converted into a form encoded format by jQuery
        // even though data is a JSON object, jQuery will convert it to "firstName=Aidy&lastName=F" so it *is* form encoded
        contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
        dataType: "json", // the data type we want back. The data will come back in JSON format
        cache: false,
        success: function (data) {
            var DataDesc = [1];
            var elements = Array();
            alert("ajax");
            elements = jQuery.parseJSON(data.d);
            alert(elements.length);
            for (var i = 0; i < elements.length; i++) {
                DataDesc.push({

                    ItemName: elements[i]['ClientID']

                    //ItemName4: elements[i]['Manager_Review']
                });
                //create the option and append to the dropdown
                var opt = DataDesc[i + 1].ItemName;
                       var el = document.createElement("option");
                el.textContent = opt;
                el.value = opt;
                select.appendChild(el);
                
            } alert(DataDesc.length);

        },
        failure: function (data) {
            alert("Failure");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
}
