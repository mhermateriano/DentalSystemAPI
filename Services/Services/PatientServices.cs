using DataAccess;
using DataAccess.Repository;
using DataTypes.Models;

namespace Services.Services;

public class PatientServices
{
    private readonly PatientRepository _repository;

    public PatientServices(AppDbContext context)
    {
        _repository = new PatientRepository(context);
    }
    public async Task<List<Patient>> GetAllPatients()
    {
        return await _repository.GetAllPatients();
    }

    public async Task<Patient?> GetPatientById(int id)
    {
        return  await _repository.GetPatientById(id);
    }

    public async Task<Patient?> AddPatient(Patient patient)
    {
        return await _repository.AddPatient(patient);
    }
}