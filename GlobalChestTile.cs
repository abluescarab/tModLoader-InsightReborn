using Terraria;
using Terraria.ModLoader;

namespace InsightReborn {
    public class GlobalChestTile : GlobalTile {
        public override bool Autoload(ref string name) {
            return true;
        }

        public override void MouseOver(int i, int j, int type) {
            InsightReborn.ChestContents.Open = false;
            base.MouseOver(i, j, type);
        }

        public override void MouseOverFar(int i, int j, int type) {
            if(TileLoader.IsChest(type)) {
                if(!InsightReborn.ChestContents.Open) {
                    InsightReborn.ChestContents.SetItems(GetChest(i, j, type));
                    InsightReborn.ChestContents.Open = true;
                }
            }
            else {
                InsightReborn.ChestContents.Open = false;
            }

            base.MouseOverFar(i, j, type);
        }

        private int GetChest(int i, int j, int type) {
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];

            if(tile.frameX % 36 != 0) {
                left--;
            }
            if(tile.frameY != 0) {
                top--;
            }

            return Chest.FindChest(left, top);
        }
    }
}
