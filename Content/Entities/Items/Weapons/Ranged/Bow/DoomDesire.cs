using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ForgetMeNot.Content.Entities.Items.Weapons.Ranged.Bow
{ 
    public class DoomDesire : FmnModItem
    {

      

        public override void SetDefaults()
        {
            Item.damage = 54;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 4;
            Item.height = 4;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 5;
            Item.knockBack = 1f;
            Item.value = 2000;
            Item.rare = 10;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.crit = 9;
            Item.maxStack = 1;
            Item.scale = 1f;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 16f;
            Item.noMelee = true;

        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 0f);//手持的位置调整
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            for (int index = 0; index < 6; index++)
            {
             
                float SpeedX = velocity.X + (float)Main.rand.Next(-40, 41) * 0.05f;
                float SpeedY = velocity.Y + (float)Main.rand.Next(-40, 41) * 0.05f;
                int proj = Projectile.NewProjectile(source, position.X, position.Y, SpeedX, SpeedY, type, damage, knockback, player.whoAmI, 0f, 0f, 0f);
                Main.projectile[proj].extraUpdates += index;
                Main.projectile[proj].noDropItem = true;
            }
            if (Main.rand.Next(5) == 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    float spread = 0f * 0f; //10 degree cone
                    float baseSpeed = (float)System.Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                    double baseAngle = System.Math.Atan2(velocity.X, velocity.Y);
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                    float spdX = baseSpeed * (float)System.Math.Sin(randomAngle);
                    float spdY = baseSpeed * (float)System.Math.Cos(randomAngle);

                    Projectile.NewProjectile(source, position.X, position.Y, spdX, spdY, 503, damage + 120, knockback, player.whoAmI, 0f, 0f, 0f);
                }
            }
            return false;
        }
    }
}
