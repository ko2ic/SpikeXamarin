using System;

namespace SpikeXamarin.Domains.Entities
{
    public class RepoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
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
