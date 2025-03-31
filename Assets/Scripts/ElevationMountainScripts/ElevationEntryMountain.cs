using UnityEngine;

public class ElevationEntry : MonoBehaviour
{
    public Collider2D[] MountainColliders;
    public Collider2D[] MountainBoundary;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            foreach (Collider2D mountain in MountainColliders)
            {
                mountain.enabled = false;
            }
            foreach (Collider2D boundary in MountainBoundary)
            {
                boundary.enabled = true;
            }

            player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 28;

        }
    }
}
