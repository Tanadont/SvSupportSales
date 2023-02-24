using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SvSupportSales.Entities;

namespace SvSupportSales.Repositories
{
    public interface IUmRepository
    {/*
        void Save(MasUser user);
        MasUser? FindById(int userId);*/
    }

    public class UmRepository : IUmRepository
    {/*
        private DataContext context;

        public UmRepository(DataContext context) 
        {
            this.context = context;
        }

        private bool disposed = false;

        public void Save(MasUser user)
        {
            context.MasUsers.Add(user);
            context.SaveChanges();           
        }

        public MasUser? FindById(int id) {
            //context.MasRoles.Where(role=>role.RoleId == id).FirstOrDefault();            

            string query = $"SELECT * FROM mas_user WHERE \"userId\" = {id}";    
            return context.MasUsers.FromSqlRaw(query).AsNoTracking().FirstOrDefault();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) 
                {
                    //release managed resources
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/
    }
}
