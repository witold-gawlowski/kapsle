using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StartingPosition
{
  public GameObject marker;
  public bool free;
  public StartingPosition(GameObject marker, bool isFree = true)
  {
    this.marker = marker;
    this.free = isFree;
  }
}
public class StartingPositionsScript : MonoBehaviour
{
  public List<StartingPosition> positions = new List<StartingPosition>();
  void Awake()
  {
    EventManager.AddListener<PlayerJoinedEvent>(HandleNewPlayerConnect);
    foreach (Transform t in transform)
    {
      if (t != transform)
      {
        positions.Add(new StartingPosition(t.gameObject, true));
      }
    }
  }
  public void HandleNewPlayerConnect(PlayerJoinedEvent ev)
  {
    Player player = ev.Player;
    Vector3? freePosition = TakeFree();
    if (freePosition != null)
    {
      Debug.Log("free position" + freePosition);
      player.transform.position = (Vector3)freePosition;
      return;
    }
    throw new System.Exception("Missing free positions!");
  }
  public Vector2? TakeFree()
  {
    foreach (StartingPosition sp in positions)
    {
      if (sp.free)
      {
        sp.free = false;
        return sp.marker.transform.position;
      }
    }
    return null;
  }
  public void FreeAll()
  {
    foreach (StartingPosition sp in positions)
    {
      sp.free = true;
    }
  }
}
