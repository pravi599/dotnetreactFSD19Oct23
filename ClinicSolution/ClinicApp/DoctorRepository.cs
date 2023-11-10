using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class DoctorRepository
    {
        List<Doctor> doctors;
        public DoctorRepository()
        {
            doctors = new List<Doctor>();
        }
        int GetNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count - 1].Id;
            return ++id;
        }
        void TakeOtherDoctorsDetails(Doctor doctor)
        {
            Console.WriteLine("Please enter doctor id");
            doctor.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter doctor specialization");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Please enter doctor experience in years");
            doctor.Experience = Console.ReadLine();
            Console.WriteLine("Please enter doctor phone number");
            doctor.Phno = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Please enter doctor salary");
            doctor.Phno = Convert.ToInt64(Console.ReadLine());

        }
        public Doctor Add()
        {
            int id = GetNextId();
            Doctor doctor = new Doctor();
            doctor.Id = id;
            //Getting the product details from theuser
            TakeOtherDoctorsDetails(doctor);
            //Adding to the collection
            doctors.Add(doctor);
            return doctor;
        }
        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
        public Doctor GetDoctorById(int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                    return doctors[i];
            }
            return null;
        }
        public Doctor Update(int id, Doctor doctor, string choice)
        {
            Doctor thisDoctor = GetDoctorById(id);
            if (thisDoctor != null)
            {

                if (choice == "experience")
                {
                    thisDoctor.Experience = doctor.Experience;
                    return thisDoctor;
                }
                else if (choice == "phno")
                {
                    thisDoctor.Phno = doctor.Phno;
                    return thisDoctor;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            Console.WriteLine("Could not update");
            return null;
        }
        public Doctor Delete(int id)
        {
            Doctor thisDoctor = GetDoctorById(id);
            if (thisDoctor != null)
            {
                doctors.Remove(thisDoctor);
                return thisDoctor;
            }
            return null;
        }
    }
}

