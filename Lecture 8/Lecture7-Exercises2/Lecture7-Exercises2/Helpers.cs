using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public static class Globals
    {
        public static bool isSwitchButtonPressed = false;


    }
    public class Helpers
    {
        public bool isSwitchButtonPressed = false;

        public static void PressSwitchButton()
        {

            if (isSwitchButtonPressed == false)
            {
                isSwitchButtonPressed = true;
            }
            else
            {
                isSwitchButtonPressed = false;
            }
        }

    }
}
