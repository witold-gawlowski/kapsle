using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreScript : MonoBehaviour
{
  List<Finisher> players;
  public Text scoreText;
  public PlayerColor? GetFreeColor()
  {
    foreach (PlayerColor c in Enum.GetValues(typeof(PlayerColor)))
    {
      bool taken = false;
      foreach (Finisher f in players)
      {
        if (f.Color.Equals(c))
        {
          taken = true;
          break;
        }
      }
      if (!taken)
      {
        return c;
      }
    }
    return null;
  }
  public void SetupNewPlayerColor(Player player)
  {
    PlayerColor? freeColor = GetFreeColor();
    if (freeColor != null)
    {
      player.Color = (PlayerColor)freeColor;
    }
  }
  void UpdateScore(PlayerDisplayDataChangedEvent ev)
  {
    string newScoreText = "";
    foreach (Finisher f in players)
    {
      PlayerColor color = f.Color;
      newScoreText += Player.colorMap[color].displayName;
      newScoreText += " " + f.GetScore() + "\n";
    }
    scoreText.text = newScoreText;
  }
  void NewPlayerHandler(PlayerJoinedEvent ev)
  {
    Player player = ev.Player;
    players.Add(player);
    SetupNewPlayerColor(player);
    EventManager.Trigger(new PlayerDisplayDataChangedEvent());
  }
  void Awake()
  {
    EventManager.AddListener<PlayerJoinedEvent>(NewPlayerHandler);
    EventManager.AddListener<PlayerDisplayDataChangedEvent>(UpdateScore);
    players = new List<Finisher>();
  }
}
