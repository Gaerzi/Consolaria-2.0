using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Consolaria.Content.Tiles {
	public class EerieOcramMusicBox : ModTile {
		public override void SetStaticDefaults () {
			Main.tileFrameImportant [Type] = true;
			Main.tileObsidianKill [Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);

			AdjTiles = new int [] { TileID.MusicBoxes };

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Music Box");
			AddMapEntry(new Color(200, 200, 200), name);
		}

		public override void KillMultiTile (int i, int j, int frameX, int frameY)
			=> Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<Items.BossDrops.Ocram.EerieOcramMusicBox>());

		public override void MouseOver (int i, int j) {
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.BossDrops.Ocram.EerieOcramMusicBox>();
		}
	}
}