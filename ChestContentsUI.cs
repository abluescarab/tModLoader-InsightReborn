using CustomSlot;
using CustomSlot.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace InsightReborn {
    public class ChestContentsUI : UIState {
        private const int MaxSlots = 8;
        private const int RowCount = 2;
        private const int SlotsPerRow = MaxSlots / RowCount;

        private UIPanel panel;
        private List<CustomItemSlot> _slots;

        public bool Visible { get; set; } = false;
        public float SlotMargin { get; set; } = 5;
        public Vector2 PopupOffset { get; set; } = new Vector2(10, 35);

        public override void OnInitialize() {
            panel = new UIPanel();
            float slotX = 0;
            float slotY = 0;
            StyleDimension slotWidth = new StyleDimension(0, 0);
            StyleDimension slotHeight = new StyleDimension(0, 0);

            _slots = new List<CustomItemSlot>(MaxSlots);

            for(int i = 0; i < MaxSlots; i++) {
                CustomItemSlot slot = new CustomItemSlot(scale: 0.75f) {
                    BackgroundTexture = new CroppedTexture2D(TextureAssets.InventoryBack5.Value)
                };

                slot.Left.Set(slotX, 0);
                slot.Top.Set(slotY, 0);

                slotWidth = slot.Width;
                slotHeight = slot.Height;

                _slots.Add(slot);
                panel.Append(slot);

                if((i + 1) % SlotsPerRow == 0) {
                    slotX = 0;
                    slotY += (slotHeight.Pixels + SlotMargin);
                }
                else {
                    slotX += (slotWidth.Pixels + SlotMargin);
                }
            }

            panel.Width.Set(SlotsPerRow * (slotWidth.Pixels + SlotMargin) + (SlotMargin * 4), 0);
            panel.Height.Set(RowCount * (slotHeight.Pixels + SlotMargin) + (SlotMargin * 4), 0);

            Append(panel);
        }

        public void SetItems(Chest chest) {
            Item[] items = chest.item.Where(i => i.stack > 0).ToArray();

            for(int i = 0; i < MaxSlots; i++) {
                if(items.Length < (i + 1)) {
                    _slots[i].SetItem(new Item());
                }
                else {
                    _slots[i].SetItem(items[i]);
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            panel.Left.Set(Main.MouseScreen.X + PopupOffset.X, 0);
            panel.Top.Set(Main.MouseScreen.Y + PopupOffset.Y, 0);
        }
    }
}
