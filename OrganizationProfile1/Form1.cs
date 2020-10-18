﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrganizationProfile1

{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new String[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }


            string[] Gender = new String[]
            {
                "Female",
                "Male"
            };
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(Gender[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException();
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new ArgumentNullException();
            }
            return _FullName;
        }

        public int Age(string age)
        {

            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);

            }
            else
            {
                throw new FormatException();
            }
            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy- MM-dd");
                StudentInformationClass.SetProgram = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (StackOverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
