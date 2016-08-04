using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace InsightReborn {
    public class InsightReborn : Mod {
        public static ChestContentsUI ChestContents { get; set; }

        public override void Load() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadSounds = true
            };
            
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
