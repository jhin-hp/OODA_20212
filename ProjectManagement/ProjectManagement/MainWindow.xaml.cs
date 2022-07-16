using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectManagement.Model;
using ProjectManagement.Controller;
using ProjectManagement.View;
namespace ProjectManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
         
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            MD5 md5 = new MD5();
            Account account = new Account(tbUserName.Text, md5.HashMd5(tbPassWord.Text));
            if (cbIsStudent.IsChecked == true)
            {
                Student student = account.StudentLogin();
                //StudentForm(student);
                if (student != null)
                {
                    var Form1 = new StudentForm(student);
                    Form1.Show();
                }
                else
                    MessageBox.Show("Sai tai khoan hoac mat khau");

            }
            if (cbIsTeacher.IsChecked == true)
            {
                Teacher teacher = account.TeacherLogin();
                if (teacher != null)
                {
                    var Form1 = new TeacherForm(teacher);
                    Form1.Show();
                }
                else
                    MessageBox.Show("Sai tai khoan hoac mat khau");
            }
        }
    }
}
