using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShaCompanyName.ShaProjectName.Domain;
using ShaCompanyName.ShaProjectName.Services.NationalParks.DTO;
using Shesha;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ShaCompanyName.ShaProjectName.Services.NationalParks
{
    //[ApiVersion("1")]
    [Route("api/[controller]")]
    public class NationalParkService : SheshaAppServiceBase, INationalParkService
    {
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IRepository<NationalPark, Guid> _nationalParkRepository;

        public NationalParkService(IDynamicRepository dynamicRepository, IRepository<NationalPark, Guid> nationalParkRepository): base()
        {
            _dynamicRepository = dynamicRepository;
            _nationalParkRepository = nationalParkRepository;
        }

        [HttpPost, Route("Create")]
        public async Task<NationalParkDto> CreateNationalPark(NationalParkDto model)
        {
            var entity = await SaveOrUpdateEntityAsync<NationalPark>(null, async item =>
            {
                ObjectMapper.Map(model, item);
            });
            return ObjectMapper.Map<NationalParkDto>(entity);
        }


        [HttpGet, Route("{id}")]
        public async Task<NationalParkDto> GetNationalPark(Guid id)
        {
            var nationalPark = await _nationalParkRepository.GetAsync(id);

            if (nationalPark == null)
            {
                throw new Abp.Runtime.Validation.AbpValidationException("", new List<ValidationResult> { new ValidationResult($"No National Park found") });
            }

            return ObjectMapper.Map<NationalParkDto>(nationalPark);
        }

        [HttpGet, Route("GetAll")]
        public async Task<ICollection<NationalParkDto>> GetNationalParks()
        {
            var nationalParks = _nationalParkRepository.GetAll();

            if (nationalParks == null)
            {
                throw new Abp.Runtime.Validation.AbpValidationException("", new List<ValidationResult> { new ValidationResult($"No Student  found") });
            }

            return ObjectMapper.Map<ICollection<NationalParkDto>>(nationalParks);
        }

        [HttpGet, Route("Exists")]
        public Task<bool> NationalParkExistsName(string name)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("Exists/{id}")]
        public Task<bool> NationalParkExists(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("Update")]
        public async Task<NationalParkDto> UpdateNationalPark(NationalParkDto model)
        {
            var nationalPark = await SaveOrUpdateEntityAsync<NationalPark>(model.Id, async item =>
            {
                ObjectMapper.Map(model, item);
            });

            return ObjectMapper.Map<NationalParkDto>(nationalPark);
        }

        [HttpDelete, Route("{id}")]
        public async Task DeleteNationalPark(Guid id)
        {
            var nationalPark = await _nationalParkRepository.GetAsync(id);

            if (nationalPark != null)
            {
                _nationalParkRepository.Delete(nationalPark);
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }
    }
}
