using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplayDataChangedEvent : IEvent{}
public class PlayerScore : MonoBehaviour
{
  private Player player;
  private int value;
  void Awake()
  {
    player = GetComponent<Player>();
  }
  public int Get()
  {
    return value;
  }
  public void Reset()
  {
    value = 0;
    EventManager.Trigger<PlayerDisplayDataChangedEvent>(new PlayerDisplayDataChangedEvent());
  }
  public void Increase()
  {
    value++;
    EventManager.Trigger<PlayerDisplayDataChangedEvent>(new PlayerDisplayDataChangedEvent());
  }
}