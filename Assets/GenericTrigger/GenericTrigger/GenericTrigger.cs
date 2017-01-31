using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GenericTrigger : MonoBehaviour {

    public enum TrigType { None,CollisionEnter,CollisionExit,TriggerEnter,TriggerExit,OnClick}

    public TrigType TypeOfTrigger = TrigType.None;

    public int mouseButton = 0;

    public bool sendGameObjectReference;

    //[System.Serializable]
    public GameObject go;

    //[System.Serializable]
    public Type so;

    //[SerializeField]
    public string function;

    //TRIGGER STUFF
    void Trig()
    {
        MonoBehaviour mb;
        foreach (Component co in go.GetComponents<MonoBehaviour>())
        {
            if(co.GetType() == so)
            {
                mb = (MonoBehaviour)co;
                if (sendGameObjectReference)
                {
                    mb.SendMessage(function,this.gameObject);
                }
                else
                {
                    mb.SendMessage(function);
                }
                return;
            }
        }

        //MethodInfo meth = mb.GetMethod(function);

        //(MonoBehaviour)go.GetComponent(so).invok

    }

    void check()
    {
        //Type[] types = Assembly.GetExecutingAssembly().GetTypes();

        MemberInfo[] memberInfos = so.GetMembers(BindingFlags.Public);

        Component[] allComponents;

        allComponents = go.GetComponents<MonoBehaviour>();

        //memberInfos[0].Name;

        //foreach (Type toCheck in so)
        //{
        //    MemberInfo[] memberInfos = toCheck.GetMembers(BindingFlags.Public);
        //    //Loop over the membersInfos and do what you need to such as retrieving their names
        //    // and adding them to a file
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TypeOfTrigger == TrigType.TriggerEnter)
        {
            Trig();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (TypeOfTrigger == TrigType.TriggerExit)
        {
            Trig();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (TypeOfTrigger == TrigType.CollisionEnter)
        {
            Trig();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (TypeOfTrigger == TrigType.CollisionExit)
        {
            Trig();
        }
    }

    bool mouseDowned = false;

	// Update is called once per frame
	void Update () {
		
        if(TypeOfTrigger == TrigType.OnClick)
        {
            if(Input.GetMouseButtonDown(mouseButton))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hitInfo = new RaycastHit();

                Physics.Raycast(r, out hitInfo);

                if(hitInfo.collider!= null && hitInfo.collider.gameObject == this.gameObject)
                {
                    mouseDowned = true;
                }
            }
            else if(mouseDowned && Input.GetMouseButtonUp(mouseButton))
            {
                mouseDowned = false;

                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hitInfo = new RaycastHit();

                Physics.Raycast(r, out hitInfo);

                if (hitInfo.collider != null && hitInfo.collider.gameObject == this.gameObject)
                {
                    Trig();
                }
            }
        }

	}
}
