using System;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction: SSAction {
    public Vector3 POS;
    public float speed;
    public bool state;

    public static CCMoveToAction CreateSSAction(Vector3 _POS, float _speed, bool _state) {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.POS = _POS;
        action.speed = _speed;
        action.state = _state;
        return action;
    }

    public override void Start() {
        
    }

    public override void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, POS, speed);
        if (this.transform.position == POS) {
            this.destroy = true;
            if (!state)
                this.callBack.SSActionEvent(this);
            else
                this.callBack.SSActionEvent(this, SSActionEventType.Completed, SSActionTargetType.Catching);
        }
    }
}
