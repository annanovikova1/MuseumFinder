using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumFinder.Model;
namespace MuseumFinder.Services
{
    [Table("MuseumModels")]
    public class MuseumService : IMuseumService
    {
      
       
            private SQLiteAsyncConnection _dbConnection;

            public MuseumService()
            {
                SetUpDb();
            }

            private async void SetUpDb()
            {
                if (_dbConnection == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MuseumFinderDB.db3");
                    _dbConnection = new SQLiteAsyncConnection(dbPath);
                    await _dbConnection.CreateTableAsync<MuseumModels>();
                   // await _dbConnection.CreateTableAsync<CollectionModel>();
                }

            }
            public Task<int> AddMuseum(MuseumModels museumModel)
            {
                return _dbConnection.InsertAsync(museumModel);
            }

            public Task<int> DeleteMuseum(MuseumModels museumModel)
            {
                return _dbConnection.DeleteAsync(museumModel);
            }

            public async Task<List<MuseumModels>> GetMuseumList()
            {

                var museumList = await _dbConnection.Table<MuseumModels>().ToListAsync();

                return museumList;

            }

            public Task<int> UpdateMuseum(MuseumModels museumModel)
            {
                return _dbConnection.UpdateAsync(museumModel);
            }
        }
}
