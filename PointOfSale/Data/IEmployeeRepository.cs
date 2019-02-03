﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Models;

namespace PointOfSale.Data
{
    public interface IEmployeeRepository
    {
        Employee Select(int id);
        List<Employee> SelectAll();
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(int id);

    }
}