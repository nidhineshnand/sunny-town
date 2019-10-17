﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyTown
{
    public class AcidRainer : WeatherEvent
    {
        [SerializeField]
        private ParticleSystem rain;

        void Start()
        {
            rain.Stop();
        }

        public void PlayAnim()
        {
            rain.Stop();
            Debug.Log("start plaing rain");
        }
    }
}