using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace bokochfilm
{
    public partial class Form1 : Form
    {
        public List<string> All = new List<string>();
        public Form1()
        {
             
            InitializeComponent();

            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            Book_Lengh_Numeric.Value = 0;
            Film_Lengh_Numeric.Value = 0;
            Alla_Check.Checked = true;



        }
       

        class Media
        {

            public void update_result(Form1 formObject)
            {
               
                formObject.result_textbox.Text = "";
                if (formObject.Alla_Check.Checked)
                {

                    foreach (string item in formObject.All)
                    {
                        string film_book = item.Substring(0, item.Length - 11);
                        formObject.result_textbox.Text += film_book;
                    }
                }
                else if (formObject.Blocker_Check.Checked)
                {
                    foreach (string item in formObject.All)
                    {
                        if (item.Contains("[({BOOK]})]"))
                        {
                            string book = item.Substring(0, item.Length - 11);
                            formObject.result_textbox.Text += book;
                        }
                    }
                }
                else if (formObject.Filmer_Check.Checked)
                {
                    foreach (string item in formObject.All)
                    {
                        if (item.Contains("[({FILM]})]"))
                        {
                            string film = item.Substring(0, item.Length - 11);
                            formObject.result_textbox.Text += film;
                        }
                    }
                }

            }

        }

        class Film : Media
        {
            public Film()
            {
                string Title;
                string director;
                int lengh;
            }

            public void Add_Film(string title, string director, int minutes, Form1 formObject)
            {
                

                string Film = title + "(" + director + ", " + minutes.ToString() + " minuter)\n[({FILM]})]";

                formObject.All.Add(Film);
            }


        }

        class Book : Media
        {
            public Book()
            {
                string Title;
                string author;
                int nrOfPages;
            }

            public void Add_Book(string title, string author, int pages, Form1 formObject)
            {


               

                string Book = title + "(" + author + ", " + pages.ToString() + " sidor)\n[({BOOK]})]";

                formObject.All.Add(Book);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string title = Book_Title_TextBox.Text;
            string author = Book_Author_TextBox.Text;
            int pages = (int)Book_Lengh_Numeric.Value;

            if (title == "" || author == "" || pages == 0)
            {
                result_textbox.Text = "Värdet måste vara större än 0";
                return;
            }

            Book book = new Book();
            Media media = new Media();

            book.Add_Book(title, author, pages, this);
            media.update_result(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string title = Film_Title_TextBox.Text;
            string director = Film_Director_TextBox.Text;
            int minutes = (int)Film_Lengh_Numeric.Value;

            if (title == "" || director == "" || minutes == 0)
            {
                result_textbox.Text = "Värdet måste vara större än 0";
                return;
            }

            Film film = new Film();
            Media media = new Media();

            film.Add_Film(title, director, minutes, this);
            media.update_result(this);

        }



        private void Alla_Check_CheckedChanged(object sender, EventArgs e)
        {
            Media media = new Media();
            media.update_result(this);
        }

        private void Blocker_Check_CheckedChanged(object sender, EventArgs e)
        {
            Media media = new Media();
            media.update_result(this);
        }

        private void Filmer_Check_CheckedChanged(object sender, EventArgs e)
        {
            Media media = new Media();
            media.update_result(this);
        }
    }
}
