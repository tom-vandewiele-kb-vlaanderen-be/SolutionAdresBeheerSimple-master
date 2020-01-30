using System;
using System.Collections.Generic;
using System.Text;

namespace AdresBeheerRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
        IAdresRepository adresRepo { get; }        
    }
}
