using DataGridWithComputedCells.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithComputedCells.Repositories
{
    class PersonRepository
    {
        private readonly DbContext _context;
        private readonly string _tableName = "Person";

        public PersonRepository(DbContext context)
        {
            _context = context;
        }

        public void Fill (DataTable dataTable)
        {
            var query = $"SELECT *, MAX(ROWID) AS MAX_ROWID FROM {_tableName}";

            using (var connection = _context.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var builder = new SQLiteCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();
                adapter.InsertCommand = builder.GetInsertCommand();

                adapter.Fill(dataTable);
            }
        }

        public void Update(DataTable dataTable)
        {
            var query = $"SELECT *, MAX(ROWID) AS MAX_ROWID FROM {_tableName}";

            using (var connection = _context.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var builder = new SQLiteCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();
                adapter.InsertCommand = builder.GetInsertCommand();

                adapter.Update(dataTable);
            }
        }
    }
}
