using System;
using ForgetMeNot.Common.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgetMeNot.Content.Entities.Items.Weapons.Ranged.Gun
{
    /// <summary>
    /// 公爵.
    /// </summary>
    public class CGUN : FmnModItem
    {
        public override void SetStaticDefaults( )
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults( )
        {
            SetSize(48, 20 );
           
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 28;
            Item.crit = 42;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.knockBack = 0.6f;
            Item.SetDiffusion( -20 );
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 12f;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;
            Item.maxStack = 1;
            Item.rare = 2;
        }

        public override void ModifyShootStats( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback )
        {
            type = 242;
            base.ModifyShootStats( player, ref position, ref velocity, ref type, ref damage, ref knockback );
        }

        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -10f, 1.1f ) );
        }

       
    }
}