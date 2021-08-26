using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
[System.Serializable]
public enum PlayerColor
{
  red, green, blue, yellow, magenta
}
public struct ColorData
{
  public Color color;
  public string displayName;
  public ColorData(Color color, string displayName)
  {
    this.color = color;
    this.displayName = displayName;
  }
}
public interface Finisher
{
  public void HandleFinishLineCrossed(MetaScript meta, float timeSinceLastCrossedFinish);
  public float GetTimeSinceLastCrossedFinish();
  public int GetScore();
  public PlayerColor Color { get; set; }
}
public class Player : MonoBehaviour, Finisher
{
  static public Dictionary<PlayerColor, ColorData> colorMap = new Dictionary<PlayerColor, ColorData>(){
  {PlayerColor.blue, new ColorData(UnityEngine.Color.blue, "Blue")},
  {PlayerColor.green, new ColorData(UnityEngine.Color.green, "Green")},
  {PlayerColor.magenta, new ColorData(UnityEngine.Color.magenta, "Magenta")},
  {PlayerColor.red, new ColorData(UnityEngine.Color.red, "Red")},
  {PlayerColor.yellow, new ColorData(UnityEngine.Color.yellow, "Yellow")},
};
  private SpriteRenderer spriteRenderer;
  private Rigidbody2D rb;
  private Vector2 movementValue;
  public float impulse = 10;
  public float chargingSpeed = 1.3f;
  private float holdCunter;
  private bool isfillipDown = false;
  private Vector3 startPosition;
  private bool isTraveling;
  private Action movementEded;
  private float timeSinceLastCrossedFinish;
  private PlayerScore score;
  public Action<MetaScript, float> finishLineCrossed;
  private PlayerColor _color;
  public float stopSpeedThreshold;
  public PlayerColor Color
  {
    get
    {
      return _color;
    }
    set
    {
      _color = value;
      spriteRenderer.color = colorMap[_color].color;
    }
  }
  public int GetScore()
  {
    return score.Get();
  }
  public void Init()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    score = GetComponent<PlayerScore>();
    rb = GetComponent<Rigidbody2D>();
    movementEded += handlePlayerOutOfTrack;
    finishLineCrossed += HandleFinishLineCrossed;
    score.Reset();
  }
  public void HandleFinishLineCrossed(MetaScript meta, float timeSinceLastCrossedFinish)
  {
    ResetTimeSinceLastCrossedFinish();
    if (timeSinceLastCrossedFinish > 5)
    {
      score.Increase();
    }
  }
  public float GetTimeSinceLastCrossedFinish()
  {
    return timeSinceLastCrossedFinish;
  }
  private void ResetTimeSinceLastCrossedFinish()
  {
    timeSinceLastCrossedFinish = 0;
  }

  private void OnMovement(InputValue value)
  {
    movementValue = value.Get<Vector2>();
  }
  private void OnFillipDown()
  {
    if(!isTraveling){
      isfillipDown = true;
      holdCunter = 1;
    }
  }

  private void OnFillipUp()
  {
    if(!isTraveling){
      rb.AddForce(chargingSpeed * movementValue * impulse * holdCunter, ForceMode2D.Impulse);
      isfillipDown = false;
      startPosition = transform.position;
      isTraveling = true;
    }
  }


  private void handlePlayerOutOfTrack()
  {
    var track = Physics2D.OverlapPoint(transform.position);
    if (!track)
    {
      transform.position = startPosition;
    }

  }
  private void FixedUpdate()
  {
    timeSinceLastCrossedFinish += Time.deltaTime;
    if (isfillipDown)
    {
      holdCunter += Time.deltaTime;
    }

    if (isTraveling && rb.velocity.magnitude < stopSpeedThreshold)
    {
      isTraveling = false;
      movementEded();
    }
  }
}
