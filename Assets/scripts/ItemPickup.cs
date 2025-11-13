using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        QuickExplosion,
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch(type)
        {
            case ItemType.ExtraBomb:
            player.GetComponent<BombController>().AddBomb();
            break;
            
            case ItemType.BlastRadius:
            player.GetComponent<BombController>().explosionRadius++;
            break;
            
            case ItemType.SpeedIncrease:
            player.GetComponent<MovementController>().speed++;
            break;

            case ItemType.QuickExplosion:
            player.GetComponent<BombController>().bombFuseTime -= 0.35f;
            break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
    {
        OnItemPickup(other.gameObject);
    }
    }

}
