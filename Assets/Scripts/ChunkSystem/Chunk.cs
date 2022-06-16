﻿using UnityEngine;

namespace ChunkSystem
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