using SR.Chat.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SR.Chat.Domain.Models;
using SR.Chat.Domain.Interfaces;

namespace SR.Chat.DataAccess.Repositories
{
    public class MessageRepository : GenericRepository<TMessage>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TMessage>> GetMessages()
        {
            return await _context.TMessage.OrderByDescending(m => m.DateMessage).Take(50).OrderBy(m => m.DateMessage).ToListAsync();
        }

        public void AddMessage(TMessage message)
        {
            _context.TMessage.AddAsync(message);
        }
    }
}
