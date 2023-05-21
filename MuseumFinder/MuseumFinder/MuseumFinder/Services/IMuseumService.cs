using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumFinder.Model;
namespace MuseumFinder.Services
{
    public interface IMuseumService
    {
        Task<List<MuseumModels>> GetMuseumList();

        Task<int> AddMuseum(MuseumModels museumModel);

        Task<int> DeleteMuseum(MuseumModels museumModel);

        Task<int> UpdateMuseum(MuseumModels museumModel);
    }
}
