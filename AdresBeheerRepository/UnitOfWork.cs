using System;
using System.Collections.Generic;
using System.Text;

namespace AdresBeheerRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AdresContext ctx;
        public IAdresRepository adresRepo { get; private set; }

        public UnitOfWork(AdresContext ctx)
        {
            this.ctx = ctx;
            adresRepo = new AdresRepository(ctx);
        }

        public void Complete()
        {
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
