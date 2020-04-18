﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public sealed class AIVision
    {
        public float ActiveDis = 4;
        public float ActiveAng = 35;

        public bool VisionM(Transform player, Transform target)
        {
            return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);
        }

        private bool CheckBloked(Transform player, Transform target)
        {
            Vector2 target2d = target.position;
            Vector2 player2d = player.position;

            var hit2d = Physics2D.Linecast(target2d, player2d, 3);

            if (hit2d.transform != null) return true;
            return false;
        }

        private bool Angle(Transform player, Transform target)
        {
            Vector2 target2d = target.position;
            Vector2 player2d = player.position;

            var angle = Vector2.Angle(target.up, player2d - target2d);

            return angle <= ActiveAng;
        }

        private bool Dist(Transform player, Transform target)
        {
            Vector2 target2d = target.position;
            Vector2 player2d = player.position;

            Vector2 offset = player2d - target2d;

            float sqrLen = offset.sqrMagnitude;

            return sqrLen <= ActiveDis * ActiveDis;
        }
    }
}
