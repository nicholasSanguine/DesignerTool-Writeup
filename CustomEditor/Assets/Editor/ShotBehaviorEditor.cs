using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShotBehavior))]
public class ShotBehaviorEditor : EditorWindow
{
    public GameObject shotPrefab;
    ShotBehavior shotBehavior;//internally hold this after it's set so we don't have to call get component a bunch
    
    [MenuItem("Tools/ShotBehaviorEditor")]
    static void ShowWindow()
    {
        GetWindow(typeof(ShotBehaviorEditor));
    }
    private void OnGUI()
    {
        GUILayout.Label("Shot Behavior Easy Editor", EditorStyles.boldLabel);
        EditorGUILayout.Space();//injects a small space
        shotPrefab = EditorGUILayout.ObjectField("Prefab we're editing", shotPrefab, typeof(GameObject), false) as GameObject;
        if (shotPrefab != null && shotPrefab.GetComponent<ShotBehavior>() != null)
            LoadComponent();
        else
        {
            shotPrefab.AddComponent<ShotBehavior>();
        }
    }
    void LoadComponent()
    {
        EditorGUILayout.Space();//injects a small space
        if (shotBehavior != shotPrefab.GetComponent<ShotBehavior>())
            shotBehavior = shotPrefab.GetComponent<ShotBehavior>();//Average saves many cycles

        //Dropdown for our enum types
        shotBehavior.sometype = (ShotBehavior.SomeType)EditorGUILayout.EnumPopup("Collision Behavior", shotBehavior.sometype);
        /*
                In every if statement we do a couple things.
            1. Destroy the other components if they are there. https://docs.unity3d.com/ScriptReference/Object.DestroyImmediate.html
            2. Add our component if it isn't already on there. https://docs.unity3d.com/ScriptReference/GameObject.AddComponent.html
            3. Call appropriate function for loading information about the loaded function
        */
        if (shotBehavior.sometype == ShotBehavior.SomeType.Bounce) 
        { 
          //First make sure we unload other components if they exist
          if(shotPrefab.GetComponent<Destroy_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Destroy_Helper>(), true); }
          if (shotPrefab.GetComponent<Stick_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Stick_Helper>(), true); }
          //Check if we don't already have the component attatched. If it isn't we attatch it.
          if (shotPrefab.GetComponent<Bounce_Helper>() == null) { shotPrefab.AddComponent<Bounce_Helper>(); }
          //Call our EditBounce() function
          EditBounce();
        }
        if(shotBehavior.sometype == ShotBehavior.SomeType.Destroy)
        {
            //First make sure we unload other components if they exist
            if (shotPrefab.GetComponent<Bounce_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Bounce_Helper>(), true); }
            if (shotPrefab.GetComponent<Stick_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Stick_Helper>(), true); }
            //Check if we don't already have the component attatched. If it isn't we attatch it.
            if (shotPrefab.GetComponent<Destroy_Helper>() == null) { shotPrefab.AddComponent<Destroy_Helper>(); }
            //Call our EditDestroy() function
            EditDestroy();
        }
        if(shotBehavior.sometype == ShotBehavior.SomeType.Stick)
        {
            //First make sure we unload other components if they exist
            if (shotPrefab.GetComponent<Bounce_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Bounce_Helper>(), true); }
            if (shotPrefab.GetComponent<Destroy_Helper>() != null) { DestroyImmediate(shotPrefab.GetComponent<Destroy_Helper>(),true); }
            //Check if we don't already have the component attatched. If it isn't we attatch it.
            if (shotPrefab.GetComponent<Stick_Helper>() == null) { shotPrefab.AddComponent<Stick_Helper>(); }
            //Call our EditStick() function
            EditStick();
        }

    }
    #region These are the functions that show the different change values
    void EditBounce()
    {
        GUILayout.Label("Bounce-Helper Value");
        shotPrefab.GetComponent<Bounce_Helper>().someValue = EditorGUILayout.Slider(shotPrefab.GetComponent<Bounce_Helper>().someValue, 0.0f, 20.0f);
    }

    void EditDestroy()
    {
        GUILayout.Label("Destroy-Helper Value");
        shotPrefab.GetComponent<Destroy_Helper>().someInt = EditorGUILayout.IntField(shotPrefab.GetComponent<Destroy_Helper>().someInt);
    }
    void EditStick() 
    {
        GUILayout.Label("Stick-Helper Value");
        shotPrefab.GetComponent<Stick_Helper>().SomeFloat = EditorGUILayout.DelayedFloatField(shotPrefab.GetComponent<Stick_Helper>().SomeFloat);
    }
    #endregion
}
