//var typingTimer;               
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
//    SuggestLocations();
//}




function SuggestLocations() {
    var prompt = document.getElementById("searchInput").value;
    var ul = document.getElementById("locationslist");
    //change to value from json 
    $.ajax({
        url: '/forecastapicontroller/' + prompt,
        method: 'get',
        /* (xml, json, script, html).*/ 
        datatype: 'json',
        success: function (data) {  
            ul.replaceChildren();
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
    document.getElementById("searchInput").value = state + " | "+name + " (" + lat + ", " + lon + ")";
    document.getElementById("locationslist").replaceChildren();
    $.ajax({
        url: '/home/Forecast?lat=' + lat + "&lon=" + lon,
        method: 'post',
        /* (xml, json, script, html).*/
        datatype: 'json',
        success: function (data) {
        },
        error: function () {
            alert("Возникла ошибка при запросе");
        }
    });
}

$(document).keypress(function (e) {
    if (e.which == 13) {
        $("#searchButton").click();
    }
});