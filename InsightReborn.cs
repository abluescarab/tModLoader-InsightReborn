using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ModConfiguration;
using Terraria.ModLoader;

namespace InsightReborn {
    public class InsightReborn : Mod {
        public const string REQUIRES_ACCESSORY = "RequiresAccessory";

        public static ChestContentsUI ChestContents { get; set; }

        public override void Load() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadSounds = true
            };

            ModConfig.ModName = "InsightReborn";
            ModConfig.AddOption(REQUIRES_ACCESSORY, true);
            ModConfig.Load();

            ChestContents = new ChestContentsUI(this.Name, new Vector2(10, 35));
            AddGlobalTile("GlobalChestTile", new GlobalChestTile());
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch) {
            if(ChestContents.Open) {
                ChestContents.Draw(spriteBatch);
            }

            base.PostDrawInterface(spriteBatch);
        }
    }
}
