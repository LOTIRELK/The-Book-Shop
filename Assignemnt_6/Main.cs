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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private List<Book> book = new List<Book>();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            book.Add(new Book() { ISBN = "124-435-766", Title = "Harry Potter", Author = "JK Rowling", Price = "09.45" });
            book.Add(new Book() { ISBN = "997-656-333", Title = "Indian cuisine", Author = "Nigella Lawson", Price = "21.05" });
            book.Add(new Book() { ISBN = "995-556-763", Title = "Horror Stories", Author = "Darren Shan", Price = "32.99" });
            book.Add(new Book() { ISBN = "134-435-766", Title = "Tokyo Travel", Author = "JRR Tolkein", Price = "33.45" });
            book.Add(new Book() { ISBN = "997-696-333", Title = "Happy Living", Author = "Stephen King", Price = "76.59" });
            book.Add(new Book() { ISBN = "085-556-752", Title = "Poems 4 Kids", Author = "Mickey Mouse", Price = "07.19" });
            book.Add(new Book() { ISBN = "424-995-766", Title = "The Hobbit", Author = "Kate Winslet", Price = "42.87" });
            book.Add(new Book() { ISBN = "117-656-323", Title = "Dictionary ", Author = "Dr. Larson", Price = "89.05" });
            book.Add(new Book() { ISBN = "995-565-768", Title = "Happy Stories", Author = "Sharon King", Price = "2.99" });
            foreach (Book b in book)
            {
                lbBook.Items.Add(b.GetDisplayText("\t"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddBook newBookForm = new frmAddBook();
            Book b = newBookForm.GetNewBook();
            
            if (b != null)
            {
                book.Add(b);
                FillBookListBox();
            }
        }
        private void FillBookListBox()
        {
            lbBook.Items.Clear();
            foreach (Book b in book)
            {
                lbBook.Items.Add(b.GetDisplayText("\t"));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lbBook.SelectedIndex;
            Book b = (Book)book[i];
            string message = "Are you sure you want to delete "
                    + b.Title + "?";
            DialogResult button =
                MessageBox.Show(message, "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                book.Remove(b);
                FillBookListBox();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchBook searchBookForm = new frmSearchBook(book);
            int pos = searchBookForm.getIndex();
            lbBook.SelectedIndex = pos;
        }
        private int position = 0;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            position = lbBook.SelectedIndex;
            Book bk = (Book)book[position];
            frmUpdateBook upBookForm = new frmUpdateBook(book, this);
            Book b = upBookForm.GetUpdatedBook();
            if (b != null)
            {
                book.Remove(bk);
                book.Insert(position, b);
                FillBookListBox();
          
            }

        }
        public int getPosition()
        {
            return position;
        }
    }
}
