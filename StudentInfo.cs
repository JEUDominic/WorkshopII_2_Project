using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class StudentInfo
    {
        private String studentID;
        private String studentName;
        private int studentBirth;
        private int studentGender;

        public StudentInfo(String studentID, String studentName, int studentBirth, int studentGender)
        {
            this.studentID = studentID;
            this.studentName = studentName;
            this.studentBirth = studentBirth;
            this.studentGender = studentGender;
        }
        public void setStudentID(String studentID)
        {
            this.studentID = studentID;
        }
        public void setStudentName(String studentName)
        {
            this.studentName = studentName;
        }
        public void setStudentBirth(int studentBirth)
        {
            this.studentBirth = studentBirth;
        }
        public void setStudentGender(int studentGender)
        {
            this.studentGender = studentGender;
        }

        public String getStudentID() { return studentID; }
        public String getStudentName() { return studentName; }
        public int getStudentBirth() { return studentBirth; }
        public int getStudentGender() { return studentGender; }
    }
}
