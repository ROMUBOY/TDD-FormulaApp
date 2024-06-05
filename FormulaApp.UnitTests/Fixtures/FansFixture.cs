using FormulaApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FormulaApp.UnitTests.Fixtures
{
    public class FansFixture
    {
        public static List<Fan> GetFans() => new()
        {
            new Fan()
            {
                Email = "romualdo@test.com",
                Id = 1,
                Name = "Romualdo",
            },
            new Fan()
            {
                Email = "sonic@test.com",
                Id = 2,
                Name = "Sonic",
            }
        };
    }
}
