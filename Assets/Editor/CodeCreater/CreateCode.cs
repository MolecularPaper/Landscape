//Author: APMIX
//Put this in Assets/Editor Folder
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Reflection;

namespace UnityEditor
{
    public class CreateCode
    {
        [MenuItem("Assets/Create/Create New Code", false, priority = 75)]
        static void Create()
        {
            // remove whitespace and minus
            string name = "NewCode";
            name = name.Replace("-", "_");

            if (!TryGetActiveFolderPath(out string copyPath)) {
                return;
            }

            copyPath += "/" + name + ".cs";

            Debug.Log("Creating Classfile: " + copyPath);
            if (File.Exists(copyPath) == false) { // do not overwrite
                using (StreamWriter outfile =
                    new StreamWriter(copyPath)) {
                    outfile.WriteLine("using System.Collections;");
                    outfile.WriteLine("using System.Collections.Generic;");
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("");
                    outfile.WriteLine("namespace Namespace");
                    outfile.WriteLine("{");
                    outfile.WriteLine("    //스크립트 개요 작성");
                    outfile.WriteLine("    public class " + name + " : MonoBehaviour");
                    outfile.WriteLine("    {");
                    outfile.WriteLine("        #region Variables");
                    outfile.WriteLine("        //변수 작성");
                    outfile.WriteLine("        #endregion");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("        #region Properties");
                    outfile.WriteLine("        //프로퍼티 작성");
                    outfile.WriteLine("        #endregion");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("        #region Unity Event Methods");
                    outfile.WriteLine("        //이벤트 메소드 작성");
                    outfile.WriteLine("        private void Awake()");
                    outfile.WriteLine("        {");
                    outfile.WriteLine("            ");
                    outfile.WriteLine("        }");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("        private void Update()");
                    outfile.WriteLine("        {");
                    outfile.WriteLine("            ");
                    outfile.WriteLine("        }");
                    outfile.WriteLine("        #endregion");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("        #region Methods");
                    outfile.WriteLine("        //일반 메소드 작성");
                    outfile.WriteLine("        #endregion");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("        #region Debug");
                    outfile.WriteLine("        //디버그 메소드 작성(있을경우)");
                    outfile.WriteLine("        #endregion");
                    outfile.WriteLine("        ");
                    outfile.WriteLine("    }");
                    outfile.WriteLine("}");
                }//File written
            }
            AssetDatabase.Refresh();
        }

        // Define this function somewhere in your editor class to make a shortcut to said hidden function
        private static bool TryGetActiveFolderPath(out string path)
        {
            var _tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("TryGetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = new object[] { null };
            bool found = (bool)_tryGetActiveFolderPath.Invoke(null, args);
            path = (string)args[0];

            return found;
        }
    }
}
