using MonthlyFollowUp.Interfaces;
using Orleans;
using Orleans.Providers;
using System;
using System.Threading.Tasks;

namespace MonthlyFollowUp.Implementations
{
    [StorageProvider(ProviderName = "memory")]
    public class UserRegistryGrain : Grain<int>, IUserRegistryGrain
    {
        public Task<long> GetNumberOfUser()
        {
            return Task.FromResult(0L);
        }
    }
}
