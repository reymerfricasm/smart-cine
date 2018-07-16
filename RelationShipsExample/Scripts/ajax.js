$(document).ready(function () {
   loadMovies();
});

function loadMovies() {
    $.ajax({
        url: "Home/GetLastMovie",
        method: "post",
        dataType: "json",
        success: function (jResponse, xhr) {
            console.log(jResponse);

            var table = document.getElementById('movie');
            var index = 0;
            var p = 0;
            for (var i = 1; i <= jResponse.length; i++) {
                table.rows[i].cells[index].innerText = jResponse[p];
                index++;
                p++;
                if (index === 1) {
                    table.insertRow();
                    i++;
                    table.rows[i].insertCell();
                    index--;
                    i--;
                }
            }
        },
        error: function (xhr) {
            console.log(xhr.status + " " + xhr.statusText);
        }
    });
}
//function loadSchelude() {
//    $.ajax({
//        url: "Home/GetLastSchelude",
//        method: "post",
//        dataType: "json",
//        success: function (jResponse) {
//            console.log(jResponse);
//        },
//        error: function (xhr) {
//            console.log(xhr.status + " " + xhr.statusText);
//        }
//    });
//}
//function loadRecent() {
//    $.ajax({
//        url: "Home/GetLastRecent",
//        method: "post",
//        dataType: "json",
//        success: function (jResponse) {
//            console.log(jResponse);
//        },
//        error: function (xhr) {
//            console.log(xhr.status + " " + xhr.statusText);
//        }
//    });
//}
