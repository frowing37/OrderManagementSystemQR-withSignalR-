var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:7237/SignalRHub").build();
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = 'bold';
    span.textContent = user;
    li.appendChild(span);

    // Şablon dizisi kullanarak daha temiz bir mesaj oluşturulması
    li.innerHTML += `: ${message} - ${currentHour.toString().padStart(2, '0')}:${currentMinute.toString().padStart(2, '0')}`;

    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
