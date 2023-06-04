using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models.Interfaces;

namespace UniProjectTests.Data.Services.Classes
{
    internal class DummyEntity : IId
    {
        public string Id { get; set; }
       
        public DummyEntity(string id)
        {
            Id = id;
        }
    }
}
