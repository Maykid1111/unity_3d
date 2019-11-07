using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHalo : MonoBehaviour {
    //定义一个粒子系统的变量，粒子的数组和对应的粒子的数据
    private ParticleSystem particleSys;                 //粒子系统
    private ParticleSystem.Particle[] particleArray;    //粒子数组
    private ParticleData[] particleData;                //粒子数据数组

    //声明变量
    public int count = 10000;       // 粒子数量  
    public float size = 0.03f;      // 粒子大小  
    public float minRadius = 5.0f;  // 最小半径  
    public float maxRadius = 12.0f; // 最大半径  
    public bool clockwise = true;   // 顺时针|逆时针  
    public float speed = 2f;        // 速度  
    public float pingPong = 0.02f;  // 游离范围
    private int diff = 100;          // 速度差分层数  

    //颜色，在Inspector窗口里改变colorGradient的值：
    public Gradient colorGradient;

    //实例化粒子系统和初始化各粒子的属性与位置
    private void Start()
    {
        //初始化粒子数组
        particleArray = new ParticleSystem.Particle[count];
        particleData = new ParticleData[count];

        //初始化粒子系统
        particleSys = this.GetComponent<ParticleSystem>();
        particleSys.startSpeed = 0;         //粒子初始速度
        particleSys.startSize = size;       //粒子大小
        particleSys.loop = false;
        particleSys.maxParticles = count;   //最大粒子数
        particleSys.Emit(count);            //发射粒子
        particleSys.GetParticles(particleArray);

        RandomlySpread();// 初始化各粒子位置 
    }

    void RandomlySpread()
    {
        float midRadius, minRate, maxRate, radius,angle,theta,time;

        //初始化粒子位置；
        for (int i = 0; i < count; i++)
        {
            // 随机每个粒子距离中心的半径，同时希望粒子集中在平均半径附近 
            midRadius = (maxRadius + minRadius) / 2;
            minRate = Random.Range(1.0f, midRadius / minRadius);
            maxRate = Random.Range(midRadius / maxRadius, 1.0f);
            radius = Random.Range(minRadius * minRate, maxRadius * maxRate);

            // 随机每个粒子的角度  
            angle = Random.Range(0.0f, 360.0f);
            theta = angle / 180 * Mathf.PI;

            // 随机每个粒子的游离起始时间
            time = Random.Range(0.0f, 360.0f);
     
            particleData[i] = new ParticleData(radius,angle,time);
        
           particleArray[i].position = new Vector3(particleData[i].radius * Mathf.Cos(theta), particleData[i].radius * Mathf.Sin(theta),0f);
        }
        particleSys.SetParticles(particleArray, particleArray.Length);
    }

    //旋转
    private void Update()
    {
        float theta;
        for (int i = 0; i < count; i++)
        {
            if (clockwise)//顺时针旋转
                particleData[i].angle -= (i % diff + 1) * (speed / particleData[i].radius / diff); 
            else//逆时针旋转
                particleData[i].angle += (i % diff + 1) * (speed / particleData[i].radius / diff);
            
            // 保证angle在到360度
            particleData[i].angle = (360.0f + particleData[i].angle) % 360.0f;
            theta = particleData[i].angle / 180 * Mathf.PI;

            //跳动效果
            particleData[i].time += Time.deltaTime;
            particleData[i].radius += Mathf.PingPong(particleData[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;
            particleArray[i].position = new Vector3(particleData[i].radius * Mathf.Cos(theta), particleData[i].radius * Mathf.Sin(theta), 0f);
        }

        //调用改变颜色的函数
        changeColor();
        particleSys.SetParticles(particleArray, particleArray.Length);
    }

    //改变颜色的函数
    void changeColor()
    {
        float colorValue;
        for (int i = 0; i < count; i++)
        {
            //改变颜色
            colorValue = (Time.realtimeSinceStartup - Mathf.Floor(Time.realtimeSinceStartup));
            colorValue += particleData[i].angle/360;
            while (colorValue > 1)
                colorValue--;
            particleArray[i].color = colorGradient.Evaluate(colorValue);
            //particleArray[i].color = colorGradient.Evaluate(Random.value);
        }
    }
}


//记录每个粒子的属性：
public class ParticleData
{
    public float radius, angle, time;
    public ParticleData(float radius_,float angle_,float time_)
    {
        radius = radius_;   //半径
        angle = angle_;     //角度
        time = time_;       //运动的时间
    }
}
