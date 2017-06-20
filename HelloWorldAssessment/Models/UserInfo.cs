using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldAssessment.Models
{
    public class UserInfo
    {
        private string fname;
        private string lname;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private string country;
        private string email;
        private string pword;



#region Properties
        // Userfname
        public string Userfname
        {
            set
            {
                fname = value;
            }

            get
            {
                return fname;
            }
        }



        // Userlname
        public string Userlname
        {
            set
            {
                lname = value;
            }

            get
            {
                return lname;
            }
        }



        // Useraddress1
        public string Useraddress1
        {
            set
            {
                address1 = value;
            }

            get
            {
                return address1;
            }
        }



        // Useraddress2
        public string Useraddress2
        {
            set
            {
                address2 = value;
            }

            get
            {
                return address2;
            }
        }



        // Usercity
        public string Usercity
        {
            set
            {
                city = value;
            }

            get
            {
                return city;
            }
        }



        // Userstate
        public string Userstate
        {
            set
            {
                state = value;
            }

            get
            {
                return state;
            }
        }



        // Usercountry
        public string Usercountry
        {
            set
            {
                country = value;
            }

            get
            {
                return country;
            }
        }



        // Useremail
        public string Useremail
        {
            set
            {
                email = value;
            }

            get
            {
                return email;
            }
        }



        // Usercountry
        public string Userpword
        {
            set
            {
                pword = value;
            }

            get
            {
                return pword;
            }
        }

#endregion



        public UserInfo() : this("", "", "", "", "", "", "", "", "")
        {


        }


        public UserInfo(string fname, string lname, string address1, string address2, string city, string state, string country, string email, string pword)
        {
            this.fname = fname;
            this.lname = lname;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.country = country;
            this.email = email;
            this.pword = pword;
        }
    }
}