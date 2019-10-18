using UnityEngine;
using System.Collections;
using SimpleFactory;

namespace Adapter
{
    public class adapter
    {
        public void Add_Component_Rigidbody(SimpleFactory.UFO ufo,int i)
        {
            ufo.Version(i).AddComponent<Rigidbody>();

        }
    }
}
