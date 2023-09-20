using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ForgetMeNot.Common.Utils
{
    public static class XnaUtils
    {
        public static Vector2 GetAngle( this int angle )
        {
            return (3.14159f / 180 * angle ).ToRotationVector2( );
        }

        public static float GetRot( this int angle )
        {
            return 3.141592f / 180 * angle;
        }

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

        public static bool Pressed( this ButtonState buttonState )
        {
            return buttonState == ButtonState.Pressed;
        }

        public static bool Released( this ButtonState buttonState )
        {
            return buttonState == 0;
        }

        public static bool Click( this ButtonState buttonState, ButtonState oldButtonState )
        {
            return buttonState.Released( ) && oldButtonState.Pressed( );
        }

        public static bool Released( this MouseState mouseState, MouseState oldMouseState )
        {
            return mouseState.LeftButton.Released( ) && oldMouseState.LeftButton.Released( ) && mouseState.RightButton.Released( ) && oldMouseState.RightButton.Released( );
        }

        public static bool Released( this MouseState mouseState )
        {
            return mouseState.LeftButton.Released( ) && mouseState.RightButton.Released( );
        }

        public static bool Interacting( this MouseState mouseState )
        {
            return mouseState.LeftButton.Pressed( ) || mouseState.RightButton.Pressed( );
        }

        public static bool IntersectMouse( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( Mouse.GetState().X , Mouse.GetState( ).Y , 0, 0 ) );
        }

        public static void DrawNinePieces( this SpriteBatch spriteBatch, Texture2D image, int x, int y, int width, int height, int borderSize , Color color )
        {
            Vector2 rightTopStartPoting = new Vector2( (float)(x + width - borderSize), (float)y );
            Vector2 leftBottomStartPoting = new Vector2( (float)x, (float)(y + height - borderSize) );
            Vector2 rightBottomStartPoting = new Vector2( (float)(x + width - borderSize), (float)(y + height - borderSize) );
            Rectangle rightTopIntercept = new Rectangle( image.Width - borderSize, 0, borderSize, borderSize );
            Rectangle leftBottomIntercept = new Rectangle( 0, image.Height - borderSize, borderSize, borderSize );
            Rectangle rightBottomIntercept = new Rectangle( image.Width - borderSize, image.Height - borderSize, borderSize, borderSize );
            spriteBatch.Draw( image, new Vector2( x, y ), new Rectangle?( new Rectangle( 0, 0, borderSize, borderSize ) ), color );
            spriteBatch.Draw( image, rightTopStartPoting, new Rectangle?( rightTopIntercept ), color );
            spriteBatch.Draw( image, leftBottomStartPoting, new Rectangle?( leftBottomIntercept ), color );
            spriteBatch.Draw( image, rightBottomStartPoting, new Rectangle?( rightBottomIntercept ), color );
            spriteBatch.Draw( image, new Rectangle( x + borderSize, y, width - borderSize * 2, borderSize ), new Rectangle?( new Rectangle( borderSize, 0, 2, borderSize ) ), color );
            spriteBatch.Draw( image, new Rectangle( x + width - borderSize, y + borderSize, borderSize, height - borderSize * 2 ), new Rectangle?( new Rectangle( image.Width - borderSize, borderSize, borderSize, 2 ) ), color );
            spriteBatch.Draw( image, new Rectangle( x + borderSize, y + height - borderSize, width - borderSize * 2, borderSize ), new Rectangle?( new Rectangle( borderSize, image.Height - borderSize, 2, borderSize ) ), color );
            spriteBatch.Draw( image, new Rectangle( x, y + borderSize, borderSize, height - borderSize * 2 ), new Rectangle?( new Rectangle( 0, borderSize, borderSize, 2 ) ), color );
            spriteBatch.Draw( image, new Rectangle( x + borderSize, y + borderSize, width - borderSize * 2, height - borderSize * 2 ), new Rectangle?( new Rectangle( borderSize, borderSize, 2, 2 ) ), color );
        }

        public static void DrawNinePieces( this SpriteBatch spriteBatch, Texture2D image, Rectangle rectangle , int borderSize, Color color )
        {
            DrawNinePieces( spriteBatch , image , rectangle.X , rectangle.Y , rectangle.Width , rectangle.Height , borderSize , color );
        }
    }
}
