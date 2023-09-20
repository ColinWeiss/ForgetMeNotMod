using System;
using Microsoft.Xna.Framework;

namespace ForgetMeNot.Common.Utils
{

    internal class SymUtils
    {

        public static Vector2 GetCloser( float x, float y, float targetx, float targety, float i, float maxi )
        {
            x *= maxi - i;
            x /= maxi;
            y *= maxi - i;
            y /= maxi;
            targetx *= i;
            targetx /= maxi;
            targety *= i;
            targety /= maxi;
            return new Vector2( x + targetx, y + targety );
        }

        public static Vector2 GetCloser( Vector2 current, Vector2 target, float i, float maxi )
        {
            current *= maxi - i;
            current /= maxi;
            target *= i;
            target /= maxi;
            return current + target;
        }

        public static Color GetCloserColor( Color current, Color target, float i, float maxi )
        {
            float num = current.R;
            float g = current.G;
            float b = current.B;
            float tr = target.R;
            float tg = target.G;
            float tb = target.B;
            float num2 = num * (maxi - i) / maxi;
            g *= maxi - i;
            g /= maxi;
            b *= maxi - i;
            b /= maxi;
            tr *= i;
            tr /= maxi;
            tg *= i;
            tg /= maxi;
            tb *= i;
            tb /= maxi;
            return new Color( (int)(num2 + tr), (int)(g + tg), (int)(b + tb) );
        }


        public static double GetCloserSingle( double current, double target, double i, double maxi )
        {
            current *= (maxi - i) / maxi;
            target *= i / maxi;
            return current + target;
        }

        public static Point ToTilesPos( Vector2 position )
        {
            return new Point( (int)(position.X / 16f), (int)(position.Y / 16f) );
        }
    }
}
