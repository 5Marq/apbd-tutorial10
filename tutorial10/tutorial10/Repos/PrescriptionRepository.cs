using tutorial10.Models;

namespace tutorial10.Repos;

public class PrescriptionRepository : IPrescriptionRepository
{

    private readonly IConfiguration _configuration;

    public int CreatePrescription(Prescription prescription)
    {
        return 0;
    }
}