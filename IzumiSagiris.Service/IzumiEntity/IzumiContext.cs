using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagiris.Service.IzumiEntity
{
    public class IzumiContext : DbContext
    {
        public IzumiContext(string connectionName)
          : base(connectionName)
        {

        }

        public IzumiContext()
        {

        }
        public DbSet<StudentEntity> Student
        {
            get;
            set;
        }

        public DbSet<UserEntity> User
        {
            get;
            set;
        }
    }
}
