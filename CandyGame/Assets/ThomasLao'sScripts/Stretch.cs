using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretch : MonoBehaviour
{
    public float wait;
    [SerializeField] private List<Vector2> points = new List<Vector2>();
    public float distanceOffset;
    public float moveSpeed;
    public float initWait;
    public int index = 0;
    void upanddown()
    {
        if (points.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[index], moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[index]) < distanceOffset)
            {
                if (wait <= 0)
                {
                    Flip();
                    index = (index + 1) % points.Count;
                    wait = initWait;
                }
                else
                {
                    wait -= Time.deltaTime;
                }
            }
        }
    }
    void Flip()
    {
        transform.Rotate(-180f, 0f, 0f);
    }
}
