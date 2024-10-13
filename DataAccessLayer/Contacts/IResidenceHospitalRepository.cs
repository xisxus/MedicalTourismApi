using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using DataAccessLayer.Entites.HospitalRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IResidenceHospitalRepository
    {
        Task<IEnumerable<ResidenceHospitalOutputModel>> GetAllHospitalsAsync();
        Task<ResidenceHospitalOutputModel> GetHospitalByIdAsync(int id);
        Task<ResidenceHospital> AddHospitalAsync(ResidenceHospitalInputModel model);
        Task<ResidenceHospital> UpdateHospitalAsync(int id, ResidenceHospitalInputModel model);
        Task<bool> DeleteHospitalAsync(int id);
    }
}
