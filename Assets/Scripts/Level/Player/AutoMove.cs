using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    private Vector2 pos;

    private void Update()
    {
        pos = transform.position;
        pos.x += this.GetComponent<Movement>().speed * Time.deltaTime;
        transform.position = pos;
    }
}
