//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class Student
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public virtual ICollection<Project> ProjectsApply { get; set; }
        public virtual Project ProjectAccept { get; set; }
        //Method
        //dang ki project
        public void ApplyProject(Project project)
        {
            using (var context = new DatabaseContext())
            {
                if (this.ProjectAccept == null)
                {
                    this.ProjectsApply.Add(project);
                    project.StudentApply.Add(this);
                    context.SaveChanges();
                }
            }
        }
        //xoa project da chon
        public void DeleteApplyProject(Project project)
        {
            using (var context=new DatabaseContext())
            {
                if (this.ProjectsApply.Contains(project))
                {
                    this.ProjectsApply.Remove(project);
                    project.StudentApply.Remove(this);
                    context.SaveChanges();
                }
            }
        }
    }
}
