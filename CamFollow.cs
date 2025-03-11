using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Player player;

    void Update()
    {
        transform.Translate(Vector2.right * player.speed * Time.deltaTime);
    }
}
