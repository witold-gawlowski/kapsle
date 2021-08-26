using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Finisher player = collision.GetComponent<Player>();
        float finishTime = player.GetTimeSinceLastCrossedFinish();
        player.HandleFinishLineCrossed(this, finishTime);
    }
}
