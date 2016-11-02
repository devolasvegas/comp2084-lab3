using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week6
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            { 
                // Check URL for Student ID argument
                if(!String.IsNullOrEmpty(Request.QueryString["StudentId"]))
                {
                    // ged ID from URL
                    Int32 StudentId = Convert.ToInt32(Request.QueryString["StudentID"]);

                    // connect to the database
                    var conn = new ContosoEntities();

                    // look up the selected student
                    var objStud = (from s in conn.Students
                                   where s.StudentID == StudentId
                                   select s).FirstOrDefault();

                    // populate the form
                    txtLastName.Text = objStud.LastName;
                    txtFirstName.Text = objStud.FirstMidName;
                    txtEnrollDate.Text = objStud.EnrollmentDate.ToShortDateString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Check if there is an ID to decide if we are adding or editing
            Int32 StudentID = 0;

            if(!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
            {
                StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            }

            // connect to db
            var connection = new ContosoEntities();

            //create a new student object from the student class
            Student s = new Student();

            // fill the properties of the new student object
            s.LastName = txtFirstName.Text;
            s.FirstMidName = txtLastName.Text;
            s.EnrollmentDate = Convert.ToDateTime(txtEnrollDate.Text);

            // save the object to the database
            if(StudentID == 0)
            {
                connection.Students.Add(s);
            }
            else
            {
                s.StudentID = StudentID;
                connection.Students.Attach(s);
                connection.Entry(s).State = System.Data.Entity.EntityState.Modified;
            }

            connection.SaveChanges();

            Response.Redirect("student.aspx");

        }
    }
}