using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Models
{
    public class Project
    {

        private string name;
        private string description;
        private string link;

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string Link { get { return link; } }

        public Project (string projectName, string projectDescription, string projectLink)
        {
            name = projectName;
            description = projectDescription;
            link = projectLink;
        }

    }
}
