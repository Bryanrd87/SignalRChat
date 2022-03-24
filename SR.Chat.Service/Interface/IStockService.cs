using SR.Chat.Domain.Models;

namespace SR.Chat.Service.Interface
{
    public interface IStockService
    {
        BotModel BotDetection(string message);
    }
}
