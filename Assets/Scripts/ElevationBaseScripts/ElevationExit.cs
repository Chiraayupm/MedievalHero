using UnityEngine;

public class ElevationExit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Collider2D[] MountainColliders;
    public Collider2D[] MountainBoundary;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            foreach (Collider2D mountain in MountainColliders)
            {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in MountainBoundary)
            {
                boundary.enabled = false;
            }

            player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}
