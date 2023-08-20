using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tanks
{
    public static class Extensions 
    {
        private static Dictionary<DirectionTye, Vector3> _directions; 
        private static Dictionary<DirectionTye, Vector3> _rotations;

        static Extensions()
        {
            _directions = new Dictionary<DirectionTye, Vector3>
            {
                { DirectionTye.Up, new Vector3 (0f, 1f, 0f) },
                { DirectionTye.Right, new Vector3 (1f, 0f, 0f) },
                { DirectionTye.Down, new Vector3 (0f, -1f, 0f) },
                { DirectionTye.Left, new Vector3 (-1f, 0f, 0f) },
            };

            _rotations = new Dictionary<DirectionTye, Vector3>
            {
                { DirectionTye.Up, new Vector3 (0f, 0f, 0f) },
                { DirectionTye.Right, new Vector3 (0f, 0f, 270f) },
                { DirectionTye.Down, new Vector3 (0f, 0f, 180f) },
                { DirectionTye.Left, new Vector3 (0f, 0f, 90f) },
            };
        }

        public static Vector3 ConvertTypeFromDirection(this DirectionTye type)
            => _directions[type];
        public static DirectionTye ConvertDirectionFromType(this Vector3 direction)
            => _directions.First(t => t.Value == direction).Key;
        public static DirectionTye ConvertDirectionFromType(this Vector2 direction)
        {
            var dir = (Vector3)direction;
            return _directions.First(t => t.Value == dir).Key;
        }
            
        public static Vector3 ConvertTypeFromRotation(this DirectionTye type)
            => _rotations[type];
        public static DirectionTye ConvertRotationFromType(this Vector3 rotations)
            => _rotations.First(t => t.Value == rotations).Key;

    }

    public enum DirectionTye : byte
    {
        Error, Up, Right, Down, Left
    }

    public enum SideType : byte
    {
        None, Player, Enemy
    }
}