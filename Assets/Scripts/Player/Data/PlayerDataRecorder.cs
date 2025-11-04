using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerDataRecorder : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Coroutine recordDataCoroutine = null;
    void Update()
    {
        if(recordDataCoroutine == null)
        {
            recordDataCoroutine = StartCoroutine(recordData());
        }
    }
    IEnumerator recordData()
    {
        Vector2 playerPosition = player.transform.position;
        RunStats.playerPosition.Add(playerPosition);
        RunStats.currentPlayerHeight = playerPosition.y;
        yield return new WaitForSeconds(1 / RunStats.updatesPerSecond);
        recordDataCoroutine = null;
        yield return null;

    }
}
