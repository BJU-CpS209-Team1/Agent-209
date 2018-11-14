﻿using System;
using System.Collections.Generic;
using System.Text;
using Urho;
using Urho.Urho2D;

namespace Battle_Platformer_Xamarin.Model
{
    public class MapTile : WorldObject
    {
        public MapTile(Scene scene, Sprite2D sprite, Vector2 pos)
        {
            WorldNode = scene.CreateChild();
            WorldNode.Position = new Vector3(pos);

            StaticSprite2D nodeSprite = WorldNode.CreateComponent<StaticSprite2D>();
            nodeSprite.Sprite = sprite;

            WorldHitbox = new Hitbox();
            WorldHitbox.Size = new Vector2(1, 1);
        }
    }
}