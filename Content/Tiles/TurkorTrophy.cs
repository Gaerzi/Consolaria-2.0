using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Consolaria.Content.Tiles {
    public class TurkorTrophy : ModTile {
        public override void SetStaticDefaults () {
            Main.tileFrameImportant [Type] = true;
            Main.tileLavaDeath [Type] = true;
            TileID.Sets.FramesOnKillWall [Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(120, 85, 60), Language.GetText("MapObject.Trophy"));
            DustType = 7;
        }

        public override void KillMultiTile (int i, int j, int frameX, int frameY)
            => Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<Items.BossDrops.Turkor.TurkorTrophy>());
    }
}