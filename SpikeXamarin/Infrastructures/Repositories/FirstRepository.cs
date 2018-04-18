using System;
using System.Threading.Tasks;
using SpikeXamarin.Domains.Dto;
using SpikeXamarin.Infrastructures.Repositories.Http;

namespace SpikeXamarin.Infrastructures.Repositories
{
    public class FirstRepository
    {
        public async Task<SearchResultDto> fetch()
        {
            return await new FirstHttpClient().fetch();
        }
    }
}
