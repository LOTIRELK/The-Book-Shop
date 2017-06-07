using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignemnt_6
{
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private Book book = null;
    
        public Book GetNewBook()
        {
            this.ShowDialog();
            return book;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool i = validateAuthor();
            bool x = validateISBN();
            bool y = validateTitle();
            bool z = validateCost();
            if (i==true&&x==true&& y==true&&z==true)
            {
                book = new Book(txtISBN.Text, txtTitle.Text, txtAuthor.Text, txtPrice.Text);
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool validateAuthor()
        {
            var regexAuthor = new Regex("^[a-zA-Z ]+$");
            if (regexAuthor.IsMatch(txtAuthor.Text))
            {
                return true;
            }
            else if (txtAuthor.Text == "")
            {
                MessageBox.Show("Author field is empty!\n" +
                    "Please try again.", "Input Error");

                return false;
            }
            else
                MessageBox.Show("Authors name must contain only letters.\n" +
                   "Please try again.", "Input Error");
            return false;
        }
        public bool validateISBN()
        {
            var regexISBN = new Regex("^[0-9][0-9][0-9][-][0-9][0-9][0-9][-][0-9][0-9][0-9]$");
            
            if (regexISBN.IsMatch(txtISBN.Text))
            {
                return true;
            }
            else if (txtISBN.Text == "")
            {
                MessageBox.Show("ISBN field is empty!\n" +
                    "Please try again.", "Input Error");

                return false;
            }
            else
                MessageBox.Show("ISBN must be entered in the following format 000-000-000\n" +
                    "Please try again.", "Input Error");
            return false;
        }
        public bool validateTitle()
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Book Title field is empty!\n" +
                    "Please try again.", "Input Error");

                return false;
            }
            else return true;
        }
        public bool validateCost()
        {
            var regexCost = new Regex("^[0-9][0-9][.][0-9][0-9]$");
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Book Price field is empty!\n" +
                    "Please try again.", "Input Error");

                return false;
            }
            else if(regexCost.IsMatch(txtPrice.Text))
            {
                return true;
            }
            else
                MessageBox.Show("Please enter in the format 00.00. \n" +
                    "Please try again.", "Input Error");
            return false;
        }
    }
}
