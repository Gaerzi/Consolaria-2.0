using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Consolaria.Content.Tiles
{
	public class Banners : ModTile {
		public override void SetStaticDefaults () {
			Main.tileFrameImportant [Type] = true;
			Main.tileNoAttach [Type] = true;
			Main.tileLavaDeath [Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new [] { 16, 16, 16 };

			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);

			TileID.Sets.DisableSmartCursor [Type] = true;
			AddMapEntry(new Color(233, 207, 94), Language.GetText("MapObject.Banner"));
		}

		public override void KillMultiTile (int i, int j, int frameX, int frameY) {
			int bannerType = frameX / 18;
			int itemType = -1;
			switch (bannerType) {
			case 0:
			itemType = ModContent.ItemType<Items.Banners.ArchWyvernBanner>();
			break;
			case 1:
			itemType = ModContent.ItemType<Items.Banners.DragonSnatcherBanner>();
			break;
			case 2:
			itemType = ModContent.ItemType<Items.Banners.SpectralElementalBanner>();
			break;
			case 3:
			itemType = ModContent.ItemType<Items.Banners.SpectralGastropodBanner>();
			break;
			case 4:
			itemType = ModContent.ItemType<Items.Banners.ShadowMummyBanner>();
			break;
			case 5:
			itemType = ModContent.ItemType<Items.Banners.ShadowHammerBanner>();
			break;
			case 6:
			itemType = ModContent.ItemType<Items.Banners.VampireMinerBanner>();
			break;
			case 7:
			itemType = ModContent.ItemType<Items.Banners.OrcaBanner>();
			break;
			case 8:
			itemType = ModContent.ItemType<Items.Banners.AlbinoAntlionBanner>();
			break;
			case 9:
			itemType = ModContent.ItemType<Items.Banners.ShadowMummyBanner>();
			break;
			case 10:
			itemType = ModContent.ItemType<Items.Banners.DragonHornetBanner>();
			break;
			case 11:
			itemType = ModContent.ItemType<Items.Banners.ArchDemonBanner>();
			break;
			case 12:
			itemType = ModContent.ItemType<Items.Banners.ShadowSlimeBanner>();
			break;
			case 13:
			itemType = ModContent.ItemType<Items.Banners.DisasterBunnyBanner>();
			break;
			case 14:
			itemType = ModContent.ItemType<Items.Banners.MythicalWyvernBanner>();
			break;
			case 15:
			itemType = ModContent.ItemType<Items.Banners.DragonSkullBanner>();
			break;
			case 16:
			itemType = ModContent.ItemType<Items.Banners.FleshSlimeBanner>();
			break;
			case 17:
			itemType = ModContent.ItemType<Items.Banners.FleshMummyBanner>();
			break;
			case 18:
			itemType = ModContent.ItemType<Items.Banners.FleshAxeBanner>();
			break;
			case 19:
			itemType = ModContent.ItemType<Items.Banners.AlbinoChargerBanner>();
			break;
			default:
			return;
			}
			if (itemType != -1)
				Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, itemType);
		}

		public override void NearbyEffects (int i, int j, bool closer) {
			Player player = Main.LocalPlayer;
			if (player == null || !player.active || player.dead) {
				return;
			}
			int bannerType = Main.tile [i, j].TileFrameX / 18;
			int npcType = -1;
			if (closer) {
				switch (bannerType) {
				case 0:
				npcType = ModContent.NPCType<NPCs.ArchWyvernBody1>();
				npcType = ModContent.NPCType<NPCs.ArchWyvernBody2>();
				npcType = ModContent.NPCType<NPCs.ArchWyvernBody3>();
				npcType = ModContent.NPCType<NPCs.ArchWyvernLegs>();
				npcType = ModContent.NPCType<NPCs.ArchWyvernHead>();
				break;
				case 1:
				npcType = ModContent.NPCType<NPCs.DragonSnatcher>();
				break;
				case 2:
				npcType = ModContent.NPCType<NPCs.SpectralElemental>();
				break;
				case 3:
				npcType = ModContent.NPCType<NPCs.SpectralGastropod>();
				break;
				case 4:
				npcType = ModContent.NPCType<NPCs.ShadowMummy>();
				break;
				case 5:
				npcType = ModContent.NPCType<NPCs.ShadowHammer>();
				break;
				case 6:
				npcType = ModContent.NPCType<NPCs.VampireMiner>();
				break;
				case 7:
				npcType = ModContent.NPCType<NPCs.Orca>();
				break;
				case 8:
				npcType = ModContent.NPCType<NPCs.AlbinoAntlion>();
				break;
				case 9:
				npcType = ModContent.NPCType<NPCs.ShadowMummy>();
				break;
				case 10:
				npcType = ModContent.NPCType<NPCs.DragonHornet>();
				break;
				case 11:
				npcType = ModContent.NPCType<NPCs.ArchDemon>();
				break;
				case 12:
				npcType = ModContent.NPCType<NPCs.ShadowSlime>();
				break;
				case 13:
				npcType = ModContent.NPCType<NPCs.Bosses.Lepus.DisasterBunny>();
				break;
				case 14:
				npcType = ModContent.NPCType<NPCs.MythicalWyvernBody>();
				npcType = ModContent.NPCType<NPCs.MythicalWyvernBody2>();
				npcType = ModContent.NPCType<NPCs.MythicalWyvernBody3>();
				npcType = ModContent.NPCType<NPCs.MythicalWyvernLegs>();
				npcType = ModContent.NPCType<NPCs.MythicalWyvernHead>();
				break;
				case 15:
				npcType = ModContent.NPCType<NPCs.DragonSkull>();
				break;
				case 16:
				npcType = ModContent.NPCType<NPCs.FleshSlime>();
				break;
				case 17:
				npcType = ModContent.NPCType<NPCs.FleshMummy>();
				break;
				case 18:
				npcType = ModContent.NPCType<NPCs.FleshAxe>();
				break;
				case 19:
				npcType = ModContent.NPCType<NPCs.AlbinoCharger>();
				npcType = ModContent.NPCType<NPCs.GiantAlbinoCharger>();
				break;
				default:
				return;
				}
				if (bannerType != -1) {
					Main.SceneMetrics.NPCBannerBuff [npcType] = true;
					Main.SceneMetrics.hasBanner = true;
				}
			}
			else return;
		}

		public override void SetSpriteEffects (int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1)
				spriteEffects = SpriteEffects.FlipHorizontally;
		}
	}
}
