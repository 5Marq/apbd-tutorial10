using tutorial10.Models;

namespace tutorial10.Repos;

public interface IPrescriptionRepository
{
    int CreatePrescription(Prescription prescription);
}