# RefreshDataSignalR

## Components
- Server: Web Service includes: 
    - SignalR: for connect, get and refresh data
    - Restful: for manager user connect
- ClientConsole: 


## Package
- Dotnet: 
    ```
    dotnet add package Microsoft.AspNetCore.SignalR // server
    dotnet add package Microsoft.AspNetCore.SignalR.Client // client
    ```
- Download and import
    ```
    npm install @microsoft/signalr // download
    <script src="~/lib/signalr/signalr.js"></script>  // import
    ```
- cdn 
    ```
    <script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/6.0.1/signalr.js"></script>
    ```

## Postman
- Collection: RefreshDataSignalR.postman_collection.json

## References
- https://www.freecodespot.com/blog/display-database-change-notification-using-signalr/
- https://code-maze.com/how-to-send-client-specific-messages-using-signalr/
- https://stackoverflow.com/questions/20908620/how-to-obtain-connection-id-of-signalr-client-on-the-server-side?fbclid=IwAR0lLx1s0FeF6XHE9rlBPmbXP6XNZN8XNXBs5jVuEsBXbUF4LXbk5a_TmIk