using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;//先安裝nuget套件(websockets)才能using

namespace _08WebSocket.Controllers
{
    public class ChatController : ApiController
    {
        public HttpResponseMessage Get(string user)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(user));

            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);            //收到一個request後廣播給所有client
        }
        class ChatWebSocketHandler : WebSocketHandler
        {
            string _user;                            //取名前要加一底線
            static WebSocketCollection _chatClients = new WebSocketCollection();

            public ChatWebSocketHandler(string user) {
                _user = user;
            }

            public override void OnOpen()               //override表示覆寫某個已存在的函數，
            {     
                _chatClients.Add(this);                 //加入目前連進來的人到chatclients中
            }
            public override void OnMessage(string message)
            {
                _chatClients.Broadcast(_user+" "+message);
            }

        }

    }
}
