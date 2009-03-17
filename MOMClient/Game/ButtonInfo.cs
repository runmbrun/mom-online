
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;



namespace MOM
{
    class ButtonInfo
    {
        private Int32 _number;
        public Int32 Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private Rectangle _location;
        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }
        
        private String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
