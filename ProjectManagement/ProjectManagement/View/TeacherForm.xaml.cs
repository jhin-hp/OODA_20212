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
using System.Windows.Shapes;
using ProjectManagement.Model;
namespace ProjectManagement.View
{
    /// <summary>
    /// Interaction logic for TeacherForm.xaml
    /// </summary>
    public partial class TeacherForm : Window
    {
        public TeacherForm(Teacher teacher)
        {
            InitializeComponent();
            //Teacher teacher = new Teacher();
            TeacherName.Content = teacher.Name;
            void ShowListProject(int type)
            {

                var epdProject = new Expander { Header = "Project " + type.ToString() };
                var container = new StackPanel { };
                foreach (var p in teacher.Projects)
                {
                    if (p.Type == type)
                    {
                        var tbProjectName = new TextBlock { Text = p.Name };
                        tbProjectName.MouseDown += new MouseButtonEventHandler(TbClick);
                        container.Children.Add(tbProjectName);
                        void TbClick(object sender, RoutedEventArgs e)
                        {
                            ShowListStudent(p);
                        }
                    }

                }
                ListProject.Children.Add(epdProject);
                epdProject.Content = container;
            }

            ShowListProject(1);
            ShowListProject(2);
            ShowListProject(3);
            void ShowListStudent(Project p)
            {
                //var container = new StackPanel { };
                ListStudent.Children.Clear();
                foreach (var student in p.StudentApply)
                {
                    var tbStudent = new TextBlock
                    {
                        Text = student.Name,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    var cbStudent = new CheckBox
                    {
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    var view = new Grid { };
                    view.Children.Add(tbStudent);
                    view.Children.Add(cbStudent);
                    ListStudent.Children.Add(view);
                }

            }
        }
    }
}
