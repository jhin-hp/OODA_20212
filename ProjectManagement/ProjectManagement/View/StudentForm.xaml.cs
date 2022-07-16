﻿using System;
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
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        public StudentForm(Student student)
        {
            InitializeComponent();
            List<int> ProjectType = new List<int>() { 1, 2, 3 };
            cbProjectType.ItemsSource = ProjectType;
            List<Project> ProjectApply = new List<Project>() { };
            List<Teacher> Teachers = new List<Teacher>() { };
            //Student student=new Student();
            StudentName.Content = student.Name;
            void ShowProject(int type)
            {
                foreach (var teacher in Teachers)
                {
                    var epdTeacher = new Expander { Header = teacher.Name };
                    var container = new StackPanel { };
                    foreach (var project in teacher.Projects)
                    {
                        if (project.Type == type)
                        {
                            var tbProjectName = new TextBlock { Text = project.Name, HorizontalAlignment = HorizontalAlignment.Left };
                            var cbProject = new CheckBox { HorizontalAlignment = HorizontalAlignment.Right };
                            var grid = new Grid();
                            grid.Children.Add(tbProjectName);
                            grid.Children.Add(cbProject);
                            container.Children.Add(grid);
                            if (cbProject.IsChecked == true)
                            {
                                if (!ProjectApply.Contains(project))
                                    ProjectApply.Add(project);
                            }
                            else
                            {
                                if (ProjectApply.Contains(project))
                                    ProjectApply.Remove(project);
                            }
                        }
                    }
                    ListProject.Children.Add(epdTeacher);
                    epdTeacher.Content = container;
                }

                void ShowRegistedProject(List<Project> Projects)
                {
                    foreach (var project in Projects)
                    {
                        var tbProject = new TextBlock
                        {
                            Text = project.Name,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        var cbProject = new CheckBox
                        {
                            HorizontalAlignment = HorizontalAlignment.Right,
                            VerticalAlignment = VerticalAlignment.Top,

                        };
                    }
                }
                btnRegistProject.Click += ClkRegistProject;
                void ClkRegistProject(object sender, RoutedEventArgs e)
                {
                    ShowRegistedProject(ProjectApply);
                }
            }
            cbProjectType.SelectionChanged += new SelectionChangedEventHandler(cbProjecTypeChange);
            void cbProjecTypeChange(object sender, SelectionChangedEventArgs e)
            {
                ShowProject(cbProjectType.SelectedIndex + 1);
            }
        }
    }
}
