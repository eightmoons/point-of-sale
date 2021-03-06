﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.BaseModels;

namespace PointOfSale.Models
{
    public class Transaction : BaseModel
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Status Condition { get; set; }

        public enum Status
        {
            Voided,
            Valid
        }

        public Transaction(int id, int customerId, int employeeId, Status condition,int createUid, DateTime createDate, int writeUid, DateTime writeDate) : base(id, createDate, createUid, writeDate, writeUid)
        {
            CustomerId = customerId;
            EmployeeId = employeeId;
            Condition = condition;
        }

        public Transaction(int customerId, int employeeId, Status condition, int createUid, int writeUid) : base(createUid,writeUid)
        {
            CustomerId = customerId;
            EmployeeId = employeeId;
            Condition = condition;
        }
    }
}
