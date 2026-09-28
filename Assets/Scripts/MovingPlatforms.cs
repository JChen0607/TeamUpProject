using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed = 2f; 
    public int startPoint;
    public Transform[] points; 

    private int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = points[startPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i >= points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}