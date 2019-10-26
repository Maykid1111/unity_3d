using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSActionManager : MonoBehaviour {

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> Add = new List<SSAction>();
    private List<int> Delete = new List<int>();

    protected void Start () {
	
	}

    protected void Update() {
	    foreach (SSAction ac in Add) {
            actions[ac.GetInstanceID()] = ac;
        }
        Add.Clear();

        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.destroy)
                Delete.Add(kv.Key);
            else if (ac.enable)
                ac.Update();
        }

        foreach (int key in Delete) {
            SSAction ac = actions[key];
            actions.Remove(key);
            Object.Destroy(ac);
        }
        Delete.Clear();
    }

    public void runAction(GameObject gameObj, SSAction action, ISSActionCallback manager) {
        for (int i = 0; i < Add.Count; i++) {
            if (Add[i].gameObject.Equals(gameObj)) {
                SSAction ac = Add[i];
                Add.RemoveAt(i);
                i--;
                Object.Destroy(ac);
            }
        }
        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.gameObject.Equals(gameObj)) {
                ac.destroy = true;
            }
        }

        action.gameObject = gameObj;
        action.transform = gameObj.transform;
        action.callBack = manager;
        Add.Add(action);
        action.Start();
    }
}
