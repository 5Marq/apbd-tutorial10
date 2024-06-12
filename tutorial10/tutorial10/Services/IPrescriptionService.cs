using tutorial10.Models;

namespace tutorial10.Services;

public interface IPrescriptionService
{
    int CreatePrescription(Prescription prescription);
}