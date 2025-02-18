using Consolaria.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Content.Items.Pets {
	public class PotOfGold : PetItem {
		public override void SetStaticDefaults () {
			DisplayName.SetDefault("Pot O' Gold");
			Tooltip.SetDefault("Summons a pet Leprechaun O'Fyffe");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
		}

		public override void SetDefaults () {
			Item.DefaultToVanitypet(ModContent.ProjectileType<Projectiles.Friendly.Pets.Leprechaun>(), ModContent.BuffType<Buffs.Leprechaun>());

			int width = 28; int height = 40;
			Item.Size = new Vector2(width, height);

			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 1);
		}

		public override void AddRecipes () {
			CreateRecipe()
				.AddIngredient<RainbowPiece>(5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}