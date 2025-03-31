using Unity.VisualScripting;
using UnityEngine;

public class MountainColliders : MonoBehaviour
{
    public Collider2D[] Colliders;
    public Collider2D[] MountainBoundary;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            foreach (Collider2D mountain in Colliders)
            {
                mountain.enabled = false;

            }
            foreach (Collider2D boundary in MountainBoundary)
            {
                boundary.enabled = true;
            }

            player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 18;

        }
    }
}
