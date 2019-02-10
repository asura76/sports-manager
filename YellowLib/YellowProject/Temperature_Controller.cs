using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowProject
{
    public class Temperature_Controller
    {
        public Temperature_Controller() { }

        public Temperature_Controller(int id)
        {
            id_ = id;
        }

        public int getUserID()
        {
            return id_;
        }

        private int id_ { get; set; }
    }
}
