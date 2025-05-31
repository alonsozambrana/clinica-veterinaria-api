using ClinicaVeterinariaAPI.Models;
using ClinicaVeterinariaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinariaAPI.Controllers;

[ApiController]
[Route("api/pets")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _repo;
    public PetController(IPetRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pet = await _repo.GetById(id);
        return pet == null ? NotFound() : Ok(pet);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pet pet)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await _repo.Add(pet));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pet pet)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _repo.Update(id, pet);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repo.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
