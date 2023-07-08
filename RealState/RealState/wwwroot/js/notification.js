//"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/notificationHub").build();



//connection.on("BookedPlotCount", function (count) {
//    var bookedPlothtml = document.getElementById("result");
//    console.log(count);
//    bookedPlothtml.innerText = `${count}`;
//});


//function newWindowLoadedOnClient() {
//    connection.send("SendBookedPlotCount");
//}

//function fullfilled() {
//    newWindowLoadedOnClient();
//}

//function rejected() {
//    console.log("connection hub rejected")
//}

//connection.start().then(fullfilled, rejected);


var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/notificationHub").build();

connection.on("BookedPlotCount", function (bookedPlotCount) {
    // Update the plot count in the UI
    $("#result").text(bookedPlotCount);
});

connection.start().then(function () {
    // Connection established
    console.log("SignalR connection established.");
}).catch(function (err) {
    // Failed to establish connection
    console.error(err.toString());
});


