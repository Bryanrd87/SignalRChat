using System;

namespace SR.Chat.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMessageRepository Messages { get; }       
        int Complete();
    }
}
