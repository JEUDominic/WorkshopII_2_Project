using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class StudentWill
    {
        private String studentID;
        private int w_character;
        private String w_interest;
        private int w_bedtime;
        private int w_waketime;
        private int w_smoke;
        private int w_clean;

        public StudentWill(String studentID, int w_character, String w_interest,int w_bedtime,int w_waketime,int w_smoke,int w_clean)
        {
            this.studentID = studentID;
            this.w_character = w_character;
            this.w_interest = w_interest;
            this.w_bedtime = w_bedtime;
            this.w_waketime = w_waketime;
            this.w_smoke = w_smoke;
            this.w_clean = w_clean;
        }

        public void setStudentID(String studentID)
        {
            this.studentID = studentID;
        }
        public void setCharacter(int w_character)
        {
            this.w_character = w_character;
        }
        public void setinterest(String w_interest)
        {
            this.w_interest = w_interest;
        }
        public void setBedtime(int w_bedtime)
        {
            this.w_bedtime = w_bedtime;
        }
        public void setWaketime(int w_waketime)
        {
            this.w_waketime = w_waketime;
        }
        public void setSmoke(int w_smoke)
        {
            this.w_smoke = w_smoke;
        }
        public void setClean(int w_clean)
        {
            this.w_clean = w_clean; 
        }
        public String getStudentID() { return studentID; }
        public int getW_character() { return w_character; }
        public String getW_interest() { return w_interest; }
        public int getW_bedtime() { return w_bedtime; }
        public int getW_waketime() { return w_waketime; }
        public int getW_smoke() { return w_smoke; }
        public int getW_clean() { return w_clean; }
    }
}
