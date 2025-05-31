using ClinicaVeterinariaAPI.Models;
using ClinicaVeterinariaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinariaAPI.Controllers;

[ApiController]
[Route("api/tutores")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _repo;
    public TutorController(ITutorRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tutor = await _repo.GetById(id);
        return tutor == null ? NotFound() : Ok(tutor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tutor tutor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await _repo.Add(tutor));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Tutor tutor)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _repo.Update(id, tutor);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repo.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
