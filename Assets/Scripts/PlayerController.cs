using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce = 10f; // Force applied for jumping
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioClip coinSound;
    public AudioClip winSound;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isGrounded; // Flag to track if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply vertical force for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Set to false to prevent multiple jumps
        }

        // Get movement input
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the player is grounded
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }
}
