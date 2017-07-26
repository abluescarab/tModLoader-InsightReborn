using Terraria.ModLoader;

namespace InsightReborn {
    public class InsightRebornPlayer : ModPlayer {
        public bool accXRayGoggles = false;

        public override void ResetEffects() {
            accXRayGoggles = false;
        }
    }
}
