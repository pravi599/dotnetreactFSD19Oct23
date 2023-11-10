using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }
        public double Phno { get; set; }
        public double Salary { get; set; }


        public override string ToString()
        {
            return $"Doctor Id: {Id}\nDoctor Name : {Name}\nSpecialization : {Specialization}\nExperience: {Experience}\nSalary: {Salary}\nPhone Number: {Phno}";
        }
    }
}
