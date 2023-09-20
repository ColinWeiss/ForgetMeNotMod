using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;

namespace ForgetMeNot.Common
{
    public abstract class FmnModPlayer : ModPlayer
    {
        public bool bigscreenShake;
        public int bigscreenShaketime = 0;
        public bool critscreenShake;
        public int critscreenShaketime = 0;
        public bool simplescreenShake;
        public int simplescreenShaketime = 0;

        public override void ResetEffects()
        {
            if (bigscreenShaketime > 0)
            {
                bigscreenShaketime--;
            }
            if (bigscreenShaketime <= 0)
            {
                bigscreenShaketime = 0;
            }
            if (bigscreenShaketime > 0)
            {
                bigscreenShake = true;
            }
            if (bigscreenShaketime <= 0)
            {
                bigscreenShake = false;
            }
            if (simplescreenShaketime > 0)
            {
                simplescreenShaketime--;
            }
            if (simplescreenShaketime <= 0)
            {
                simplescreenShaketime = 0;
            }
            if (simplescreenShaketime > 0)
            {
                simplescreenShake = true;
            }
            if (simplescreenShaketime <= 0)
            {
                simplescreenShake = false;
            }
            if (critscreenShaketime > 0)
            {
                critscreenShaketime--;
            }
            if (critscreenShaketime <= 0)
            {
                critscreenShaketime = 0;
            }
            if (critscreenShaketime > 0)
            {
                critscreenShake = true;
            }
            if (critscreenShaketime <= 0)
            {
                critscreenShake = false;
            }
        }

        public int screenShakeTime = 0;
        public Vector2 screenShakeModifier = Vector2.Zero;
        public Vector2 screenShakeVelocity = Vector2.One;

        public override void ModifyScreenPosition()
        {
            Main.screenPosition += screenShakeModifier;
        }

        public override void PostUpdate()
        {



            float maxScreenShakeDistance = 14;//晃动距离
            float screenShakeSpeed = 7;//晃动速度

            if (bigscreenShake)
            {
                maxScreenShakeDistance = 50;//晃动距离
                screenShakeSpeed = 30;//晃动速度
            }
            if (critscreenShake && !bigscreenShake && !simplescreenShake)
            {
                maxScreenShakeDistance = 6;//晃动距离
                screenShakeSpeed = 3;//晃动速度
            }
            if (simplescreenShake)
            {
                maxScreenShakeDistance = 14;//晃动距离
                screenShakeSpeed = 7;//晃动速度
            }

            if (screenShakeTime > 0)
            {
                screenShakeVelocity.Normalize();
                screenShakeVelocity *= screenShakeSpeed;
                screenShakeModifier += screenShakeVelocity;
                if (screenShakeModifier.Length() >= maxScreenShakeDistance)
                {
                    screenShakeModifier.Normalize();
                    screenShakeModifier *= maxScreenShakeDistance;
                    screenShakeVelocity = -screenShakeSpeed * screenShakeModifier.SafeNormalize(Vector2.Zero).RotatedByRandom(MathHelper.PiOver2);
                }
            }
            else
            {
                screenShakeModifier = screenShakeModifier.SafeNormalize(Vector2.Zero) * Math.Max(screenShakeModifier.Length() - screenShakeSpeed, 0);

            }
        }
        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using OnHitNPC instead */
        {

            if (hit.Crit)
            {
                SoundStyle strike = new SoundStyle("ForgetMeNot/Sounds/Custom/Crit", 0);
                strike.Volume = 0.5f;
                SoundEngine.PlaySound(strike, default(Vector2?), null);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y, Player.width, Player.height), new Color(220, 20, 60), "暴击！", true, true);
                Player.GetModPlayer<FmnModPlayer>().critscreenShaketime = 8;
                Player.GetModPlayer<FmnModPlayer>().screenShakeTime = 8;
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Projectile, consider using OnHitNPC instead */
        {
            if (hit.Crit)
            {
                SoundStyle strike = new SoundStyle("ForgetMeNot/Sounds/Custom/Crit", 0);
                strike.Volume = 0.5f;
                SoundEngine.PlaySound(strike, default(Vector2?), null);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y, Player.width, Player.height), new Color(220, 20, 60), "暴击！", true, true);
                Player.GetModPlayer<FmnModPlayer>().critscreenShaketime = 8;
                Player.GetModPlayer<FmnModPlayer>().screenShakeTime = 8;
            }
        }
     
    }
}