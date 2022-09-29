using Shapes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(DashStyle))]
public class DashStylePropertyDrawer : PropertyDrawer
{
	// Draw the property inside the given rect
	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		// Create property container element.
		var container = new VisualElement();

		// Create property fields.
		var typeField = new PropertyField(property.FindPropertyRelative("type"));
		var spaceField = new PropertyField(property.FindPropertyRelative("space"));
		var snapField = new PropertyField(property.FindPropertyRelative("snap"));
		var sizeField = new PropertyField(property.FindPropertyRelative("size"));
		var offsetField = new PropertyField(property.FindPropertyRelative("offset"));
		var spacingField = new PropertyField(property.FindPropertyRelative("spacing"));
		var shapeModifier = new PropertyField(property.FindPropertyRelative("shapeModifier"));

		// Add fields to the container.
		container.Add(typeField);
		container.Add(spaceField);
		container.Add(snapField);
		container.Add(sizeField);
		container.Add(offsetField);
		container.Add(spacingField);
		container.Add(shapeModifier);
		
		return container;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		EditorGUI.PropertyField(position, property, label, true);
		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property);
	}
}
