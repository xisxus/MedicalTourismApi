using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IFacilitiesRepository
    {
        Task<IEnumerable<FacilitiesOutputModel>> GetAllFacilitiesAsync();
        Task<FacilitiesOutputModel> GetFacilitiesByIdAsync(int id);
        Task<FacilitiesOutputModel> AddFacilitiesAsync(FacilitiesInputModel inputModel);
        Task<FacilitiesOutputModel> UpdateFacilitiesAsync(int id, FacilitiesInputModel inputModel);
        Task<bool> DeleteFacilitiesAsync(int id);
    }
}
