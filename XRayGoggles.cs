using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InsightReborn {
    public class XRayGoggles : ModItem {
        public override void SetDefaults() {
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<InsightRebornPlayer>().accXRayGoggles = true;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddTile(TileID.Chairs);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
