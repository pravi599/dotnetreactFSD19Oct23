using ClinicModelLibrary;
using System.Numerics;

namespace ClinicDALLibrary
{
    public class DoctorRepository : IRepository
    {
        Dictionary<int,Doctor> doctors = new Dictionary<int,Doctor>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor">Doctor object that has to be added</param>
        /// <returns>The doctor that has been added</returns>

        public Doctor Add(Doctor doctor)
        {
            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The doctor Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;
        }
        private int GetTheNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// Deletes the doctor from the dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the doctor to be deleted</param>
        /// <returns>The deleted doctor</returns>
        

        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }

        public Doctor GetById(int id)

        {
            try
            {
                return doctors[id];

            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("No doctor details added with this id");
                Console.WriteLine(e.Message);

            }
            return null;
            
        }

        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
    }
}