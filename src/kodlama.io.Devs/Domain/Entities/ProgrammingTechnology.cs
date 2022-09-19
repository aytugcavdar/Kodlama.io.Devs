using Kodlama.io.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingTechnology:Entity
    {    

        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        
        public string ImageUrl { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingTechnology()
        {

        }
        public ProgrammingTechnology(int id,int programmingLanguageId, string name, string ımageUrl):this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            ImageUrl = ımageUrl;
            
        }
    }
}
