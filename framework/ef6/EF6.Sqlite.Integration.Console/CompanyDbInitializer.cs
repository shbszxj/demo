using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;

namespace EF6.Sqlite.Integration.Console
{
    public class CompanyDbInitializer : SqliteCreateDatabaseIfNotExists<CompanyContext>
    {
        public CompanyDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public CompanyDbInitializer(DbModelBuilder modelBuilder, bool nullByteFileMeansNotExisting) : base(modelBuilder, nullByteFileMeansNotExisting)
        {
        }
    }
}
