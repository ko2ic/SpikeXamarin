using System;
using System.Threading.Tasks;
using SpikeXamarin.Domains.Dto;
using SpikeXamarin.Infrastructures.Repositories;

namespace SpikeXamarin.Domains
{
    public class FirstDomain
    {
        public FirstDomain()
        {
        }

        public async Task<SearchResultDto> fetch()
        {
            // TODO ここはinterfaceを使うようにしたい
            var repository = new FirstRepository();
            return await repository.fetch();
        }
    }
}
