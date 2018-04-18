using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using SpikeXamarin.Domains.Entities;


namespace SpikeXamarin.Domains.Dto
{
    public class SearchResultDto
    {
        [JsonProperty("total_count")]
        public int totalCount = 0;

        [JsonProperty("incomplete_results")]
        public bool isIncompleteResults = false;

        [JsonProperty("items")]
        public List<RepoEntity> items = new List<RepoEntity>();
    }
}
