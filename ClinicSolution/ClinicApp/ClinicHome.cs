using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    internal class ClinicHome
    {
        DoctorRepository doctorRepository;
        public ClinicHome()
        {
            doctorRepository = new DoctorRepository();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Doctor Phone");
            Console.WriteLine("3. Modify Doctor Experience");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Print All Doctors Details");
            Console.WriteLine("0. Exit");
        }
        void StartAdminFunctionalities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        doctorRepository.Add();
                        break;
                    case 2:
                        UpdateDoctorPhone();
                        break;
                    case 3:
                        UpdateDoctorExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintAllDoctorsDetails();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }

            } while (choice != 0);
        }
        private void PrintAllDoctorsDetails()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorRepository.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            int id = GetDoctorIdFromUser();
            if (doctorRepository.Delete(id) != null)
            {
                Console.WriteLine("Doctor deleted");
            }
        }
        private void UpdateDoctorPhone()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            Doctor doctor = new Doctor();
            long phno = Convert.ToInt64(Console.ReadLine());
            doctor.Phno = phno;
            var result = doctorRepository.Update(id, doctor, "phno");
            if (result != null)
            {
                Console.WriteLine("Update success");
            }
        }
        private void UpdateDoctorExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the exerience to update");
            Doctor doctor = new Doctor();
            string experience = Console.ReadLine();
            doctor.Experience = experience;
            var result = doctorRepository.Update(id, doctor, "experience");
            if (result != null)
            {
                Console.WriteLine("Update success");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to online clinic application");
            ClinicHome home = new ClinicHome();
            home.StartAdminFunctionalities();
        }
    }
}
