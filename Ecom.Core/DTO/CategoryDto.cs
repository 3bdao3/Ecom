using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO
{
    public record CategoryDto
    (string Name,string Discrption);
    public record UpdateCategoryDto(string Name,string Discrption,int id);
}
