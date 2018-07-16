using Orleans;
using System;
using System.Threading.Tasks;

namespace MonthlyFollowUp.Interfaces
{
    public interface IUserRegistryGrain : IGrainWithIntegerKey
    {
        Task<long> GetNumberOfUser();
    }
}
