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
    
    public partial class Project
    {
        public int ID { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public Nullable<int> Type { get; set; }
        public string Name { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> StudentApply { get; set; }
        public virtual ICollection<Student> StudentAccepted { get; set; }

        //Method
        public Project(String name, int type, int teacherID, int ID)
        {
            this.Name = name;
            this.TeacherID = TeacherID;
            this.ID = ID;
            this.Type = type;
        }
        public void AcceptStudent(Student student)
        {
            using (var context=new DatabaseContext())
            {
                if (!StudentAccepted.Contains(student))
                    this.StudentAccepted.Add(student);
                if (StudentApply.Contains(student))
                    this.StudentApply.Remove(student);
                student.ProjectAccept = this;
                student.ProjectsApply.Clear();
                context.SaveChanges();//save to databse
            }    
            

        }

    }
}
