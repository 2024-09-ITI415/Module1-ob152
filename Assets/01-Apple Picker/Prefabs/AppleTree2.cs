using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    [Header("Set in Inspector")]

    public GameObject applePrefab;

    public float speed = 10;

    public float leftAndRightEdge = 20f;

    public float chanceToChangeDirections = 0.1f;

    public float secondBetweenAppleDrops = 1f;

    void Start() {
        Invoke ("DropApple", 2f);

    }

    void DropApple() {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke ("DropApple", secondBetweenAppleDrops);
    }


    void Update () {
        
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x <- leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        } else if (Random.value < chanceToChangeDirections) {
            speed *= -1;
        }
    }


    
}