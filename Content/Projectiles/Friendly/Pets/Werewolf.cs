using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Consolaria.Content.Projectiles.Friendly.Pets {
    public class Werewolf : ConsolariaPet {
        public override int maxFrames => 20;

        public override void SetDefaults () {
            int width = 30; int height = 52;
            Projectile.Size = new Vector2(width, height);

            DrawOffsetX -= 10;

            base.SetDefaults();
        }

        public override void AI () {
            Player player = Main.player [Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<Buffs.Werewolf>()))
                Projectile.timeLeft = 2;

            WalkerAI();
            PassiveAnimation(idleFrame: 0, jumpFrame: 1);
            WalkingAnimation(walkingAnimationSpeed: 2, walkingFirstFrame: 2, walkingLastFrame: 15);
            int finalFrame = maxFrames - 1;
            FlyingAnimation(flyingAnimationSpeed: 4, flyingFirstFrame: 16, finalFrame);

            double rotation = (Math.PI / 2) * player.velocity.X * 0.08f;
            if (isFlying)
            Projectile.rotation = (float) rotation;
        }
    }
}