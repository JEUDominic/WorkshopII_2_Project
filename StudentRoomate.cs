using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma
{
    public class StudentRoomate
    {
        public String stuAID;
        public String stuBID;

        public StudentRoomate(String stuAID, String stuBID)
        {
            this.stuAID = stuAID;
            this.stuBID = stuBID;
        }

        public void setStuAID(String stuAID)
        {
            this.stuAID = stuAID;
        }
        public void setStuBID(String stuBID)
        {
            this.stuBID = stuBID;
        }

        public String getStuAID() { return stuAID; }
        public String getStuBID() { return stuBID; }
    }
}
