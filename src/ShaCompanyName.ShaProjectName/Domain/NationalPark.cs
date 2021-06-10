using Abp.Domain.Entities.Auditing;
using Shesha.Authorization.Users;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShaCompanyName.ShaProjectName.Domain
{
    
    public class NationalPark: Address
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Established { get; set; }

    }
}
