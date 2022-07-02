using UnityEngine;

namespace Assets.Scripts.Components
{
    public class CameraController : MonoBehaviour 
    {
        public float moveSpeed;
        public float scroll_wheel;
        public float horiz;
        public float vert;

        void Awake()
        {
            //camera.aspect = 1.6f;
            //Screen.SetResolution(Screen.width, (int)(Screen.width*0.3625f), true); //Maintain 16:9 apect ratio
        }

        void Update ()
        {
            scroll_wheel = Input.GetAxis ("Scroll Wheel"); 
            horiz = Input.GetAxis ("Horizontal");
            vert = Input.GetAxis ("Vertical");

            moveSpeed = 1f * transform.position.y;

            //Axis can have negative and positive values.
            //When a value other than zero is detected, the transform can be translated with the appropriate vector.
            //We multiply this vector by the moveSpeed, and Time.deltaTime creates a smooth transition
            //I use Space.World coordinates so the movement isn't based on camera rotation (camera starts at 45 degree down angle)

            if (horiz > 0f) transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            else if (horiz < 0f) transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

            if (vert > 0f) transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
            else if (vert < 0f) transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

            //I don't use moveSpeed here because moveSpeed is based on the camera height and scrolling adjusts camera height
            if (scroll_wheel > 0f) transform.Translate(Vector3.down * 10f * Time.deltaTime, Space.World);
            else if(scroll_wheel < 0f) transform.Translate(Vector3.up * 10f * Time.deltaTime, Space.World);
        }
    }
}
