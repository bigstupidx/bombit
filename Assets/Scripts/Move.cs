using UnityEngine;

public class Move : MonoBehaviour {

    public Transform player;
    private bool faceRight = true;
    [SerializeField] private float speed = 30f;
    public GameObject players;

    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2f ? 2f : mousePos.x;
            mousePos.x = mousePos.x < -2f ? -2f : mousePos.x;
            player.position = Vector2.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.deltaTime);


            if (mousePos.x > 0 && !faceRight)
                flip();
            else if (mousePos.x < 0 && faceRight)
                flip();
        }
    }
    void flip() {
        faceRight = !faceRight;
    //НЕРАБОТАЕТ    players.GetComponent<Transform>().localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
       players.GetComponent<Transform>().Rotate(Vector3.up * 180);
    }
}
