using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.collider.name)
        {
            case "Option1":
                Destroy(GameObject.Find("Option2"));
                Destroy(GameObject.Find("Option3"));
                Debug.Log("Picked up option 1");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                break;
           
            case "Option2":
                Destroy(GameObject.Find("Option1"));
                Destroy(GameObject.Find("Option3"));
                Debug.Log("Picked up option 2");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                break;
           
            case "Option3":
                Destroy(GameObject.Find("Option1"));
                Destroy(GameObject.Find("Option2"));
                Debug.Log("Picked up option 3");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                break;

            default:
                Debug.Log("Not touching an option");
                break;
        }
       
    }
}
