using System;
using System.Collections.Generic;
using UnityEngine;

public class CCSequeneActions : SSAction, ISSActionCallback {
    public List<SSAction> actionList;
    public int Times = -1;         
    public int Imdex = 0;        

    public static CCSequeneActions CreateSSAction(List<SSAction> _actionList, int _Times = 0) {
        CCSequeneActions action = ScriptableObject.CreateInstance<CCSequeneActions>();
        action.Times = _Times;
        action.actionList = _actionList;
        return action;
    }

    public override void Start() {
        foreach (SSAction action in actionList) {
            action.gameObject = this.gameObject;
            action.transform = this.transform;
            action.callBack = this;
            action.Start();
        }
    }

    public override void Update() {
        if (actionList.Count == 0)
            return;
        else if (Imdex < actionList.Count) {
            actionList[Imdex].Update();
        }
    }

    public void SSActionEvent(SSAction source, 
        SSActionEventType eventType = SSActionEventType.Completed,
        SSActionTargetType intParam = SSActionTargetType.Normal, string strParam = null, object objParam = null) {
        this.Imdex++;
        source.destroy = false;
        if (this.Imdex >= actionList.Count) {
            this.Imdex = 0;
            if (Times > 0)
            {
                Times--;
            }
            if (Times == 0) {
                this.destroy = true;
                this.callBack.SSActionEvent(this);
            }
        }
    }

   
}
