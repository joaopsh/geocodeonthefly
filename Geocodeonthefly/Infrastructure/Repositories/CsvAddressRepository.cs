using System;
using System.Collections.Generic;
using Geocodeonthefly.Domain;
using Geocodeonthefly.Infrastructure.Interfaces;

namespace Geocodeonthefly.Infrastructure.Repositories
{
    public class CsvAddressRepository : IAddressRepository
    {
        public ICollection<Address> Read()
        {
            throw new NotImplementedException();
        }

        public void Write(ICollection<Address> addresses)
        {
            throw new NotImplementedException();
        }
    }
}
