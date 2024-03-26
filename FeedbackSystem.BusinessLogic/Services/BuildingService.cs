using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Services
{
	public class BuildingService : IBuildingService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<UserModel> _userManager;
        public BuildingService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<UserModel> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<BuildingDto> CreateBuilding(BuildingDto buildingDto)
		{
			try
			{
				var actuaclBuilding = _mapper.Map<Building>(buildingDto);
                if (actuaclBuilding != null)
				{
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actuaclBuilding.UserId = user.Id;
					actuaclBuilding.CreatedAt = DateTime.Now;
					await _unitOfWork.Buildings.CreateAsync(actuaclBuilding);
					_unitOfWork.Save();
				}
				return buildingDto;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task DeleteBuilding(long Id)
		{
			try
			{

				var building = await _unitOfWork.Buildings.GetByLongIdAsync(Id);
				if (building != null)
				{
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    building.UserId = user.Id;
                    await _unitOfWork.Buildings.DeleteAsync(building);
					_unitOfWork.Save();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<IEnumerable<BuildingDto>> GetAllBuildings()
		{
			try
			{
				var allBuildings = await _unitOfWork.Buildings.GetAllAsync();
				var buildings = allBuildings.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<BuildingDto>>(buildings);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<BuildingDto> GetBuildingById(long Id)
		{
			try
			{
				var building = await _unitOfWork.Buildings.GetByLongIdAsync(Id);
				return _mapper.Map<BuildingDto>(building);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async Task<BuildingDto> UpdateBuilding(BuildingDto buildingDto)
		{
			try
			{
				if (buildingDto != null)
				{
					var updatedBuilding = _mapper.Map<Building>(buildingDto);
					if (updatedBuilding != null)
					{
                        var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                        updatedBuilding.UserId = user.Id;

                        await _unitOfWork.Buildings.UpdateAsync(updatedBuilding);
						_unitOfWork.Save();
					}
				}
				return buildingDto;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
