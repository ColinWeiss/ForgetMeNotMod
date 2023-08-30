namespace ForgetMeNot.Content.Entities.Items.Materials
{
    /// <summary>
    /// 砂钢锭.
    /// </summary>
    public class Sandsteel : FmnModItem
    {
        public override void SetDefaults( )
        {
            SetSize( 32 , 24 );
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 16;
            Item.value = Item.sellPrice( 0, 1, 24, 0 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( 1 ).
                AddRecipeGroup( RecipeGroupID.IronBar, 4 ).
                AddRecipeGroup( RecipeGroupID.Sand, 1 ).
                AddRecipeGroup( RecipeGroupID.Wood, 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}