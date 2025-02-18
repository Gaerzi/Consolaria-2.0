using Consolaria.Content.Items.BossDrops.Lepus;
using Consolaria.Content.Items.BossDrops.Ocram;
using Consolaria.Content.Items.BossDrops.Turkor;
using Consolaria.Content.Items.Summons;
using Consolaria.Content.NPCs.Bosses.Lepus;
using Consolaria.Content.NPCs.Bosses.Ocram;
using Consolaria.Content.NPCs.Bosses.Turkor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Consolaria.Common {
    public class CrossContentIntegration : ModSystem {
        public override void PostSetupContent () {
            if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist)) {

                if (bossChecklist.Version < new Version(1, 3, 1)) {
                    return;
                }
                bossChecklist.Call(
                    "AddBoss",
                    Mod,
                    "Lepus",
                    ModContent.NPCType<Lepus>(),
                    1.8f,
                    () => DownedBossSystem.downedLepus,
                    () => true,
                    new List<int> {
                    ModContent.ItemType<LepusMask>(),
                    ModContent.ItemType<LepusTrophy>(),
                    ModContent.ItemType<LepusMusicBox>(),
                    ModContent.ItemType<LepusRelic>(),
                    ModContent.ItemType<RabbitFoot>()
                    },
                    ModContent.ItemType<SuspiciousLookingEgg>(),
                    $"Use a [i:" + ModContent.ItemType<SuspiciousLookingEgg>() + "] at day time",
                    "Lepus jumps away into sunset!"
                );
                bossChecklist.Call(
                   "AddBoss",
                   Mod,
                   "Turkor The Ungrateful",
                   ModContent.NPCType<TurkortheUngrateful>(),
                   5.75f,
                   () => DownedBossSystem.downedTurkor,
                   () => true,
                   new List<int> {
                    ModContent.ItemType<TurkorMask>(),
                    ModContent.ItemType<TurkorTrophy>(),
                    ModContent.ItemType<TurkorMusicBox>(),
                    ModContent.ItemType<TurkorRelic>(),
                    ModContent.ItemType<FruitfulPlate>()
                   },
                   ModContent.ItemType<CursedStuffing>(),
                   $"Use a [i:" + ModContent.ItemType<CursedStuffing>() + "] after summoning a pet turkey",
                   "Turkor the Ungrateful escapes from the dinner plate!",
                   (SpriteBatch spriteBatch, Rectangle rect, Color color) => {
                       Texture2D texture = ModContent.Request<Texture2D>("Consolaria/Assets/Textures/Bestiary/Turkor_Bestiary").Value;
                       Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                       spriteBatch.Draw(texture, centered, color);
                   },
                   "Consolaria/Content/NPCs/Bosses/Turkor/TurkortheUngratefulHead_Head_Boss"
                );
                bossChecklist.Call(
                  "AddBoss",
                  Mod,
                  "Ocram",
                  ModContent.NPCType<Ocram>(),
                  12f,
                  () => DownedBossSystem.downedOcram,
                  () => true,
                  new List<int> {
                    ModContent.ItemType<OcramMask>(),
                    ModContent.ItemType<OcramTrophy>(),
                    ModContent.ItemType<OcramMusicBox>(),
                    ModContent.ItemType<OcramRelic>(),
                    ModContent.ItemType<CursedFang>()
                  },
                  ModContent.ItemType<SuspiciousLookingSkull>(),
                  $"Use a [i:" + ModContent.ItemType<SuspiciousLookingSkull>() + "] at night",
                  "Ocram disappears back into shadows!",
                  (SpriteBatch spriteBatch, Rectangle rect, Color color) => {
                      Texture2D texture = ModContent.Request<Texture2D>("Consolaria/Assets/Textures/Bestiary/Ocram_Bestiary").Value;
                      Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
                      spriteBatch.Draw(texture, centered, color);
                  }
                );
            }

            if (ModLoader.TryGetMod("Fargowiltas", out Mod fargos)) {
                fargos.Call("AddSummon", 1.8f, "Consolaria", "SuspiciousLookingEgg", () => DownedBossSystem.downedLepus, 60000);
                fargos.Call("AddSummon", 5.75f, "Consolaria", "CursedStuffing", () => DownedBossSystem.downedLepus, 180000);
                fargos.Call("AddSummon", 12f, "Consolaria", "SuspiciousLookingSkull", () => DownedBossSystem.downedLepus, 500000);
            }
        }
    }
}