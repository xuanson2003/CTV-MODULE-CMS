using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Models;
using System.Collections.Generic;

namespace OcdServiceMono.API.Models.Dtos
{
    public class SM_MenuRq : SM_Menu
    {
        public List<Dictionary<string>> Props { get; set; } = new List<Dictionary<string>>();
    }
}
