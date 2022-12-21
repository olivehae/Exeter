using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;

  void Start()
  {
    // Set the camera's transform to be a child of the player's transform
    Camera.main.transform.SetParent(player.transform);
  }
}