using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

public GameObject thePlatform;
public Transform generationPoint;
public float distanceBetween;

private float platformHeight;

void Start () {
    platformHeight = thePlatform.GetComponent<BoxCollider2D>().size.y;
}

void Update () {
    if(transform.position.y < generationPoint.position.y);
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + platformHeight + distanceBetween, transform.position.z);

        Instantiate (thePlatform, transform.position, transform.rotation);
    }
}
}
