using System.Collections.Generic;
using System.Linq;
using InsightReborn.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;

namespace InsightReborn {
    public class ChestContentsUI {
        private const int maxSlots = 8;
        private const int rowCount = 2;
        private UIObject uiObject;
        private List<UIItemSlot> slots;

        public bool Open { get; set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float SlotWidth { get; set; }
        public float SlotHeight { get; set; }
        public float SlotMargin { get; set; }
        public Vector2 PopupOffset { get; set; }

        public ChestContentsUI(string mod, Vector2 popupOffset, float slotWidth = 52, float slotHeight = 52,
            float slotMargin = 5) {
            UIParameters.MODNAME = mod;
            PopupOffset = popupOffset;
            SlotWidth = slotWidth;
            SlotHeight = slotHeight;
            SlotMargin = slotMargin;
            
            Initialize();
        }

        private void Initialize() {
            float slotX = SlotMargin;
            float slotY = SlotMargin;

            int slotsPerRow = maxSlots / rowCount;

            Width = (SlotMargin * (slotsPerRow + 1)) + (SlotWidth * slotsPerRow);
            Height = (SlotMargin * (rowCount + 1)) + (SlotHeight * rowCount);
            float locX = (Main.screenWidth / 2) - (Width / 2);
            float locY = (Main.screenHeight / 2) - (Height / 2);

            UIPanel background = new UIPanel(new Vector2(locX, locY), new Vector2(Width, Height), transparent: true);

            slots = new List<UIItemSlot>(maxSlots);

            for(int i = 1; i <= maxSlots; i++) {
                UIItemSlot slot = new UIItemSlot(
                    pos: new Vector2(slotX, slotY),
                    parent: background,
                    con: delegate(Item item) {
                        return false;
                    },
                    pdi: delegate(SpriteBatch spriteBatch, UIItemSlot itemSlot) {
                        if(itemSlot.item.stack > 1) {
                            string stack = itemSlot.item.stack.ToString();
                            SpriteFont font = Main.fontItemStack;
                            Vector2 textSize = font.MeasureString(stack);
                            float textW = textSize.X;
                            float textH = textSize.Y;

                            spriteBatch.DrawString(
                                font,
                                stack,
                                new Vector2(
                                    itemSlot.rectangle.X + (itemSlot.rectangle.Width / 2) - (textW / 2),
                                    itemSlot.rectangle.Y + itemSlot.rectangle.Height - textH + (textH / 3)),
                                Color.White);
                        }
                    });

                slots.Add(slot);

                if(i % (maxSlots / rowCount) == 0) {
                    slotX = SlotMargin;
                    slotY += (SlotHeight + SlotMargin);
                }
                else {
                    slotX += (SlotWidth + SlotMargin);
                }

                background.children.Add(slot);
            }

            uiObject = background;
        }

        public void SetItems(Chest chest) {
            Item[] items = chest.item.Where(i => i.stack > 0).ToArray();

            for(int i = 0; i < maxSlots; i++) {
                if(items.Length < (i + 1)) {
                    slots[i].item = new Item();
                }
                else {
                    slots[i].item = items[i];
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            MouseState state = Mouse.GetState();
            uiObject.position.X = state.X + PopupOffset.X;
            uiObject.position.Y = state.Y + PopupOffset.Y;

            uiObject.Draw(spriteBatch);
        }
    }
}
