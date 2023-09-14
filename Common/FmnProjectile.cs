using System;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgetMeNot.Common
{ 
    public class FmnGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

      
        public Color customColor = Color.White;
        public bool useCustomColor = false;
        public Vector2 vec = Vector2.Zero;
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            if (useCustomColor)
                return new Color(customColor.R - projectile.alpha, customColor.G - projectile.alpha, customColor.B - projectile.alpha, 255 - projectile.alpha);
            return base.GetAlpha(projectile, lightColor);
        }


        public float speedMutiply = 1;
        public override void PostAI(Projectile projectile)
        {
            projectile.position += projectile.velocity * (speedMutiply - 1);
        }








        public static void DrawCenteredAndAfterimage(Projectile projectile, Color lightColor, int trailingMode, int afterimageCounter, Texture2D texture = null)
        {
            if (texture == null)
            {
                texture = TextureAssets.Projectile[projectile.type].Value;
            }
            int num = texture.Height / Main.projFrames[projectile.type];
            int y = num * projectile.frame;
            Rectangle rectangle = new Rectangle(0, y, texture.Width, num);
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            if (Lighting.NotRetro)
            {
                if (trailingMode != 0)
                {
                    if (trailingMode == 1)
                    {
                        Color color = Lighting.GetColor((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f));
                        int num2 = 8;
                        for (int i = 1; i < num2; i += afterimageCounter)
                        {
                            Color color2 = color;
                            color2 = projectile.GetAlpha(color2);
                            float num3 = (float)(num2 - i);
                            color2 *= num3 / ((float)ProjectileID.Sets.TrailCacheLength[projectile.type] * 1.5f);
                            Main.spriteBatch.Draw(texture, projectile.oldPos[i] + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(rectangle), color2, projectile.rotation, rectangle.Size() / 2f, projectile.scale, effects, 0f);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < projectile.oldPos.Length; j++)
                    {
                        Vector2 position = projectile.oldPos[j] + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
                        Color color3 = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - j) / (float)projectile.oldPos.Length);
                        Main.spriteBatch.Draw(texture, position, new Rectangle?(rectangle), color3, projectile.rotation, rectangle.Size() / 2f, projectile.scale, effects, 0f);
                    }
                }
            }
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture.Width, num)), projectile.GetAlpha(lightColor), projectile.rotation, new Vector2((float)texture.Width / 2f, (float)num / 2f), projectile.scale, effects, 0f);
        }
    }
}

		