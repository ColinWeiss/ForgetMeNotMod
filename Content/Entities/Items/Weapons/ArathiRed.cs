using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;


namespace ForgetMeNot.Content.Entities.Items.Weapons
{

    public class ArathiRed : ModProjectile
    {

        public override void SetStaticDefaults()
        {
           
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 19;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }


        public override void SetDefaults()
        {
            base.Projectile.width = 6;
            base.Projectile.height = 8;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.extraUpdates = 1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 90;
            base.Projectile.alpha = 0;
            base.Projectile.aiStyle = 2;
        }


        public override void AI()
        {
            int num = Dust.NewDust(base.Projectile.Center, 0, 0, 5, 0f, 0f, 0, default(Color), 1.15f);
            Main.dust[num].noGravity = true;
            if (base.Projectile.alpha > 0)
            {
                base.Projectile.alpha -= 25;
            }
            if (base.Projectile.alpha < 0)
            {
                base.Projectile.alpha = 0;
            }
            Lighting.AddLight(base.Projectile.Center, 0.6f, 0f, 0f);
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            float num2 = 100f;
            float num3 = 3f;
            if (base.Projectile.ai[1] == 0f)
            {
                base.Projectile.localAI[0] += num3;
                if (base.Projectile.localAI[0] > num2)
                {
                    base.Projectile.localAI[0] = num2;
                    return;
                }
            }
            else
            {
                base.Projectile.localAI[0] -= num3;
                if (base.Projectile.localAI[0] <= 0f)
                {
                    base.Projectile.Kill();
                    return;
                }
            }
        }


        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(220, 20, 60));
        }


        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 vector = new Vector2(3f, 4f);
            for (int i = 0; i < base.Projectile.oldPos.Length; i++)
            {
                Vector2 position = base.Projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, base.Projectile.gfxOffY);
                Color color = base.Projectile.GetAlpha(Color.White) * ((float)(base.Projectile.oldPos.Length - i) / (float)base.Projectile.oldPos.Length);
                Texture2D texture = (i == 0) ? ModContent.Request<Texture2D>("ForgetMeNot/Content/Entities/Items/Weapons/ArathiProjectile", (ReLogic.Content.AssetRequestMode)2).Value : TextureAssets.Projectile[base.Projectile.type].Value;
                spriteBatch.Draw(texture, position, null, color, base.Projectile.rotation, vector, base.Projectile.scale, effects, 0f);
            }
            return false;
        }
    }

}
