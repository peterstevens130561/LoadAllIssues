using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class Permission
    {
        public string key { get; set; }
        public int usersCount { get; set; }
        public int groupsCount { get; set; }
    }

    public class PermissionTemplate
    {
        public string id { get; set; }
        public string name { get; set; }
        public string projectKeyPattern { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public List<Permission> permissions { get; set; }
        public string description { get; set; }
    }

    public class DefaultTemplate
    {
        public string templateId { get; set; }
        public string qualifier { get; set; }
    }

    public class PermissionTemplates
    {
        public List<PermissionTemplate> permissionTemplates { get; set; }
        public List<DefaultTemplate> defaultTemplates { get; set; }
    }
}
