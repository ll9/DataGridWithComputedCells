using DataGridWithComputedCells.Factories;
using DataGridWithComputedCells.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithComputedCells.Presenter
{
    public class Presenter
    {
        private readonly Form1 _view;
        private readonly IAdoRepository _personRepository = RepositoryFactory.GetRepository<PersonRepository>();
        private DataTable _dataTable = new DataTable();

        public Presenter(Form1 dialog)
        {
            _view = dialog;
            Setup();
            InitEvents();
        }

        private void InitEvents()
        {
            _dataTable.RowChanged += UpdateDatabaseOnRowChanged;
        }

        private void UpdateDatabaseOnRowChanged(object sender, DataRowChangeEventArgs e)
        {
            _personRepository.Update(_dataTable);
        }

        private void Setup()
        {
            _personRepository.Fill(_dataTable);
            _view.DataSource = _dataTable;
        }
    }
}
