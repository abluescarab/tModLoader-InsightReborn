using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace InsightReborn {
    internal class InsightRebornSystem : ModSystem {
        private UserInterface _interface;
        public static ChestContentsUI UI;

        public override void Load() {
            if(!Main.dedServ) {
                _interface = new UserInterface();
                UI = new ChestContentsUI();

                UI.Activate();
                _interface.SetState(UI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int layer = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));

            if(layer != -1) {
                layers.Insert(layer,
                    new LegacyGameInterfaceLayer("Insight Reborn: Chest Contents UI", () => {
                        if(UI.Visible) {
                            _interface.Draw(Main.spriteBatch, new GameTime());
                        }

                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        public override void Unload() {
            UI = null;
        }
    }
}
