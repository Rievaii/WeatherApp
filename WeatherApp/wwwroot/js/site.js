var typingTimer;                //timer identifier
var doneTypingInterval = 3000;  
var $input = $('#searchInput');

$input.on('keyup', function () {
    clearTimeout(typingTimer);
    typingTimer = setTimeout(doneTyping, doneTypingInterval);
});

$input.on('keydown', function () {
    clearTimeout(typingTimer);
});

function doneTyping() {
	debugger;
	//drop list
	$.ajax({
		url: '/ForecastApiController/' + "Moscow",   /* Куда пойдет запрос */
		method: 'get',             /* Метод передачи (post или get) */
		dataType: 'json',          /* Тип данных в ответе (xml, json, script, html). */ // сейчас метод возвращает объект
		success: function (response) {   /* функция которая будет выполнена после успешного запроса.  */
			alert(response);            /* В переменной data содержится ответ от index.php. */
		},
		error: function (error) {
			console.log(error)
		}
	});
}

