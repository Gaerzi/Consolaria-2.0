using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Consolaria.Content.Items.Armor.Misc
{
    [AutoloadEquip(EquipType.Body)]
    public class OstaraJacket : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Jacket of Ostara");
            Tooltip.SetDefault("5% increased movement speed");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() {
            int width = 30; int height = 20;
            Item.Size = new Vector2(width, height);

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;

            Item.defense = 5;
        }

        public override void UpdateEquip(Player player) 
            => player.moveSpeed += 0.05f;
    }
}
