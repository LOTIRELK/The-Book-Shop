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
    public partial class frmSearchBook : Form
    {
        private List<Book> searchList;
        public frmSearchBook(List<Book> list)
        {
            searchList = list;
            InitializeComponent();
            
        }
        private int index = 0;


        private void frmSearchBook_Load(object sender, EventArgs e)
        {
            foreach (Book b in searchList)
            {
                lbBookList.Items.Add(b.GetDisplayText("\t"));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ISBNtoFind = txtISBN.Text;
            bool i = validateISBN();
            if (i == true)
            {
                foreach (Book b in searchList)
                {

                    if (ISBNtoFind == b.ISBN)
                    {
                        lbBookList.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
        }
        public int getIndex()
        {
            this.ShowDialog();
            return index;
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
    }
}
