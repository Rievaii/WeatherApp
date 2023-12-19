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
    debugger;

    $.ajax({
        url: '/forecastapicontroller/' + prompt,
        method: 'get',
        /* (xml, json, script, html).*/ 
        datatype: 'json',
        success: function (data) {  
            ul.replaceChildren();
            if (data.length > 0) {
                for (let i = 0; i < data.length; i++) {
                    //6 - max li elements - const fixed by UI 
                    if (i < 6) {
                        var li = document.createElement("li");
                        li.classList.add("list-group-item");
                        var children = ul.children.length + 1
                        li.setAttribute("id", "element" + children)
                        li.setAttribute("style", "cursor:pointer")
                        //TODO: fix this trash TriggerSuggestion(state, name, lat, lon)
                        li.setAttribute("onclick", "TriggerSuggestion(" +
                            "'" + data[i].state + "'" + "," +
                            "'" + data[i].name + "'" + "," +
                            data[i].coord.lat + "," +
                            data[i].coord.lon + ")")
                        li.appendChild(document.createTextNode(data[i].country + (data[i].state ? " - " + data[i].state : "") + " | " + data[i].name));
                        ul.appendChild(li)
                    }
                }
            }           
        },
        error: function (error) {
            alert(error);
        }
    });
}

function TriggerSuggestion(state, name, lat, lon) {
    document.getElementById("searchInput").value = "";
    document.getElementById("searchInput").placeholder = name + (state ? " | " + state : "") + " (" + lat + ", " + lon + ")" ;
    //$('#ForecastPartial').load('/home/Forecast?lat=' + lat + "&lon=" + lon);

    $.ajax({
        url: '/home/Forecast?lat=' + lat + "&lon=" + lon,
        method: 'post',
        /* (xml, json, script, html).*/
        datatype: 'json',
        success: function (response) {
            $('#ForecastPartial').html(response);
            document.getElementById("locationslist").replaceChildren();
        },
        error: function () {
            alert("Возникла ошибка при запросе");
        }
    });
}

$(document).unbind('keypress').bind('keypress', function (e) {
    if (e.which == 13) {
        if (document.getElementById("searchInput").value.length > 0) {
                SuggestLocations();
        }
    }
});
