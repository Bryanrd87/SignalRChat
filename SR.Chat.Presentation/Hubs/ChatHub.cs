using Microsoft.AspNetCore.SignalR;
using SR.Chat.Service.Interface;
using System.Threading.Tasks;

namespace SR.Chat.Presentation.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IStockService _iStockService;

        public ChatHub(IStockService iStockService)
        {
            _iStockService = iStockService;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            if (message.ToLower().Contains("/stock="))
            {
                user = "StockBot";
                var botResponse = _iStockService.BotDetection(message);
                if (botResponse.Detected)
                    if (botResponse.IsSuccessful)
                        await Clients.All.SendAsync("ReceiveMessage", user, $"{botResponse.Symbol} quote is ${botResponse.Close} per share.");
                    else
                        await Clients.All.SendAsync("ReceiveMessage", user, $"Oops! something went wrong.");
            }
        }
    }
}