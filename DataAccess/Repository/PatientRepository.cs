using DataTypes.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class PatientRepository
{
    private readonly AppDbContext _context;
    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Patient>> GetAllPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient?> GetPatientById(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<Patient?> AddPatient(Patient patient)
    {
        try
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
        catch
        {
            return null;
        }
    }
}