using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SceneController
{
    void load();
    void game(int Round);
    int Choose(float[] probe);
}