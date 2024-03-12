using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Utils
{
    public class BKDatabase
    {
        private readonly string _connectionString;

        public BKDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static void BackupDatabase(string databaseName)
        {
            string backupQuery = $"BACKUP DATABASE {databaseName} TO DISK = 'D:\\Uduino\\TT.BAK'";

            using (var context = new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString))
            {
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, backupQuery);
            }

        }
        

    }
}
