using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace DocterMain.Content.Projectiles
{
    public class LaevatainProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 7;
        }
        public override void SetDefaults()
        {
            Projectile.width = 84;
            Projectile.height = 94;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 35;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 35;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            LaevatainProjectile();
        }

        private void LaevatainProjectile()
        {
            Projectile.frameCounter++;

            if (Projectile.frameCounter < 5)
            {
                return;
            }
            Projectile.frame++;
            Projectile.frame %= 7;
            Projectile.frameCounter = 0;
        }
    }
}
