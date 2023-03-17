using System;
using NativeWebSocket;
using UnityEngine;

namespace WebSocket
{
    public class WebSocketManager
    {
        private static readonly Lazy<WebSocketManager> lazy = new(() =>
        {
            var i = new WebSocketManager();
            i.Start("ws://127.0.0.1:9527?user=1");
            return i;
        });

        public static WebSocketManager Instance => lazy.Value;

        private NativeWebSocket.WebSocket websocket;

        // Start is called before the first frame update
        private async void Start(string url)
        {
            websocket = new NativeWebSocket.WebSocket(url);
            websocket.OnOpen += () => { Debug.Log("Connection open!"); };
            websocket.OnError += (e) => { Debug.Log("Error! " + e); };
            websocket.OnClose += (e) => { Debug.Log("Connection closed!"); }; websocket.OnMessage += (bytes) =>
            {
                Debug.Log("OnMessage!");
                Debug.Log(bytes);
            };
            // Keep sending messages at every 0.3s
            // InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);
            // waiting for messages
            await websocket.Connect();
        }

        private void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            websocket.DispatchMessageQueue();
#endif
        }

        private async void SendWebSocketMessage()
        {
            if (websocket.State == WebSocketState.Open)
            {
                // Sending bytes
                await websocket.Send(new byte[] {10, 20, 30});

                // Sending plain text
                await websocket.SendText(@"plain text message");
            }
        }

        private async void OnApplicationQuit()
        {
            await websocket.Close();
        }
    }
}