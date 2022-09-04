using Consolaria.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Consolaria.Content.Items.Armor.Summon {
    [AutoloadEquip(EquipType.Head)]
    public class WarlockHood : ModItem {
        public override void SetStaticDefaults () {
            DisplayName.SetDefault("Warlock Hood");
            Tooltip.SetDefault("Increases your max number of minions by 1" + "\n20% increased minion damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId [Type] = 1;
        }

        public override void SetDefaults () {
            int width = 30; int height = 26;
            Item.Size = new Vector2(width, height);

            Item.value = Item.sellPrice(gold: 6, silver: 40);
            Item.rare = ItemRarityID.Lime;

            Item.defense = 6;
        }

        public override void UpdateEquip (Player player) {
            player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.2f;
        }

        public override bool IsArmorSet (Item head, Item body, Item legs)
           => (body.type == ModContent.ItemType<WarlockRobe>() || body.type == ModContent.ItemType<AncientWarlockRobe>())
           && (legs.type == ModContent.ItemType<WarlockLeggings>() || legs.type == ModContent.ItemType<AncientWarlockLeggings>());

        public override void ArmorSetShadows (Player player)
            => player.armorEffectDrawShadow = true;

        public override void UpdateArmorSet (Player player) {
            player.setBonus = "Enemies killed by minions heal the player";
            player.GetModPlayer<WarlockPlayer>().necroHealing = true;
        }

        public override void AddRecipes () {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedHood)
                .AddRecipeGroup(RecipeGroups.Titanium, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient<SoulofBlight>(10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }

    internal class WarlockPlayer : ModPlayer {
        public bool necroHealing;
        private int healingTimer;
        private readonly int healingTimerLimit = 180;

        public override void Initialize ()
            => healingTimer = healingTimerLimit;

        public override void ResetEffects ()
            => necroHealing = false;

        public override void PostUpdateEquips () {
            if (!necroHealing) return;
            if (healingTimer > 0)
                healingTimer--;
        }

        public override void OnHitNPCWithProj (Projectile proj, NPC target, int damage, float knockback, bool crit) {
            if (target.type == NPCID.TargetDummy || Player.moonLeech || !necroHealing)
                return;

            if (healingTimer == 0 && target.life <= 0 &&
                (proj.minion || proj.DamageType == DamageClass.Summon)) {
                int helLife = Player.statLifeMax / 20;
                if (Main.netMode != NetmodeID.Server) {
                    float _dustCountMax = 45;
                    int _dustCount = 0;
                    while (_dustCount < _dustCountMax) {
                        Vector2 vector = Vector2.UnitX * 0f;
                        vector += -Vector2.UnitY.RotatedBy(_dustCount * (7f / _dustCountMax), default) * new Vector2(26f, 26f);
                        vector = vector.RotatedBy(proj.velocity.ToRotation(), default);
                        int _dust = Dust.NewDust(proj.Center, 0, 0, DustID.Shadowflame, 0f, 0f, 100, Color.DarkViolet, 1.3f);
                        Main.dust [_dust].noGravity = true;
                        Main.dust [_dust].position = proj.Center + vector;
                        Main.dust [_dust].velocity = proj.velocity * 0f + vector.SafeNormalize(Vector2.UnitY) * 0.75f;
                        int _dustCountMax2 = _dustCount;
                        _dustCount = _dustCountMax2 + 1;
                    }
                }
                SoundEngine.PlaySound(SoundID.NPCDeath55, proj.Center);
                Player.statLife += helLife;
                Player.HealEffect(helLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, proj.owner, helLife);
                healingTimer = healingTimerLimit;
            }
        }
    }
}