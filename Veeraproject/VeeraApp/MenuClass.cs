using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeeraApp
{
    public class MenuClass 
    {
        private string NAME, MENU_NAME;
        private int SYSCODE, CODE, REF_CODE, MENU_ORD;

        //Declare Property Get/Set Method for Type String
        public string Name
        {
            get
            {
                return this.NAME;
            }
            set
            {
                this.NAME = value;
            }
        }

        public string Menu_Name
        {
            get
            {
                return this.MENU_NAME;
            }
            set
            {
                this.MENU_NAME = value;
            }
        }

        // Declare Property Get/Set Method for Type Integer 
        public int Code
        {
            get
            {
                return CODE;
            }
            set
            {
                CODE = value;
            }
        }

        public int SysCode
        {
            get
            {
                return SYSCODE;
            }
            set
            {
                SYSCODE = value;
            }
        }
        
        public int REf_Code
        {
            get
            {
                return REF_CODE;
            }
            set
            {
                REF_CODE = value;
            }
        }

        public int Menu_Ord
        {
            get
            {
                return MENU_ORD;
            }
            set
            {
                MENU_ORD = value;
            }
        }

    }

    class TestMenu
    {
        public static void main()
        {
            // Create an Object for MenuClass

            MenuClass mc = new MenuClass();
            mc.SysCode = 1;
            mc.Code = 1;
            mc.Name = "Master";
            mc.REf_Code = 1;
            mc.Menu_Name = "Comapny";
            mc.Menu_Ord = 1;

            Console.WriteLine("Menu Info:{0}",mc);
        }
    }
}