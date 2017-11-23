namespace Futbol5.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Futbol5Entities dbContext;
        private readonly IDatabaseFactory dbFactory;

        protected Futbol5Entities DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
