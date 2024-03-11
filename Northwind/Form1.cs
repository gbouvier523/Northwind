//Gisell Figueredo
//Assignment 11
//Data Entity
//11/11/22
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NorthwindEntities dbContext = new NorthwindEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dbContext.Products.Load();
            productBindingSource.DataSource = dbContext.Products.Local;
                
        }

        private void btnAllProd_Click(object sender, EventArgs e)
        {
            dbContext.Products.Load();
            productBindingSource.DataSource= dbContext.Products.Local;
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            productBindingSource.DataSource = dbContext.Products.Local
                .Where(product => product.ReorderLevel > product.UnitsInStock);

        }

        private void btnDiscontinued_Click(object sender, EventArgs e)
        {
            productBindingSource.DataSource = dbContext.Products.Local
                .Where(product => product.Discontinued);
        }
    }
}
