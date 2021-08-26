using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct PlayerJoinedEvent : IEvent
{
  public Player Player{get; set;}
  public PlayerJoinedEvent(Player player) => this.Player = player;
}

public class PlayerManager : MonoBehaviour
{
  public PlayerInputManager playerInputManager;
  void TriggerNewPlayerJoined(PlayerInput playerInput)
  {
    Player newPlayer = playerInput.GetComponent<Player>();
    newPlayer.Init();
    EventManager.Trigger(new PlayerJoinedEvent(newPlayer));
  }
  void Awake()
  {
    playerInputManager = GetComponent<PlayerInputManager>();
    playerInputManager.onPlayerJoined += TriggerNewPlayerJoined;
  }
}
