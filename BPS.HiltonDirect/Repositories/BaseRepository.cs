using BPS.HiltonDirect.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BPS.HiltonDirect.Model;

namespace BPS.HiltonDirect.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly HiltonDirectEntities context;

        public BaseRepository(HiltonDirectEntities context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

    partial class HiltonDirectEntities
    {
        private readonly IUserContext userContext;

        public HiltonDirectEntities(string connectionString, IUserContext userContext)
            : base(connectionString)
        {
            this.userContext = userContext;
        }

        public override int SaveChanges()
        {
            try
            {
                var username = userContext != null && userContext.User != null ? userContext.User.UserEmail : "No user set";
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {

                    }
                }
                throw ex;
            }
            catch (Exception ex)
            {
                var sqlException = ex.InnerException as SqlException;

                throw ex;
            }
        }
    }
}
