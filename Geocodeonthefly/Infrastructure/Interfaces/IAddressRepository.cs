using System.Collections.Generic;
using Geocodeonthefly.Domain;

namespace Geocodeonthefly.Infrastructure.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> Read();

        void Write(ICollection<Address> addresses);
    }
}
