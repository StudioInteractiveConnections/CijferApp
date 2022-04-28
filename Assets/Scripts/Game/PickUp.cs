using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.collider.name)
        {
            case "Option1":
                GameObject.Find("Option2").SetActive(false);
                GameObject.Find("Option3").SetActive(false);
                GameObject.Find("Option4").SetActive(false);
                Debug.Log("Picked up option 1");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;
           
            case "Option2":
                GameObject.Find("Option1").SetActive(false);
                GameObject.Find("Option3").SetActive(false);
                GameObject.Find("Option4").SetActive(false);
                Debug.Log("Picked up option 2");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;
           
            case "Option3":
                GameObject.Find("Option1").SetActive(false);
                GameObject.Find("Option2").SetActive(false);
                GameObject.Find("Option4").SetActive(false);
                Debug.Log("Picked up option 3");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;

            case "Option4":
                GameObject.Find("Option1").SetActive(false);
                GameObject.Find("Option2").SetActive(false);
                GameObject.Find("Option3").SetActive(false);
                Debug.Log("Picked up option 4");
                other.transform.SetParent(player.transform);
                other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
                break;

            default:
                Debug.Log("Not touching an option");
                break;
        }
       
    }
}
