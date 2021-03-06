﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridWithComputedCells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var presenter = new Presenter.Presenter(this);
        }

        public object DataSource
        {
            get
            {
                return dataGridView1.DataSource;
            }
            set
            {
                dataGridView1.DataSource = value;
            }
        }
    }
}
