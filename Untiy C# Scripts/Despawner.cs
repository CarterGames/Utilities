using System.Collections;
using UnityEngine;

/*
*  Carter Games Utilities Script
*  Copyright (c) Carter Games
*  W: https://carter.games
*  
*  Written by:
*  Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games
*/

namespace CarterGames.Utilities
{
    public class Despawner : MonoBehaviour
    {
        private enum DespawnerChoices { Disable, Destroy };

        [Header("Despawn Delay")]
        [Tooltip("Set this to define how long the object will wait before despawning. Default Value = 1")]
        [SerializeField] private float despawnTime = 1f;

        [Header("Despawn Choice")]
        [Tooltip("Pick an option for what happens when the despawn timer runer out.")]
        [SerializeField] private DespawnerChoices choices;


        /// <summary>
        /// When the object is enabled, start the corutine that will despawn the object.
        /// </summary>
        private void OnEnable()
        {
            StartCoroutine(DespawnCo());
        }

        /// <summary>
        /// When the object is disabled, stop all corutines so it doesn't run more than it needs to.
        /// </summary>
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        /// <summary>
        /// Despawns the object this is attached to as and when it is enabled.
        /// </summary>
        private IEnumerator DespawnCo()
        {
            yield return new WaitForSeconds(despawnTime);

            switch (choices)
            {
                case DespawnerChoices.Disable:
                    gameObject.SetActive(false);
                    break;
                case DespawnerChoices.Destroy:
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}