using PetStoreTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreTests.Models
{
    class Pet
    {
        public long id { get; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<string> tags { get; set; }
        public string status { get; set; }


        public Pet(long id, string name, List<string> photoUrls, List<string> tags, string status)
        {
            this.id = id;
            this.name = name;
            this.photoUrls = photoUrls;
            this.tags = tags;
            this.status = status;
        }
    }
}
