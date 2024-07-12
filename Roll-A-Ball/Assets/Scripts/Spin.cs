using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
  {
  transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
  //Time.delta will make something frame independent
  }
}
