using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShaCompanyName.ShaProjectName.Services.NationalParks.DTO
{
    public class NationalParkDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Established { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string POBox { get; set; }
        public string FullAddress { get; set; }
    }
}
