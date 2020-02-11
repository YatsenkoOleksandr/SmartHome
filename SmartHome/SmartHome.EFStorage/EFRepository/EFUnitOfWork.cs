using SmartHome.EFStorage.EFContext;
using SmartHome.Entities.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.EFStorage.EFRepository
{
    public sealed class EFUnitOfWork : IUnitOfWork
    {
        private SmartHomeContext dbContext;

        public EFUnitOfWork(SmartHomeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(dbContext);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        
        private bool disposedValue = false; 

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {                    
                    dbContext.Dispose();
                }

                disposedValue = true;
            }
        }
        
        ~EFUnitOfWork() {           
            Dispose(false);
        }
        
        public void Dispose()
        {            
            Dispose(true);            
            GC.SuppressFinalize(this);
        }        
    }
}
