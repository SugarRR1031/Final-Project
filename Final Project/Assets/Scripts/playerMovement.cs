using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 myLook;

    public gameManager GM;

    public float speed = 0.5f;
    public float lookSpeed = 5f;
    //public int score = 0;

    public GameObject myCam;
    public float camLock = 90;


    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myLook = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }

        Vector3 playerLook = myCam.transform.TransformDirection(Vector3.forward);
        myLook += DeltaLook() * Time.deltaTime;

        if (myLook.y > camLock)
        {
            myLook.y = camLock;
        }
        else if (myLook.y < -camLock)
        {
            myLook.y = -camLock;

        }

        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);



    }

    private void FixedUpdate()
    {
        Vector3 myDir = transform.TransformDirection(Dir());
        rb.AddForce(myDir * speed);
    }

    Vector3 Dir()
    {
        Vector3 moveDir = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(x, 0, z);
        return moveDir;

    }

    Vector3 DeltaLook()
    {
        Vector3 deltaLook = Vector3.zero;
        Vector3 moveDir = Vector3.zero;
        float rotY = Input.GetAxisRaw("Mouse Y") * lookSpeed;
        float rotX = Input.GetAxisRaw("Mouse X") * lookSpeed;

        deltaLook = new Vector3(rotX, rotY, 0);
        return DeltaLook();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            gameManager.Instance.Score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.Instance.Score--;
            //Destroy(gameObject);
            //SceneManagement.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
