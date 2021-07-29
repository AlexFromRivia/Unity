using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using System;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]

public class ItemEditor : Editor
{
    Item _itemPropertyes;
    Weapon _weaponPropertyes;

    SerializedProperty _itemTypes;

    private void OnEnable()
    {
        _itemPropertyes = target as Item;
        _weaponPropertyes = target as Weapon;
        _itemTypes = serializedObject.FindProperty("ItemTypes");
    }

    public override void OnInspectorGUI()
    {
        //Метод обязателен
        serializedObject.Update();

        //Icon
        EditorGUILayout.LabelField("Icon");
        _itemPropertyes._itemIcon = (Sprite)EditorGUILayout.ObjectField(_itemPropertyes._itemIcon, typeof(Sprite), GUILayout.Width(75), GUILayout.Height(75));

        #region String fields
        _itemPropertyes._itemName = EditorGUILayout.TextField("Item Name", _itemPropertyes._itemName);
        _itemPropertyes._itemCode = EditorGUILayout.TextField("Item Code", _itemPropertyes._itemCode);
        #endregion

        #region Integer fields
        _itemPropertyes._price = EditorGUILayout.IntField("Price", _itemPropertyes._price);
        _itemPropertyes._itemAmount = EditorGUILayout.IntField("Amount", _itemPropertyes._itemAmount);
        _itemPropertyes._index = EditorGUILayout.IntField("Index", _itemPropertyes._index);

        
        EditorGUILayout.LabelField("Test");
        _weaponPropertyes.PhysicDamage = EditorGUILayout.IntField("Physic damage", _weaponPropertyes.PhysicDamage);
        #endregion

        //Метод обязателен
        serializedObject.ApplyModifiedProperties();
    }
}
