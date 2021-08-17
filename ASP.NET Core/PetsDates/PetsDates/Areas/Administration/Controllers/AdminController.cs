using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Areas.Administration.Controllers
{
    [Area(AdminArea)]
    [Authorize(Roles = Admin)]
    public abstract class AdminController : Controller
    {

    }
}
