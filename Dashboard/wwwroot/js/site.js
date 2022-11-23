/**
 * Счетчик перехода по плиткам
 * @param {number} tile - Идентификатор плитки
 */
function tileclick(tile) {    
    $.post("/home/link/" + tile,
        {
            name: "example",
            city: "example"
        },
        function (data) {
            //resultData = JSON.stringify(data);
            //console.log(resultData);
        })
        .fail(function (data) {
            resultData = JSON.stringify(data);
            console.error("error: " + resultData);
        })
}