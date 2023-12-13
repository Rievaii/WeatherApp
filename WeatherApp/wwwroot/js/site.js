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



//$.ajax({
//	url: '/forecastapicontroller/' + data,   /* куда пойдет запрос */
//	method: 'get',             /* метод передачи (post или get) */
//	datatype: 'json',          /* тип данных в ответе (xml, json, script, html). */ // сейчас метод возвращает объект
//	success: function (response) {   /* функция которая будет выполнена после успешного запроса.  */
//		alert(response);            /* в переменной data содержится ответ от index.php. */
//	},
//	error: function (error) {
//		console.log(error)
//	}
//});

function SuggestLocations() {
    var prompt = document.getElementById("searchInput").value;
    var ul = document.getElementById("locationslist");
    
    //Get all suggested location
    $.get(
        "/forecastapicontroller/"+ prompt,
        function (data) {
            ul.replaceChildren();
            if (data.length > 0) {
                for (let i = 0; i < data.length; i++) {
                    var li = document.createElement("li");
                    li.classList.add("list-group-item");
                    var children = ul.children.length + 1
                    li.setAttribute("id", "element" + children)
                    li.appendChild(document.createTextNode(data[i].country + "-" + data[i].state + " | " +data[i].name));
                    ul.appendChild(li)
                }
                $("#locations").append(options);
            }
        }
    );
}
