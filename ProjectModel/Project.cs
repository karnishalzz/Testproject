using ProjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectModels
{
    public class Project : BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

       
    }
}
