using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Member
    {

        private int memberNo;
        private int age;
        private string firstName;
        private string lastName;
        private string result;

        public Member()
        {
            memberNo = 0;
            age = 0;
            firstName = "";
            lastName = "";
        }

        public Member(int memberNo, int age, string firstName, string lastName)
        {
            this.memberNo = memberNo;
            this.age = age;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int MemberNo
        {
            set 
            {
                this.memberNo = value;
                result = this.memberNo.ToString();
            }
            get 
            { 
                return this.memberNo;
            } 
        }

        public int Age
        {
            set
            {
                this.age = value;
                result = result + "," + this.age;
            }
            get 
            { 
                return this.age; 
            }
        }

        public string FirstName
        {
            set
            {
                this.firstName = value;
                result = result + "," + this.firstName;
            }
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            set
            {
                this.lastName = value;
                result = result + "," + this.lastName;
            }
            get
            {
                return this.lastName;
            }    
        }

        public string Result
        {
            get 
            { 
                return result;
            }
        }
    }
}
