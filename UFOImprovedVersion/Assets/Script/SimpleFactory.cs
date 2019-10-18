using UnityEngine;
using Adapter;

namespace SimpleFactory
{
    #region 产品

    public interface UFO
    {
        GameObject Version(int round);
    }
    
    public class UFO1 : UFO
    {
        
        float x = Random.Range(0.0f, 5.0f);
        public virtual GameObject Version(int round)
        {
            GameObject UFO1;
            Vector3 UFO1Pos = new Vector3(x, 0, 0);
            UFO1 = Object.Instantiate(Resources.Load("UFO1", typeof(GameObject)), UFO1Pos, Quaternion.identity) as GameObject;
            UFO1.name = "UFO1";
            UFO1.AddComponent<PickupObject>();
            //UFO1.AddComponent<Rigidbody>();
            move1 test = UFO1.AddComponent<move1>();
            test.speedX *=  (float)round;
            test.speedY *=   (float)round;
            test.speedZ = 0.0f ;
            return UFO1;
        }
     
    }
    
    public class UFO2 : UFO
    {
        float x = Random.Range(0.0f, 5.0f);
        public virtual GameObject Version(int round)
        {
            GameObject UFO1;
            Vector3 UFO1Pos = new Vector3(x, 0, 0);
            UFO1 = Object.Instantiate(Resources.Load("UFO2", typeof(GameObject)), UFO1Pos, Quaternion.identity) as GameObject;
            UFO1.name = "UFO2";
            UFO1.AddComponent<PickupObject>();
            //UFO1.AddComponent<Rigidbody>();
            move1 test = UFO1.AddComponent<move1>();
            test.speedX *= (float)round;
            test.speedY *= (float)round;
            test.speedZ = 0.0f;
            return UFO1;
     
        }
        public virtual void Add_Component_Rigidbody(GameObject ufo)
        {
            ufo.AddComponent<Rigidbody>();
        }
    }

    public class UFO3 : UFO
    {
        float x = Random.Range(0.0f, 5.0f);
        public virtual GameObject Version(int round)
        {
            GameObject UFO1;
            Vector3 UFO1Pos = new Vector3(x, 0, 0);
            UFO1 = Object.Instantiate(Resources.Load("UFO3", typeof(GameObject)), UFO1Pos, Quaternion.identity) as GameObject;
            UFO1.name = "UFO3";
            UFO1.AddComponent<PickupObject>();
            //UFO1.AddComponent<Rigidbody>();
            move1 test = UFO1.AddComponent<move1>();
            test.speedX *= (float)round;
            test.speedY *=  (float)round;
            test.speedZ = 0.0f;
            return UFO1;

        }
    }

    public class UFO4 : UFO
    {
        float x = Random.Range(0.0f, 5.0f);
        public virtual GameObject Version(int round)
        {
            GameObject UFO1;
            Vector3 UFO1Pos = new Vector3(x, 0, 0);
            UFO1 = Object.Instantiate(Resources.Load("UFO4", typeof(GameObject)), UFO1Pos, Quaternion.identity) as GameObject;
            UFO1.name = "UFO4";
            UFO1.AddComponent<PickupObject>();
            //UFO1.AddComponent<Rigidbody>();
            move1 test = UFO1.AddComponent<move1>();
            test.speedX *= (float)round;
            test.speedY *= (float)round;
            test.speedZ = 0.0f;
            return UFO1;
     
        }
    }


    public class UFO5 : UFO
    {
        float x = Random.Range(0.0f, 5.0f);
        public virtual GameObject Version(int round)
        {
            GameObject UFO1;
            Vector3 UFO1Pos = new Vector3(x, 0, 0);
            UFO1 = Object.Instantiate(Resources.Load("UFO5", typeof(GameObject)), UFO1Pos, Quaternion.identity) as GameObject;
            UFO1.name = "UFO5";
            UFO1.AddComponent<PickupObject>();
            //UFO1.AddComponent<Rigidbody>();
            move1 test = UFO1.AddComponent<move1>();
            test.speedX *= (float)round;
            test.speedY *= (float)round;
            test.speedZ = 0.0f;
            return UFO1;

        }
    }
    #endregion

    #region 工厂
    public interface IFactory
    {
        UFO Create();
    }

    public class UFO1Factory : IFactory
    {
        public virtual UFO Create()
        {
            
            return new UFO1();
        }
    }

    public class UFO2Factory : IFactory
    {
        public virtual UFO Create()
        {
            return new UFO2();
        }
    }

    public class UFO3Factory : IFactory
    {
        public virtual UFO Create()
        {
            
            return new UFO3();
        }
    }

    public class UFO4Factory : IFactory
    {
        public virtual UFO Create()
        {
            return new UFO4();
        }
    }

    public class UFO5Factory : IFactory
    {
        public virtual UFO Create()
        {
            return new UFO5();
        }
    }

    #endregion
}