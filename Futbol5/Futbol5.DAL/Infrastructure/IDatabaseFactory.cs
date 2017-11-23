using System;

namespace Futbol5.DAL.Infrastructure 
{
    public interface IDatabaseFactory : IDisposable
    {
        Futbol5Entities Get();
    }
}
