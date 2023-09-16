using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace ForgetMeNot.Content.Entities.Items.Weapons.Ranged.Bow
{
	public class Arathi : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 4;
			Item.height = 4;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 5;
			Item.knockBack = 0.5f;
			Item.value = 2000;
			Item.rare = 10;
            Item.UseSound = new SoundStyle($"{nameof(ForgetMeNot)}/Sounds/Items/Weapons/ArathiS")
            {
                Volume = 0.9f,
                PitchVariance = 0.3f,
                MaxInstances = 2,
            };
            Item.autoReuse = true;
			Item.useTurn = true;
			Item.crit = 8;
			Item.maxStack = 1;
			Item.scale = 1.4f;
			Item.shoot = base.Mod.Find<ModProjectile>("ArathiRedProj").Type;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 3; i++)
			{

				type = ((Main.rand.Next(2) == 0) ? base.Mod.Find<ModProjectile>("ArathiRedProj").Type : base.Mod.Find<ModProjectile>("ArathiPurpleProj").Type);
				Projectile.NewProjectile(source, position, Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), 0.2617993950843811), type, damage, knockback, player.whoAmI, 0f, 0f);
				if (Main.rand.Next(2) == 0)
				{
					type = ((Main.rand.Next(2) == 0) ? base.Mod.Find<ModProjectile>("ArathiRedProj").Type : base.Mod.Find<ModProjectile>("ArathiPurpleProj").Type);
					Projectile.NewProjectile(source, position, Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), 0.2617993950843811), type, damage, knockback, player.whoAmI, 0f, 0f);
				}
			}
			return false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0f, 0f);//手持的位置调整
		}
	}
}

		

		
		

