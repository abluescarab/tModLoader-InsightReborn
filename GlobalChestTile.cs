using Terraria;
using Terraria.ModLoader;

namespace InsightReborn {
    public class GlobalChestTile : GlobalTile {
        public override void MouseOver(int i, int j, int type) {
            InsightRebornSystem.UI.Visible = false;
            base.MouseOver(i, j, type);
        }

        public override void MouseOverFar(int i, int j, int type) {
            if(InsightRebornConfig.Instance.RequiresGoggles && !Main.LocalPlayer.GetModPlayer<InsightRebornPlayer>().accXRayGoggles)
                return;

            int chestIndex = GetChest(i, j);
            
            if(chestIndex > -1) {
                Chest chest = Main.chest[chestIndex];
                InsightRebornSystem.UI.SetItems(chest);
                InsightRebornSystem.UI.Visible = true;
            }
            else {
                InsightRebornSystem.UI.Visible = false;
            }
        }

        private int GetChest(int i, int j) {
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];

            if(tile.TileFrameX % 36 != 0) {
                left--;
            }

            if(tile.TileFrameY != 0) {
                top--;
            }

            return Chest.FindChest(left, top);
        }
    }
}
