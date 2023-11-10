using ClinicModelLibrary;
using ClinicBLLibrary;
using ClinicDALLibrary;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ClinicApp
{
    internal class Program
    {
        IDoctorService doctorService;

        public Program()
        {
            doctorService = new DoctorService();
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
        void StartAdminActivities()
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
                        AddDoctor();
                        break;
                    case 2:
                        UpdatePhone();
                        break;
                    case 3:
                        UpdateExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintAllDoctorDetails();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        private void PrintAllDoctorDetails()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorService.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if(result!= null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Please enter doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter doctor specialization");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Please enter doctor experience in years");
            doctor.Experience = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Please enter doctor phone number");
            doctor.Phno = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Please enter doctor salary");
            doctor.Salary = Convert.ToInt64(Console.ReadLine());

            return doctor;
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdatePhone()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            double phno = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phno = phno;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorPhno(id, phno);
                if (result != null)
                    Console.WriteLine("Update Success");
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the experience to update");
            double experience = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = experience;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorExperience(id, experience);
                if (result != null)
                    Console.WriteLine("Update Success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int Main(string[] args)
        {
            Console.WriteLine("Welcome to online clinic application");

            Program program = new Program();
            program.StartAdminActivities();
            return 0;
        }
    }
}
               