using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgetMeNot.Content.Entities.Items.Weapons.Ranged.Gun.GunProj
{
    public class Deathboom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
          
            Main.projFrames[base.Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 8;
            base.Projectile.height = 8;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = false;
            base.Projectile.alpha = 255;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 60;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            Lighting.AddLight(base.Projectile.Center, 0.9f, 0.8f, 0.6f);
            base.Projectile.ai[1] += 0.01f;
            base.Projectile.scale = base.Projectile.ai[1] * 0.5f;
            base.Projectile.ai[0] += 1f;
            if (base.Projectile.ai[0] >= (float) (3 * Main.projFrames[base.Projectile.type]))
            {
                base.Projectile.Kill();
                return;
            }
            int num = base.Projectile.frameCounter + 1;
            base.Projectile.frameCounter = num;
            if (num >= 3)
            {
                base.Projectile.frameCounter = 0;
                num = base.Projectile.frame + 1;
                base.Projectile.frame = num;
                if (num >= Main.projFrames[base.Projectile.type])
                {
                    base.Projectile.hide = true;
                }
            }
            base.Projectile.alpha -= 63;
            if (base.Projectile.alpha < 0)
            {
                base.Projectile.alpha = 0;
            }
            if (base.Projectile.ai[0] == 1f)
            {
                base.Projectile.position = base.Projectile.Center;
                base.Projectile.width = (base.Projectile.height = (int) (52f * base.Projectile.scale));
                base.Projectile.Center = base.Projectile.position;
                SoundEngine.PlaySound(SoundID.Item14, base.Projectile.position);
                for (int i = 0; i < 4; i++)
                {
                    int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num2].position = base.Projectile.Center + Utils.RotatedByRandom(Vector2.UnitY, 3.1415927410125732) * (float) Main.rand.NextDouble() * base.Projectile.width / 2f;
                }
                for (int j = 0; j < 10; j++)
                {
                    int num3 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 21, 0f, 0f, 200, default(Color), 2.7f);
                    Main.dust[num3].position = base.Projectile.Center + Utils.RotatedByRandom(Vector2.UnitY, 3.1415927410125732) * (float) Main.rand.NextDouble() * base.Projectile.width / 2f;
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity *= 3f;
                    num3 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 27, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num3].position = base.Projectile.Center + Utils.RotatedByRandom(Vector2.UnitY, 3.1415927410125732) * (float) Main.rand.NextDouble() * base.Projectile.width / 2f;
                    Main.dust[num3].velocity *= 2f;
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].fadeIn = 2.5f;
                }
                for (int k = 0; k < 5; k++)
                {
                    int num4 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 6, 0f, 0f, 0, default(Color), 2.7f);
                    Main.dust[num4].position = base.Projectile.Center + Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 3.1415927410125732), Utils.ToRotation(base.Projectile.velocity)) * base.Projectile.width / 2f;
                    Main.dust[num4].noGravity = true;
                    Main.dust[num4].velocity *= 3f;
                }
                for (int l = 0; l < 10; l++)
                {
                    int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 31, 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[num5].position = base.Projectile.Center + Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 3.1415927410125732), Utils.ToRotation(base.Projectile.velocity)) * base.Projectile.width / 2f;
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].velocity *= 3f;
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return base.Projectile.ai[0] > 1f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 127);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(153, 300);
            base.Projectile.direction = Main.player[base.Projectile.owner].direction;
        }

     

      
    }
}
