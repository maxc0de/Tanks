using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Tank : GameObject
    {
        public void Move()
        {
            int dir = Tanks.randomNum.Next(0,3);

            //Move();
        }
    }
}
