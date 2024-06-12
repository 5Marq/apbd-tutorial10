using Microsoft.AspNetCore.Mvc;
using tutorial10.Models;
using tutorial10.Services;

namespace tutorial10.Controllers;

public class PrescriptionController : ControllerBase
{
  private IPrescriptionService _prescriptionService;

  public PrescriptionController(IPrescriptionService prescriptionService)
  {
    _prescriptionService = prescriptionService;
  }

  [HttpPost]
  public IActionResult CreatePrescription(Prescription prescription)
  {
    _prescriptionService.CreatePrescription(prescription);
    return StatusCode(StatusCodes.Status201Created);
  }
  
}