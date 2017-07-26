using ModConfiguration;
using Terraria;
using Terraria.ModLoader;

namespace InsightReborn {
    public class GlobalChestTile : GlobalTile {
        private static Chest lastChest;

        public override bool Autoload(ref string name) {
            return true;
        }

        public override void MouseOver(int i, int j, int type) {
            InsightReborn.ChestContents.Open = false;
            base.MouseOver(i, j, type);
        }

        public override void MouseOverFar(int i, int j, int type) {
            bool requiresAccessory = (bool)ModConfig.GetOption(InsightReborn.REQUIRES_ACCESSORY);

            if(!requiresAccessory || (requiresAccessory && Main.LocalPlayer.GetModPlayer<InsightRebornPlayer>().accXRayGoggles)) {
                int chestIndex = GetChest(i, j);

                if(chestIndex > -1) {
                    Chest chest = Main.chest[chestIndex];

                    if(lastChest == null || chest.x != lastChest.x || chest.y != lastChest.y) {
                        InsightReborn.ChestContents.SetItems(chest);
                    }

                    lastChest = chest;
                    InsightReborn.ChestContents.Open = true;
                }
                else {
                    InsightReborn.ChestContents.Open = false;
                }
            }
        }

        private int GetChest(int i, int j) {
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
