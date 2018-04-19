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

        public async Task<SearchResultDto> fetch(string freeword, int pageNo)
        {
            // TODO ここはinterfaceを使うようにしたい
            var repository = new FirstRepository();
            return await repository.fetch(freeword, pageNo);
        }
    }
}
