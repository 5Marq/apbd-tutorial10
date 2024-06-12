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
    
    using var transaction = con.BeginTransaction();
    
    try
    {
       //recepta
        string insertQuery = @"
            INSERT INTO Prescription(Date, DueDate, IdPatient, IdDoctor)
            VALUES(@Date, @DueDate, @IdPatient, @IdDoctor)
        ";

        using (var cmd = new SqlCommand(insertQuery, con, transaction))
        {
            cmd.Parameters.AddWithValue("@Date", prescription.Date);
            cmd.Parameters.AddWithValue("@DueDate", prescription.DueDate);
            cmd.Parameters.AddWithValue("@IdPatient", prescription.Patient.IdPatient);
            cmd.Parameters.AddWithValue("@IdDoctor", prescription.IdDoctor);

            cmd.ExecuteNonQuery();
        }

        //ostatnia wartosc id prescription
        string selectMaxQuery = "SELECT MAX(IdPrescription) FROM Prescription";

        int prescriptionId;

        using (var cmd = new SqlCommand(selectMaxQuery, con, transaction))
        {
            var result = cmd.ExecuteScalar();
            prescriptionId = Convert.ToInt32(result);
        }

        // Jeśli recepta wstawiona to dodaj leki do Prescription_Medicament
        foreach (var medicament in prescription.Medicaments)
        {
            string insertMedicamentQuery = @"
                INSERT INTO Prescription_Medicament(IdPrescription, IdMedicament, Dose, Details)
                VALUES(@IdPrescription, @IdMedicament, @Dose, @Details)
            ";

            using (var cmd = new SqlCommand(insertMedicamentQuery, con, transaction))
            {
                cmd.Parameters.AddWithValue("@IdPrescription", prescriptionId);
                cmd.Parameters.AddWithValue("@IdMedicament", medicament.IdMedicament);
                cmd.Parameters.AddWithValue("@Dose", medicament.Dose);
                cmd.Parameters.AddWithValue("@Details", medicament.Details);

                cmd.ExecuteNonQuery();
            }
        }
        transaction.Commit();
        return prescriptionId;
    }
    catch (Exception ex)
    {
        transaction.Rollback();
        throw new Exception("An error occurred while creating the prescription: " + ex.Message);
    }
}
}