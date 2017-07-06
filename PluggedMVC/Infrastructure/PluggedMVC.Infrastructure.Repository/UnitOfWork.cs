using PluggedMVC.Core.Data.Base;
using System;
using System.Data;
using System.Data.Entity;

namespace PluggedMVC.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public bool KeepContextLive { get; set; }

        public DbContext DbContext { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int Commit()
        {
            try
            {
                return DbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Dispose()
        {
            if (!this.KeepContextLive)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DbContext != null && this.DbContext.Database.Connection.State == ConnectionState.Open)
                {
                    this.DbContext.Database.Connection.Close();
                }

                if (this.DbContext != null)
                {
                    this.DbContext.Dispose();
                }
            }
        }
    }
}
