using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.collider.name)
        {
            case "Option1":
                Debug.Log("Touching Option1");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;
           
            case "Option2":
                Debug.Log("Touching Option1");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;
           
            case "Option3":
                Debug.Log("Touching Option1");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;

            default:
                Debug.Log("Not touching an option");
                break;
        }
       
    }
}
