using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class StudentHabit
    {
        private String studentID;
        private int character;
        private String interest;
        private int bedtime;
        private int waketime;
        private int smoke;
        private int clean;

        public StudentHabit(String studentID, int character, String interest, int bedtime, int waketime, int smoke, int clean)
        {
            this.studentID = studentID;
            this.character = character;
            this.interest = interest;
            this.bedtime = bedtime;
            this.waketime = waketime;
            this.smoke = smoke;
            this.clean = clean;
        }

        public void setStudentID(String studentID)
        {
            this.studentID = studentID;
        }
        public void setCharacter(int character)
        {
            this.character = character;
        }
        public void setInterest(String interest)
        {
            this.interest = interest;
        }
        public void setBedtime(int bedtime)
        {
            this.bedtime = bedtime;
        }
        public void setWaketime(int waketime)
        {
            this.waketime = waketime;
        }
        public void setSmoke(int smoke)
        {
            this.smoke = smoke;
        }
        public void setClean(int clean)
        {
            this.clean = clean;
        }
        public String getStudentID() { return studentID; }
        public int getCharacter() { return character; }
        public String getInterest() { return interest; }
        public int getBedtime() { return bedtime; }
        public int getWaketime() { return waketime; }
        public int getSmoke() { return smoke; }
        public int getClean() { return clean; }

    }
}
