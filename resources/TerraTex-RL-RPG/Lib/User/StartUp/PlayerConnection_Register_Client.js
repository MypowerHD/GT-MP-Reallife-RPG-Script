API.onServerEventTrigger.connect(function(eventName) {
    if (eventName === "startRegister") {
        API.sendNotification("startRegister");
    }
});