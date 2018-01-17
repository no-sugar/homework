using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string name1,telephone1, organization1,email1,remarks1;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //提交
        private void button1_Click(object sender, EventArgs e)
        {
            const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=contacts_data;Integrated Security=true;";
            Contacts aNewContact = new Contacts { name = name1,telephone=telephone1,organization=organization1,email=email1,remarks=remarks1 };
            using (contact_dataDataContext aDataContext = new contact_dataDataContext(ConnectionString))
            {
                aDataContext.Contacts.InsertOnSubmit(aNewContact);
                aDataContext.SubmitChanges();
                this.Close();
            }

        }
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            name1 = textBox2.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            remarks1 = textBox6.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            email1 = textBox5.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            organization1 = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            telephone1 = textBox3.Text;
        }
        
    }
}
