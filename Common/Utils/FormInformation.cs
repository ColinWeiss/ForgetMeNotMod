using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace ForgetMeNot.Common.Utils
{

    public class FormInformation
    {

        public int ScreenWidth
        {
            get
            {
                bool flag = Main.netMode != 2;
                int result;
                if( flag )
                {
                    result = Main.graphics.GraphicsDevice.Viewport.Width;
                }
                else
                {
                    result = 0;
                }
                return result;
            }
        }


        public int ScreenHeight
        {
            get
            {
                bool flag = Main.netMode != 2;
                int result;
                if( flag )
                {
                    result = Main.graphics.GraphicsDevice.Viewport.Height;
                }
                else
                {
                    result = 0;
                }
                return result;
            }
        }


        public Vector2 ScreenCenter
        {
            get
            {
                bool flag = Main.netMode != 2;
                Vector2 result;
                if( flag )
                {
                    result = new Vector2( ScreenWidth / 2, ScreenHeight / 2 );
                }
                else
                {
                    result = Vector2.Zero;
                }
                return result;
            }
        }


        public Rectangle Screen
        {
            get
            {
                bool flag = Main.netMode != 2;
                Rectangle result;
                if( flag )
                {
                    result = new Rectangle( 0, 0, ScreenWidth, ScreenHeight );
                }
                else
                {
                    result = Rectangle.Empty;
                }
                return result;
            }
        }


        internal void GetInformationFromDevice( )
        {
        }
    }
}
