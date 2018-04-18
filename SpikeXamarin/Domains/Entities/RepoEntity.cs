using System;
using Newtonsoft.Json;

namespace SpikeXamarin.Domains.Entities
{
    public class RepoEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("stargazers_count")]
        public int Stars { get; set; }
        public PermissionDto permissions = new PermissionDto();
    }

    public class PermissionDto
    {
        public bool haveAdmin { get; set; }
        public bool havePushAuthorizetion { get; set; }
        public bool havePullAuthorizetion { get; set; }
    }
}
