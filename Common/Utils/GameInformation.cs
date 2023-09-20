using System;
using Terraria;

namespace ForgetMeNot.Common.Utils
{

    public class GameInformation
    {

        public bool Sever
        {
            get
            {
                return Main.netMode == 2;
            }
        }
    }
}
