using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    sealed class AIVision
    {
        public float ActiveDis = 10;
        public float ActiveAng = 35;

        public bool VisionM(Transform player, Transform target)
        {
            return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);
        }

        private bool CheckBloked(Transform player, Transform target)
        {
            var hit2d = Physics2D.Linecast(player.position, target.position);

            if (hit2d.transform == null) return true;
            return hit2d.transform != target;
        }

        private bool Angle(Transform player, Transform target)
        {
            var angle = Vector3.Angle(player.forward, target.position - player.position);
            return angle <= ActiveAng;
        }

        private bool Dist(Transform player, Transform target)
        {
            //var dist = Vector3.Distance(player.position, target.position); //todo оптимизация
            Vector3 offset = target.position - player.position;
            float sqrLen = offset.sqrMagnitude;
            return sqrLen <= ActiveDis * ActiveDis;
        }
    }
}
