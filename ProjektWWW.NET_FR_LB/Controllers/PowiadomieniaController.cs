using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
public class PowiadomieniaController : Controller
{
    private readonly IPowiadomienieRepository _repo;
    public PowiadomieniaController(IPowiadomienieRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Lista()
    {
        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
        var powiadomienia = _repo.PobierzDlaUzytkownika(userId);
        return View(powiadomienia);
    }
}