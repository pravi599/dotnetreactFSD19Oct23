using System.Net.Http.Headers;

namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public double Experience { get; set; }
        public double Phno { get; set; }
        public double Salary { get; set; }
        public Doctor()
        {
            Experience = 0;
            Phno = 0;
            Salary = 0;
        }
        /// <summary>
        /// Construct the doctor object with the essential properties
        /// </summary>
        /// <param name="id">Doctor Id</param>
        /// <param name="name">Name of the doctor</param>
        /// <param name="specialization">Doctor specialized in</param>
        /// <param name="experience">Experience of doctor in years</param>
        /// <param name="phno">Doctor Phonenumber</param>
        /// <param name="salary">Salary of the doctor</param>

        public Doctor(int id, string name, string specialization, double experience, double phno, double salary)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
            Experience = experience;
            Phno = phno;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Doctor Id: {Id}\nDoctor Name : {Name}\nSpecialization : {Specialization}\nExperience: {Experience}\nPhone Number: {Phno}\nSalary: {Salary}\n";
        }
    }
}