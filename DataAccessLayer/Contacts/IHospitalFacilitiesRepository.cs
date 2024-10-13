using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IHospitalFacilitiesRepository
    {
        Task<IEnumerable<HospitalFacilitiesOutModel>> GetAllHospitalFacilitiesAsync();
        Task<HospitalFacilitiesOutModel> GetHospitalFacilitiesByIdAsync(int id);
        Task<HospitalFacilitiesOutModel> CreateHospitalFacilitiesAsync(HospitalFacilitiesInModel model);
        Task<HospitalFacilitiesOutModel> UpdateHospitalFacilitiesAsync(int id, HospitalFacilitiesInModel model);
        Task<bool> DeleteHospitalFacilitiesAsync(int id);
    }
}
