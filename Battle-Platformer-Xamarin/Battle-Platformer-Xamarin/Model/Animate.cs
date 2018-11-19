using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using Urho.Resources;
using Urho.Urho2D;

namespace Royale_Platformer.Model
{
    class Animate : GameApp
    {
        public Animate(ApplicationOptions options) : base(options)
        {
        }

        public static void UpdateAnimation(RigidBody2D body)
        {
            if (body.LinearVelocity.X > 0)
            {
                //Sprite2D PlayerSprite = ResourceCache.GetSprite2D("characters/special forces/png1/attack/1_Special_forces_attack_Attack_000.png");
            }
        }
    }
}
