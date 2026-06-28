using DataAccess;
using DataTypes.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace DentalSystemAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : Controller
{
  private readonly PatientServices _patientServices;

  public PatientController(AppDbContext context)
  {
    _patientServices = new PatientServices(context);
  }
  [HttpGet]
  [EnableCors("AllowOrigin")]
  [Route("GetAllPatients")]
  public async Task<IEnumerable<Patient>> GetAllPatients()
  {
    return await _patientServices.GetAllPatients();
  }
  [HttpGet]
  [EnableCors("AllowOrigin")]
  [Route("GetPatientById/{id}")]
  public async Task<ActionResult<Patient?>> GetPatientById(int id)
  {
    var result = await _patientServices.GetPatientById(id);
    if (result == null)
      return null;
    return Ok(result);
  }

  [HttpPost]
  [EnableCors("AllowOrigin")]
  [Route("AddPatient")]
  public async Task<ActionResult<Patient>>AddPatient([FromBody]Patient patient)
  {
    var result = await _patientServices.AddPatient(patient);

    if (result == null)
      return BadRequest();

    return CreatedAtAction(nameof(GetPatientById), new { id = result.Id }, result);
  }

   
}