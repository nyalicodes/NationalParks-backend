using Abp.Application.Services;
using ShaCompanyName.ShaProjectName.Services.NationalParks.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShaCompanyName.ShaProjectName.Services.NationalParks
{
    public interface INationalParkService: IApplicationService
    {
        Task<NationalParkDto> CreateNationalPark(NationalParkDto model);
        Task<NationalParkDto> GetNationalPark(Guid id);
        Task<ICollection<NationalParkDto>> GetNationalParks();
        Task<NationalParkDto> UpdateNationalPark(NationalParkDto model);
        Task DeleteNationalPark(Guid id);
        Task<bool> NationalParkExistsName(string name);
        Task<bool> NationalParkExists(Guid id);

    }
}
