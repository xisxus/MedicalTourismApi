using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<HotelOutputModel>>> GetAllHotelsAsync()
        {
            var hotels = await _context.Hotels.Select(h => new HotelOutputModel
            {
                HotelID = h.HotelID,
                HotelName = h.HotelName,
                Address = h.Address,
                City = h.City,
                Country = h.Country,
                Rate = h.Rate,
                CreatedAt = h.CreatedAt,
                UpdatedAt = h.UpdatedAt
            }).ToListAsync();

            return new ServiceResponse<List<HotelOutputModel>>(hotels);
        }

        public async Task<ServiceResponse<HotelOutputModel>> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotels
                .Where(h => h.HotelID == id)
                .Select(h => new HotelOutputModel
                {
                    HotelID = h.HotelID,
                    HotelName = h.HotelName,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    Rate = h.Rate,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt
                }).FirstOrDefaultAsync();

            return new ServiceResponse<HotelOutputModel>(hotel);
        }

        public async Task<ServiceResponse<HotelOutputModel>> AddHotelAsync(HotelInputModel inputModel)
        {
            var hotel = new Hotel
            {
                HotelName = inputModel.HotelName,
                Address = inputModel.Address,
                City = inputModel.City,
                Country = inputModel.Country,
                Rate = inputModel.Rate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return await GetHotelByIdAsync(hotel.HotelID);
        }

        public async Task<ServiceResponse<HotelOutputModel>> UpdateHotelAsync(int id, HotelInputModel inputModel)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return new ServiceResponse<HotelOutputModel>(null, false, "Hotel not found");

            hotel.HotelName = inputModel.HotelName;
            hotel.Address = inputModel.Address;
            hotel.City = inputModel.City;
            hotel.Country = inputModel.Country;
            hotel.Rate = inputModel.Rate;
            hotel.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetHotelByIdAsync(hotel.HotelID);
        }

        public async Task<ServiceResponse<bool>> DeleteHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null) return new ServiceResponse<bool>(false, false, "Hotel not found");

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
