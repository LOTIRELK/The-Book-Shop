using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignemnt_6
{
    public partial class frmUpdateBook : Form
    {
        private List<Book> updateList;

        Main mainform;
        public frmUpdateBook(List<Book> list, Main mainform)
        {
            this.mainform = mainform;
            updateList = list;
            InitializeComponent();
        }

        private Book book = null;

        private void frmUpdateBook_Load(object sender, EventArgs e)
        {
            
            int pos = mainform.getPosition();
            book = (Book)updateList[pos];
            txtAuthor.Text = book.Author;
            txtISBN.Text = book.ISBN;
            txtPrice.Text = book.Price;
            txtTitle.Text = book.Title;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           book.Author = txtAuthor.Text ;
           book.ISBN = txtISBN.Text;
           book.Price = txtPrice.Text;
           book.Title = txtTitle.Text;
           book = new Book(txtISBN.Text, txtTitle.Text, txtAuthor.Text, txtPrice.Text);
            this.Close();
        }

        public Book GetUpdatedBook()
        {
            this.ShowDialog();
            return book;
        }
    }
}
