﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Diagnostics;

namespace InsightReborn.UI {
    public class UIPanel : UIObject {
        public Texture2D t;
        public bool transparent = false;

        public UIPanel(Vector2 pos, Vector2 size, UIObject parent = null, Texture2D fullTexture = null,
            bool transparent = false) : base(pos, size, parent) {
            t = fullTexture;
            this.transparent = transparent;
        }

        public override void Draw(SpriteBatch sb) {
            Vector2 position = this.position;

            if(parent != null) {
                position += this.parent.position;
            }

            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)this.size.X, (int)this.size.Y);

            if(!transparent) {
                if(this.t != null) {
                    sb.Draw(this.t, this.rectangle, Color.White);
                }
                else {
                    BaseTextureDrawing.DrawTerrariaStyledBox(sb, new Color(10, 10, 140), this.rectangle);
                }
            }

            base.Draw(sb);
        }
    }
}
