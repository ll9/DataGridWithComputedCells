using System.Data;

namespace DataGridWithComputedCells.Repositories
{
    public interface IAdoRepository
    {
        void Fill(DataTable dataTable);
        void Update(DataTable dataTable);
    }
}