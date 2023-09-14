using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace ForgetMeNot.Content.Entities.Items.Weapons
{
	public class DeathStar : FmnModItem
	{
		

		public override void SetDefaults()
		{
			Item.damage = 142;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 4;
			Item.height = 4;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 5f;
			Item.value = 2000;
			Item.rare = 4;
			Item.UseSound = new SoundStyle($"{nameof(ForgetMeNot)}/Sounds/Items/Weapons/LaserCannon")
            {
                Volume = 0.9f,
                PitchVariance = 0.3f,
                MaxInstances = 2,
            };
            Item.autoReuse = true;
			Item.useTurn = true;
			Item.crit = 0;
			Item.maxStack = 1;
			Item.scale = 1f;
			Item.useAmmo = AmmoID.Bullet;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
            Item.shoot = 8;
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 6; i++)
			{
				float spread = 20f * 0.023f; //10 degree cone
                float baseSpeed = (float)System.Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                double baseAngle = System.Math.Atan2(velocity.X, velocity.Y);
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                float speedX2 = velocity.X + (float)Main.rand.Next(-20, 21) * 0.05f;
				float speedY2 = velocity.Y + (float)Main.rand.Next(-20, 21) * 0.05f;

				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, Mod.Find<ModProjectile>("DeathLaser").Type, damage, knockback, player.whoAmI);
			}
			return false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14f, 0f);//手持的位置调整
		}
	}
}

		

		
		

