using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damage =3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        collision.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
    //when player collides with spikes, plater instantly dies
}
