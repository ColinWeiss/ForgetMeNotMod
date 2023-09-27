using ForgetMeNot.Common.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace ForgetMeNot.Common.Items
{
    public class GunsDiffusion_PlayerEffect : ModPlayer
    {
        public override bool IsCloneable => true;

        public int Diffusion = 10;

        public override void ResetEffects()
        {
            Diffusion = 10;
            base.ResetEffects();
        }
    }
    public class GunsDiffusion : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public int Diffusion = 0;
        public int Success = 3;



        public override void SetDefaults(Item item)
        {

            //这里对一些枪械的精准度进行初始化.
            base.SetDefaults(item);

        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            if (item.useAmmo == AmmoID.Bullet)
            {
                float currentRot = velocity.ToRotation();
                float cDiffusion = player.GetModPlayer<GunsDiffusion_PlayerEffect>().Diffusion + Diffusion;
                cDiffusion = Math.Clamp(cDiffusion, 0, 90);
                if (Main.rand.Next(100) <= Success)
                {
                    CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(50, 205, 50), "精确打击！", false, false);
                    SoundStyle strike = new SoundStyle("ForgetMeNot/Sounds/Custom/Accurate Strike", 0);
                    strike.Volume = 0.5f;
                    SoundEngine.PlaySound(strike, default(Vector2?), null);
                }
                else if (cDiffusion > 0)
                {
                    if (Main.rand.NextBool())
                        currentRot += Main.rand.Next((int)((double)cDiffusion)).GetRot();
                    else
                        currentRot -= Main.rand.Next((int)((double)cDiffusion)).GetRot();
                }
                velocity = currentRot.ToRotationVector2() * velocity.Length();
                player.itemRotation = currentRot;
                base.ModifyShootStats(item, player, ref position, ref velocity, ref type, ref damage, ref knockback);
            }


        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {

            if (item.useAmmo == AmmoID.Bullet)
            {
                int insertIndex = tooltips.FindIndex(a => a.Name == "CritChance");
                if (insertIndex != -1)
                {
                    int cDiffusion = Main.LocalPlayer.GetModPlayer<GunsDiffusion_PlayerEffect>().Diffusion + Diffusion;
                    cDiffusion = Math.Clamp(cDiffusion, 0, 90);
                    if (cDiffusion > 0)
                    {
                        TooltipLine diffusion = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat(cDiffusion * 2, "°", " 扩散幅度"));
                        diffusion.OverrideColor = new Color(255, 102, 91);
                        tooltips.Insert(insertIndex + 1, diffusion);
                        if (cDiffusion > 10 && cDiffusion < 35)
                        {
                            TooltipLine diffusionp = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat("此武器精度较差 "));
                            diffusionp.OverrideColor = new Color(139, 0, 0);
                            tooltips.Insert(insertIndex + 1, diffusionp);

                        }
                        else if (cDiffusion >= 35)
                        {
                            TooltipLine diffusionp = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat("*此武器精度严重不足* "));
                            diffusionp.OverrideColor = new Color(139, 0, 0);
                            tooltips.Insert(insertIndex + 1, diffusionp);

                        }
                    }
                    else
                    {
                        TooltipLine diffusion = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat("「校准完备」"));
                        diffusion.OverrideColor = new Color(255, 177, 43);
                        tooltips.Insert(insertIndex + 1, diffusion);
                    }

                }
            }




            if ((item.accessory || item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0) && Diffusion > 0)
            {
                int insertIndex = tooltips.FindIndex(a => a.Name == "Equipable");
                if (insertIndex != -1)
                {
                    if (Diffusion > 0)
                    {
                        TooltipLine diffusion = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat(Diffusion * 2, "°", " 枪械校准"));
                        TooltipLine diffusion1 = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat("「精准度提升中！」"));
                        diffusion1.OverrideColor = new Color(255, 165, 0);
                        tooltips.Insert(insertIndex + 1, diffusion);
                        tooltips.Insert(insertIndex + 1, diffusion1);
                    }
                    else
                    {
                        TooltipLine diffusion = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat(Diffusion * 2, "°", " 枪械校准"));
                        TooltipLine diffusion1 = new TooltipLine(Mod, "ForgetMeNot_SpBoxInclude_Diffusion", string.Concat("「你的精准度下降了！」"));
                        diffusion1.OverrideColor = new Color(139, 0, 0);
                        tooltips.Insert(insertIndex + 1, diffusion);
                        tooltips.Insert(insertIndex + 1, diffusion1);
                    }
                }

            }

            base.ModifyTooltips(item, tooltips);


        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (Diffusion > 0)
            {
                player.GetModPlayer<GunsDiffusion_PlayerEffect>().Diffusion -= Diffusion;
            }
            base.UpdateEquip(item, player);
        }

    }
    public static class GunsDiffusion_Helper
    {
        public static void SetDiffusion(this Item item, float value)
        {
            item.GetGlobalItem<GunsDiffusion>().Diffusion = (int)((double)value) / 2;
        }
    }

}