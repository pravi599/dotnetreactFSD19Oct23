﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public interface IRepository
    {
        public Doctor Add(Doctor doctor);
        public Doctor Update(Doctor doctor);
        public Doctor Delete(int doctor);
        public Doctor GetById(int id);
        public List<Doctor> GetAll();
    }
}
