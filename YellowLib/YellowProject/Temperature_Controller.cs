
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

        //public int getTemp()
        //{
        //    return CurrentTemp_;
        //}

        public void changeTemp(float temp, char conv)
        {
            CurrentTemp_ = temp;
            if(char.ToUpper(prefConv_) == 'C' &&
                char.ToUpper(conv) == 'F')
            {
                CurrentTemp_ = (CurrentTemp_ * 1.8) + 32;
            }
            else if(char.ToUpper(prefConv_) == 'F' &&
                char.ToUpper(conv) == 'C')
            {
                CurrentTemp_ = (9.5) * (CurrentTemp_ + 32);
            }
        }

        private int id_ { get; set; }

        private char prefConv_ { get; set; }
        private double CurrentTemp_ { get; set; }

    }
}
