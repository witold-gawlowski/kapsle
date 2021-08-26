using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Awake()
    {
        var pads = Gamepad.all;
        foreach (var pad in pads)
        {
            var newPlayerInput = Instantiate(playerPrefab).GetComponent<PlayerInput>();
            InputUser.PerformPairingWithDevice(pad, newPlayerInput.user);
            newPlayerInput.enabled = true;
        }
    }
}
