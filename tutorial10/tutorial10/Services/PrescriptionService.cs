using tutorial10.Models;
using tutorial10.Repos;

namespace tutorial10.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }
    
    public int CreatePrescription(Prescription prescription)
    {
        return _prescriptionRepository.CreatePrescription(prescription);
    }
}