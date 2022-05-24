using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Consolaria.Content.Items.BossDrops.Ocram
{
	[AutoloadEquip(EquipType.Head)]
	public class OcramMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ocram Mask");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			int width = 20; int height = 24;
			Item.Size = new Vector2(width, height);

			Item.value = Item.sellPrice(silver: 75);
			Item.rare = ItemRarityID.Blue;

			Item.vanity = true;
			Item.maxStack = 1;
		}
	}
}