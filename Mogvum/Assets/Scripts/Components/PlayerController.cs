using System;
using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Debug.Log("Player controller initialized start function.");
            Debug.LogError("Character's PrimaryTypes already contains " + Enum.GetName(typeof(PrimaryType), 2) + ".");
            Debug.Log("Player controller has finished start function.");
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }
}
