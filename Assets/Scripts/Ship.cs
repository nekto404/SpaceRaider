using System;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Ship
    {
        public int id;
        public int hp_points;
        public int damage;
        public int speed;
        public Sprite image;
    }
}