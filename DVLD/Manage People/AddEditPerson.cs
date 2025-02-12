﻿using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_People
{
    public partial class AddEditPerson : Form
    {
        DVLD _mainForm;

        public AddEditPerson(DVLD mainForm)
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Person Card");
            _mainForm = mainForm;
            ucAddPerson1.Linker += LinkerMethod;
        }

        public void GetPerson(clsPeople_BLL person)
        {
            if (person != null)
                ucAddPerson1.GetPerson(person);
        }

        public delegate void _deLinker();
        public event _deLinker Linker;

        void LinkerMethod()
        {
            if (Linker != null)
                Linker.Invoke();
        }

        internal void AddMode()
        {
            ucAddPerson1.AddMode();
        }
    }
}
