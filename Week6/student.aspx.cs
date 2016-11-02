using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getStudents();
        }

        protected void getStudents()
        {
            // connect to db
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Students= from d in conn.Students
                              select d;

            // display query result in gridview
            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();

        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Delete student from gridview
            // Determine which row in the student grid the user clicked
            Int32 gridIndex = e.RowIndex;

            // find the StudentID value in the selected row
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[gridIndex].Value);

            // Connect to the database
            var conn = new ContosoEntities();

            // Delete the selected student record
            Student s = new Student();

            s.StudentID = StudentID;

            conn.Students.Attach(s);
            conn.Students.Remove(s);
            conn.SaveChanges();

            // Refresh the gridview
            getStudents();
        }
    }
}
