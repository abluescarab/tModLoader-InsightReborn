using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InsightReborn {
    public class XRayGoggles : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("X-Ray Goggles");
            Tooltip.SetDefault("Shows the contents of chests from far away");
        }

        public override void SetDefaults() {
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<InsightRebornPlayer>().accXRayGoggles = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddTile(TileID.Chairs);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
