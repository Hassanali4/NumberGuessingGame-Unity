//
//Copyright (c) Hassan_Ali. All rights reserved 
//

using UnityEditor;

public class CreateScriptTemplates
{
    [MenuItem("Assets/Create/Code/MonoBehaviour" , priority = 40)]
    public static void CreateMonoBehaviourMenuItem()
    {
        string templatePath = "Assets/Editor/Templates/MonoBehaviour.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScript.cs");
    }
    [MenuItem("Assets/Create/Code/Enum" , priority = 41)]
    public static void CreateEnumMenuItem()
    {
        string templatePath = "Assets/Editor/Templates/Enum.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
    }
    [MenuItem("Assets/Create/Code/ScrptableObjectM", priority = 42)]
    public static void CreateScrptableObjectMenuItem()
    {
        string templatePath = "Assets/Editor/Templates/ScrptableObject.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScrptableObject.cs");
    }
    [MenuItem("Assets/Create/Code/Class", priority = 43)]
    public static void CreateClassMenuItem()
    {
        string templatePath = "Assets/Editor/Templates/Class.cs.txt";

        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewClass.cs");
    }
}
