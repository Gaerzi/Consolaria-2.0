using Consolaria.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Content.Items.Consumables
{
    public class Wishbone : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wishbone");
            Tooltip.SetDefault("Enables all small seasonal events for one day");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
        }

        public override void SetDefaults() {
            int width = 30; int height = 22;
            Item.Size = new Vector2(width, height);

            Item.maxStack = 20;
            Item.UseSound = SoundID.NPCHit2;

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Orange;

            Item.useAnimation = 18;
            Item.useTime = 18;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem (Player player)
            => !SeasonalEvents.allEventsForToday;

        public override bool? UseItem (Player player) {
            if (player.whoAmI == Main.myPlayer) {
                SeasonalEvents.allEventsForToday = true;
                Main.NewText("Events has started!", Color.HotPink);
            }
            return true;
        }
    }
}