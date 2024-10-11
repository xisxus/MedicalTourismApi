using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IHotelRepository
    {
        Task<ServiceResponse<List<HotelOutputModel>>> GetAllHotelsAsync();
        Task<ServiceResponse<HotelOutputModel>> GetHotelByIdAsync(int id);
        Task<ServiceResponse<HotelOutputModel>> AddHotelAsync(HotelInputModel inputModel);
        Task<ServiceResponse<HotelOutputModel>> UpdateHotelAsync(int id, HotelInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteHotelAsync(int id);
    }

}
