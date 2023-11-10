using ClinicModelLibrary;
using ClinicDALLibrary;

namespace ClinicBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }
        /// <summary>
        /// Adds the doctor to the collection using the repository
        /// </summary>
        /// <param name="doctor">The doctor to be added</param>
        /// <returns></returns>
        /// <exception cref="NotAddedException"></exception>

        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            return result == null ? throw new NoSuchDoctorException() : result;
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateDoctorExperience(int id, double experience)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                doctor.Experience = experience;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateDoctorPhno(int id, double phno)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Phno = phno;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}