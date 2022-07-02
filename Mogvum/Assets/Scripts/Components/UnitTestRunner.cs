using UnityEngine;
using Assets.Scripts.Testing;

namespace Assets.Scripts.Components
{
    class UnitTestRunner : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Starting Tests");

            //Test.GamePersistence();
            Test.GenerateNames();

            Debug.Log("Finished tests");
        }
    }
}
