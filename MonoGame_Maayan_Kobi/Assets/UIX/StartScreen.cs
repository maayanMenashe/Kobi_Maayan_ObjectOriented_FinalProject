using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class StartScreen : Screen
    {
        public void Start()
        {
            base.text.text = "Use WASD or arrow keys to move\r\nClaim as much territory as required to advance\r\nto the next level\r\nAvoid the notorious LogoBounce or lose a life\r\n\r\n//PRESS ENTER TO START THE DIGITAL LIBERATION\\\\";
        }
    }
}
