using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets();

app.Map("/ws", async context =>
{
    // check if the request is a WebSocket establishment request
    if (context.WebSockets.IsWebSocketRequest)
    {
        // accept socket, TCP connection
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        var rand = new Random();

        while (true)
        {
            byte[] data = Encoding.ASCII.GetBytes($"{DateTime.Now}");

            // send data
            await webSocket.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);

            await Task.Delay(1000);

            long r = rand.NextInt64(0, 10);

            if (r == 7)
            {
                // close socket
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "random closing", CancellationToken.None);
                return;
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

app.Run("http://localhost:5050");