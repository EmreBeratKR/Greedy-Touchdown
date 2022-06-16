﻿using UnityEngine;

namespace Chunk
{
    public class Chunk : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}