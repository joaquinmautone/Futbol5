namespace Futbol5.DAL.Infrastructure 
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private Futbol5Entities dataContext;

        public Futbol5Entities Get()
        {
            return dataContext ?? (dataContext = new Futbol5Entities());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null) dataContext.Dispose();
        }
    }
}
