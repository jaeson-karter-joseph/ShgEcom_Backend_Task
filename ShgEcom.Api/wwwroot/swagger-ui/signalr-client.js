(async function () {
    //Load SignalR library dynamically
    const script = document.createElement("script");
    script.src = "https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/7.0.5/signalr.min.js";
    script.onload = async function () {
        //Initialize SignalR connection
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/notificationHub") // Ensure this matches your SignalR endpoint
            .withAutomaticReconnect()
            .build();

        try {
            await connection.start();
            alert("✅ Connected to SignalR for product notifications");

            //Generic function to listen for any event
            function registerSignalRHandler(eventName) {
                connection.on(eventName, (message) => {
                    alert(`📢 Notification: ${message}`);
                    console.log(`📢 ${eventName}: ${message}`);
                });
            }

            // ✅ Register event listeners dynamically
            registerSignalRHandler("ProductAdded");
            registerSignalRHandler("ProductDeleted");

        } catch (err) {
            console.error("❌ SignalR Connection Error:", err);
        }
    };

    document.head.appendChild(script);
})();
