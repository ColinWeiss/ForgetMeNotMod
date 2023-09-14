using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgetMeNot.Content.Entities.Items.Weapons
{
    public class DeathLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("暗无天日");
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 8;
            base.Projectile.height = 8;
            base.Projectile.friendly = true;
            base.Projectile.extraUpdates = 10;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 200;
            base.Projectile.DamageType = DamageClass.Ranged;
        }

        public override void AI()
        {
            base.Projectile.spriteDirection = (base.Projectile.direction = Utils.ToDirectionInt(base.Projectile.velocity.X > 0f));
            base.Projectile.rotation = Utils.ToRotation(base.Projectile.velocity) + ((base.Projectile.spriteDirection == 1) ? 0f : ((float) Math.PI)) + MathHelper.ToRadians(90f) * (float) base.Projectile.direction;
            base.Projectile.localAI[0] += 1f;
            if (base.Projectile.localAI[0] > 4f)
            {
                float num = base.Projectile.velocity.X / 3f;
                float num2 = base.Projectile.velocity.Y / 3f;
                int num3 = 4;
                int num4 = Dust.NewDust(new Vector2(base.Projectile.position.X + (float) num3, base.Projectile.position.Y + (float) num3), base.Projectile.width - num3 * 2, base.Projectile.height - num3 * 2, 21, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num4].noGravity = true;
                Main.dust[num4].velocity *= 0.1f;
                Main.dust[num4].velocity += base.Projectile.velocity * 0.1f;
                Main.dust[num4].position.X -= num;
                Main.dust[num4].position.Y -= num2;
                if (Utils.NextBool(Main.rand, 20))
                {
                    int num5 = 4;
                    int num6 = Dust.NewDust(new Vector2(base.Projectile.position.X + (float) num5, base.Projectile.position.Y + (float) num5), base.Projectile.width - num5 * 2, base.Projectile.height - num5 * 2, 21, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num6].velocity *= 0.25f;
                    Main.dust[num6].velocity += base.Projectile.velocity * 0.5f;
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            if (base.Projectile.owner == Main.myPlayer)
            {
                int num = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), base.Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Deathboom>(), (int)((double)base.Projectile.damage * 0.3f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0.85f + Utils.NextFloat(Main.rand) * 1.15f);
                
            }
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(153, 60);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            FmnGlobalProjectile.DrawCenteredAndAfterimage(base.Projectile, lightColor, ProjectileID.Sets.TrailingMode[base.Projectile.type], 1);
            return false;
        }
    }
}
