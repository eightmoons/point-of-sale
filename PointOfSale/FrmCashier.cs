﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointOfSale.Models;
using PointOfSale.BaseModels;
using PointOfSale.Data.AccessObjects;

namespace PointOfSale
{
    public partial class FrmCashier : Form
    {
        private Employee Employee;
        private FrmLogin FrmLogin;
        private List<Category> Categories;
        private Category ActiveCategory;
        public FrmCashier(Employee employee, FrmLogin form)
        {
            InitializeComponent();
            Employee = employee;
            FrmLogin = form;
        }

        private void FrmCashier_Load(object sender, EventArgs e)
        {
            lblEmployeeName.Text = Employee.Name;
            lblEmployeeRole.Text = Employee.Role;
            Categories = AoCategory.Instance.SelectAll("1","1");
            if (Categories.Count > 0)
            {
                foreach(Category cat in Categories)
                {
                    //Populate Category Flow layout panel with categories in database.
                }
                SetActiveCategory(Categories[0]);
            }
        }        

        private void TmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString();
        }

        private void LnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin.Show();
            Close();
        }

        private void SetActiveCategory(Category category)
        {
            List<Item> items = AoItem.Instance.SelectAll("category", category.Name);
            if (items.Count > 0)
            { 
                foreach (Item itm in items)
                {
                    //Populate Item Flow layout panel with Items from Category.
                    Button btn = new Button();
                    btn.Enabled = itm.Stocks > 0;
                    btn.Click += btnItemGenerated_Click;
                    if (itm.Stocks > 0)
                    {
                        btn.Text = itm.Name;
                    }
                    else
                    {
                        btn.Text = itm.Name + "(Out of Stock)";
                    }
                }
                SetActiveCategory(Categories[0]);
            }
        }

        private void btnCategoryGenerated_Click(object sender, EventArgs e)
        {

        }
        private void btnItemGenerated_Click(object sender, EventArgs e)
        {

        }
    }
}
