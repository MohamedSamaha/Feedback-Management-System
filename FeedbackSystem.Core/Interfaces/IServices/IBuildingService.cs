using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
	public interface IBuildingService
	{
		Task<IEnumerable<BuildingDto>> GetAllBuildings();
		Task<BuildingDto> GetBuildingById(long Id);
		Task<BuildingDto> CreateBuilding(BuildingDto buildingDto);
		Task<BuildingDto> UpdateBuilding(BuildingDto buildingDto);
		Task DeleteBuilding(long Id);
	}
}
