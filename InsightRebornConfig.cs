using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace InsightReborn {
    public class InsightRebornConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static InsightRebornConfig Instance;

        [DefaultValue(true)]
        [Label("Require goggles accessory")]
        public bool RequiresGoggles;
    }
}
