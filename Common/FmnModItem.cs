using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetMeNot.Common
{
    public abstract class FmnModItem : ModItem
    {
        public void SetSize( int width , int height )
        {
            Item.width = width;
            Item.height = height;
        }
    }
}