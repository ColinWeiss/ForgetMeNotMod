using System;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using Terraria;

namespace ForgetMeNot.Common.Utils
{
    public static class ModUtils
    {


        public static Vector2 Random( int rand )
        {
            return new Vector2( Terraria.Utils.NextBool( Main.rand ) ? Main.rand.Next( rand ) : -(float)Main.rand.Next( rand ), Terraria.Utils.NextBool( Main.rand ) ? Main.rand.Next( rand ) : -(float)Main.rand.Next( rand ) );
        }


        public static void Progressive( NPC npc, Vector2 target, float speed )
        {
            float progressiveFactor = 20f;
            Vector2 targetPos = Vector2.Normalize( target ) * progressiveFactor;
            npc.velocity = (npc.velocity * (speed - 1f) + targetPos) / speed;
        }


        public static Vector2 SpinDust( Vector2 center, Vector2 objectPosition, bool clockwise, float speed = 10f )
        {
            speed -= 1f;
            float num = Terraria.Utils.ToRotation( objectPosition - center );
            float X = (float)Math.Cos( (double)num ) * speed;
            float Y = (float)Math.Sin( (double)num ) * speed;
            float Y2 = (float)Math.Cos( (double)num ) * speed * (clockwise ? 1 : -1);
            return new Vector2( -(-(Y * Y2) / X), -Y2 );
        }

        public static void DustCircle( int dustType, Vector2 center, float r, int quantity )
        {
            for( int i = 0; i < quantity; i++ )
            {
                Vector2 vector2 = Vector2.One * r;
                vector2 = Terraria.Utils.RotatedBy( vector2, (double)((i - (quantity / 2 - 1)) * 6.2831855f / quantity), default( Vector2 ) ) + center;
                Vector2 vector3 = vector2 - center;
                int num21 = Dust.NewDust( vector2 + vector3, 0, 0, dustType, vector3.X * 1.1f, vector3.Y * 1.1f, 100, new Color( 255, 255, 255, 30 ), 1.4f );
                Main.dust[num21].noGravity = true;
                Main.dust[num21].noLight = true;
                Main.dust[num21].velocity = Vector2.Normalize( vector3 ) * 3f;
            }
        }


        public static float GetLerpValue( float from, float to, float t )
        {
            bool flag = from < to;
            if( flag )
            {
                bool flag2 = t < from;
                if( flag2 )
                {
                    return 0f;
                }
                bool flag3 = t > to;
                if( flag3 )
                {
                    return 1f;
                }
            }
            return (t - from) / (to - from);
        }


        public static float GetLerpValue( float from, float to, float t, bool clamped = false )
        {
            if( clamped )
            {
                bool flag = from < to;
                if( flag )
                {
                    bool flag2 = t < from;
                    if( flag2 )
                    {
                        return 0f;
                    }
                    bool flag3 = t > to;
                    if( flag3 )
                    {
                        return 1f;
                    }
                }
                else
                {
                    bool flag4 = t < to;
                    if( flag4 )
                    {
                        return 1f;
                    }
                    bool flag5 = t > from;
                    if( flag5 )
                    {
                        return 0f;
                    }
                }
            }
            return (t - from) / (to - from);
        }


        public static Vector2 Size( this DynamicSpriteFont font )
        {
            return font.MeasureString( "口" );
        }

        public static bool IsWeapon( this Item Item )
        {
            return Item.useStyle > 0 && (Item.damage > 0 || Item.crit > 0 || Item.knockBack > 0f) && !Item.accessory && !Item.consumable;
        }
    }
}
