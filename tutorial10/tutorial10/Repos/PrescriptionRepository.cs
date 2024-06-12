using System.Data.SqlClient;
using tutorial10.Models;

namespace tutorial10.Repos;

public class PrescriptionRepository : IPrescriptionRepository
{

    private readonly IConfiguration _configuration;

    public PrescriptionRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public int CreatePrescription(Prescription prescription)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Prescription(Date, DueDate, IdPatient, IdDoctor) " +
                          "VALUES(@Date, @DueDate, @IdPatient, @IdDoctor)";
        cmd.Parameters.AddWithValue("@Date", prescription.Date);
        cmd.Parameters.AddWithValue("@DueDate", prescription.DueDate);
        cmd.Parameters.AddWithValue("@IdPatient", prescription.Patient.IdPatient);
        cmd.Parameters.AddWithValue("@IdDoctor", prescription.IdDoctor);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}