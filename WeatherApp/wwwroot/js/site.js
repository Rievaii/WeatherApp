//var typingTimer;                //timer identifier
//var doneTypingInterval = 3000;
//var $input = $('#searchInput');

//$input.on('keyup', function () {
//    clearTimeout(typingTimer);
//    typingTimer = setTimeout(doneTyping, doneTypingInterval);
//});

//$input.on('keydown', function () {
//    clearTimeout(typingTimer);
//});

//function doneTyping() {
//    //only if null
//    //$("#locations").empty();
//    var options = [];
//    //Get all suggested location
//    $.get(
//        "/forecastapicontroller/Moscow",
//        function (data) {
//            if (data.length > 0) {
//                for (let i = 0; i < data.length; i++) {
//                    options[i] = new Option(data[i].country +  "-" + data[i].state, data[i].name);
//                }
//                $("#locations").append(options);
//            }
//        }
//    );
//}





function SuggestLocations() {
    var prompt = document.getElementById("searchInput").value;
    var ul = document.getElementById("locationslist");
    
    $.ajax({
        url: '/forecastapicontroller/' + prompt,
        method: 'get',
        /* (xml, json, script, html).*/ 
        datatype: 'json',
        success: function (data) {  
            ul.replaceChildren();
            debugger;
            if (data.length > 0) {
                for (let i = 0; i < data.length; i++) {
                    var li = document.createElement("li");
                    li.classList.add("list-group-item");
                    var children = ul.children.length + 1
                    li.setAttribute("id", "element" + children)
                    li.setAttribute("style", "cursor:pointer")
                    //TODO: fix this trash TriggerSuggestion(state, name, lat, lon)
                    li.setAttribute("onclick", "TriggerSuggestion(" +
                        "'" + data[i].state + "'" + "," +
                        "'" + data[i].name + "'" + "," +
                        data[i].lat + "," +
                        data[i].lon + ")")
                    li.appendChild(document.createTextNode(data[i].country + "-" + data[i].state + " | " + data[i].name));
                    ul.appendChild(li)
                }
            }           
        },
        error: function () {
            alert("Возникла ошибка при запросе");
        }
    });
}
function TriggerSuggestion(state, name, lat, lon) {
    debugger;
    document.getElementById("searchInput").value = state + " | "+name + " (" + lat + ", " + lon + ")";
    document.getElementById("locationslist").replaceChildren();


    $.ajax({
        url: '/forecastapicontroller/' + prompt,
        method: 'get',
        /* (xml, json, script, html).*/
        datatype: 'json',
        success: function (data) {
           
        },
        error: function () {
            alert("Возникла ошибка при запросе");
        }
    });
}