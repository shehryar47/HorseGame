﻿using MalbersAnimations.Scriptables;
using MalbersAnimations.Events;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MalbersAnimations
{
    [AddComponentMenu("Malbers/Variables/Int Comparer")]
    [HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
    public class IntComparer : IntVarListener
    {
        public List<AdvancedIntegerEvent> compare = new List<AdvancedIntegerEvent>();
      
        /// <summary>Set the first value on the comparer </summary>
        public int CompareFirst { get => compare[0].Value.Value; set => compare[0].Value.Value = value; }

        public override int Value
        {
            set
            {
                base.Value = value;
                if (Auto) Compare();
            }
        }


        public int this[int index]
        {
            get => compare[index].Value.Value;
            set => compare[index].Value.Value = value;
        }

        void OnEnable()
        {
            if (value.Variable && Auto)
            {
                value.Variable.OnValueChanged += Compare;
                value.Variable.OnValueChanged += Invoke;
            }

            Raise.Invoke(Value);
        }

        void OnDisable()
        {
            if (value.Variable && Auto)
            {
                value.Variable.OnValueChanged -= Compare;
                value.Variable.OnValueChanged -= Invoke;
            }
        }


        /// <summary>Compares the Int parameter on this Component and if the condition is made then the event will be invoked</summary>
        public virtual void Compare()
        {
            foreach (var item in compare)
                item.ExecuteAdvanceIntegerEvent(value);
        }


        /// <summary>Compares an given int Value and if the condition is made then the event will be invoked</summary>
        public virtual void Compare(int value)
        {
            foreach (var item in compare)
                item.ExecuteAdvanceIntegerEvent(value);
        }

        /// <summary>Compares an given intVar Value and if the condition is made then the event will be invoked</summary>
        public virtual void Compare(IntVar value)
        {
            foreach (var item in compare)
                item.ExecuteAdvanceIntegerEvent(value.Value);
        }
    }


    //INSPECTOR
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(IntComparer))]
    public class IntCompareEditor : VarListenerEditor
    {
        private UnityEditor.SerializedProperty Raise1, compare;
        private UnityEditorInternal.ReorderableList reo_compare;

        private GUIContent DebugCont;

        private void OnEnable()
        {
            base.SetEnable();
            Raise1 = serializedObject.FindProperty("Raise");
            compare = serializedObject.FindProperty("compare");

            reo_compare = new UnityEditorInternal.ReorderableList(serializedObject, compare, true, true, true, true)
            {
                drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    var element = compare.GetArrayElementAtIndex(index);
                    var name = element.FindPropertyRelative("name");
                    var comparer = element.FindPropertyRelative("comparer");
                    var Value = element.FindPropertyRelative("Value");

                    rect.y += 1;
                    var height = UnityEditor.EditorGUIUtility.singleLineHeight;
                    var split = rect.width / 3;
                    var p = 5;

                    var rectName = new Rect(rect.x, rect.y, split + p - 2, height);
                    var rectComparer = new Rect(rect.x + split + p, rect.y, split - p, height);
                    var rectValue = new Rect(rect.x + split * 2 + p + 15, rect.y, split - p - 10, height);


                    UnityEditor.EditorGUI.PropertyField(rectName, name, GUIContent.none);
                    UnityEditor.EditorGUI.PropertyField(rectComparer, comparer, GUIContent.none);
                    UnityEditor.EditorGUI.PropertyField(rectValue, Value, GUIContent.none);
                },
               
                drawHeaderCallback = (Rect rect) =>
                {
                    rect.y += 1;
                    var height = UnityEditor.EditorGUIUtility.singleLineHeight;
                    var split = rect.width / 3;
                    var p = (split * 0.3f);
                    var rectName = new Rect(rect.x, rect.y, split + p - 2, height);
                    var rectComparer = new Rect(rect.x + split + p, rect.y, split - p + 15, height);
                    var rectValue = new Rect(rect.x + split * 2 + p + 5, rect.y, split - p, height);
                    var DebugRect = new Rect(rect.width, rect.y - 1, 25, height + 2);

                    UnityEditor.EditorGUI.LabelField(rectName, "    Name");
                    UnityEditor.EditorGUI.LabelField(rectComparer, " Compare");
                    UnityEditor.EditorGUI.LabelField(rectValue, " Value");
                },
            };
        }

       
 
        protected override void DrawEvents()
        {
            //UnityEditor.EditorGUILayout.BeginVertical(UnityEditor.EditorStyles.helpBox);
            //UnityEditor.EditorGUILayout.PropertyField(Raise1);
            reo_compare.DoLayoutList();

            int SelectedItem = reo_compare.index;

            if (SelectedItem != -1)
            {
                var element = compare.GetArrayElementAtIndex(SelectedItem);
                if (element != null)
                {
                    var Response = element.FindPropertyRelative("Response");
                    var name = element.FindPropertyRelative("name").stringValue;
                    UnityEditor.EditorGUILayout.PropertyField(Response, new GUIContent("Response: [" + name + "]   "));
                }
            }

            //UnityEditor.EditorGUI.indentLevel++;
            //UnityEditor.EditorGUILayout.PropertyField(compare, true);
            //UnityEditor.EditorGUI.indentLevel--;
            //UnityEditor.EditorGUILayout.EndVertical();

            //UnityEditor.EditorGUILayout.Space(16);
            //UnityEditor.EditorGUILayout.PropertyField(Raise1);
        }
    }
#endif
}