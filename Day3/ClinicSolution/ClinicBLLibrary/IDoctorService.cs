using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    public interface IDoctorService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor UpdateDoctorPhno(int id,double phno);
        public Doctor UpdateDoctorExperience(int id, double experience);
        public Doctor Delete(int id);
    }
}
