using SR.Chat.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SR.Chat.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<TMessage>> GetMessages();

        void AddMessage(TMessage message);
    }
}
