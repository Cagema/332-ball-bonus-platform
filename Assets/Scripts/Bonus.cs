using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void Start()
    {
        SetNewPos();
    }

    public void SetNewPos()
    {
        transform.position = new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x, GameManager.Single.RightUpperCorner.x),
            Random.Range(-3.5f, 1f), transform.position.z);
    }
}
