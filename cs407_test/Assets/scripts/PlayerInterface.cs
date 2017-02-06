using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace System.Collections
{
    public interface PlayerInterface
    {
        // Use this for initialization
        void Start();
        // Update is called once per frame
        void Update();
        //use this for any forces
        void LateUpdate();
        //get speed of object
        float getSpeed();
    }
}
