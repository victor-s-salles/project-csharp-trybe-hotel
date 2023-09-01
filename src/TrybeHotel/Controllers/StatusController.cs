using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

[Route("/")]
public class StatusController : Controller
{
    [HttpGet]
    public ActionResult GetStatus()
    {
        return Ok(new { message = "online" });
    }
}