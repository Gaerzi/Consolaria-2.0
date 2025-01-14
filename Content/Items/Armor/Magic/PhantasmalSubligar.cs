using Consolaria.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Content.Items.Armor.Magic {
    [AutoloadEquip(EquipType.Legs)]
    public class PhantasmalSubligar : ModItem {
        public override void SetStaticDefaults () {
            DisplayName.SetDefault("Phantasmal Subligar");
            Tooltip.SetDefault("5% increased magic damage" + "\n12% increased movement speed" + "\nIncreases maximum mana by 30");

            ArmorIDs.Legs.Sets.HidesBottomSkin [Item.legSlot] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
        }

        public override void SetDefaults () {
            int width = 22; int height = 18;
            Item.Size = new Vector2(width, height);

            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.Lime;

            Item.defense = 12;
        }

        public override void UpdateEquip (Player player) {
            player.moveSpeed += 0.12f;
            player.statManaMax2 += 30;

            player.GetDamage(DamageClass.Magic) += 0.05f;
        }

        public override void AddRecipes () {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedGreaves)
                .AddRecipeGroup(RecipeGroups.Titanium, 10)
                .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient<SoulofBlight>(10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}