using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(GenericTrigger))]
public class GenericTriggerOverride : Editor {

    GenericTrigger gt;

    public override void OnInspectorGUI()
    {
        //target = base.target(GenericTrigger);
        //base.OnInspectorGUI();

        gt = (GenericTrigger)target;

        gt.TypeOfTrigger = (GenericTrigger.TrigType)EditorGUILayout.EnumPopup("Type of Trigger: ",gt.TypeOfTrigger);

        if(gt.TypeOfTrigger == GenericTrigger.TrigType.OnClick)
        {
            gt.mouseButton = EditorGUILayout.IntField("Mouse Button Number: ", gt.mouseButton);
        }

        gt.sendGameObjectReference = EditorGUILayout.Toggle("Send GameObject: ", gt.sendGameObjectReference);

        gt.go =(GameObject)EditorGUILayout.ObjectField("GameObject: ", gt.go,typeof(GameObject),true);

        if(gt.go != null)
        {
            if (mons.Count < 1)
            {
                refreshScripts();

            }
            else
            {
                selection = EditorGUILayout.Popup("Script: ",selection, nms.ToArray());
                gt.so = mons[selection].GetType();

                //if(funcsList.Count < 1)
                //{
                //    //refreshFuncs();

                //}
                //else
                //{
                //selectionFunc = EditorGUILayout.TextArea( selectionFunc); //EditorGUILayout.Popup("Function: ", selection, funcsList.ToArray());
                //gt.function = funcsList[selectionFunc];
                gt.function = EditorGUILayout.TextField("Function name", gt.function);
                //}
            }

            
        }
        
        if(GUILayout.Button("Refresh Scripts"))
        {
            refreshScripts();
        }
        //if(GUILayout.Button("Refresh Functions"))
        //{
        //    refreshFuncs();
        //}


    }
    int selection = 0;
    int selectionFunc = 0;
    List<MonoBehaviour> mons = new List<MonoBehaviour>();
    List<string> nms = new List<string>();

    List<string> funcsList = new List<string>();

    void refreshScripts()
    {
        selection = 0;
        mons = new List<MonoBehaviour>( gt.go.GetComponents<MonoBehaviour>());

        nms = new List<string>();
        foreach (MonoBehaviour mb in mons)
        {
            nms.Add(mb.ToString());
        }

    }
    //void refreshFuncs()
    //{
    //    funcsList = new List<string>();

    //    MemberInfo[] memberInfos = mons[selection].GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
    //    Debug.Log(memberInfos.Length);
    //    foreach (MemberInfo mi in memberInfos)
    //    {
    //        funcsList.Add(mi.ToString());
    //    }

    //}
    
}
