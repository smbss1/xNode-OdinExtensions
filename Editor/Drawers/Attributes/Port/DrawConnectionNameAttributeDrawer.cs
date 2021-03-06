﻿
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

using UnityEngine;
using XNode.Odin;
using static XNode.Node;

namespace XNodeEditor.Odin
{
	[NodePortAttributeDrawerPriority]
	public class DrawConnectionNameAttributeDrawer<T> : NodePortAttributeDrawer<DrawConnectionNameAttribute, T>
	{
		protected override bool CanDrawNodePort( NodePortInfo nodePortInfo, InspectorProperty property )
		{
			return nodePortInfo.ConnectionType == ConnectionType.Override;
		}

		protected GUIContent connectionName = GUIContent.none;

		protected override void DrawPort( GUIContent label )
		{
			// Extra sanity checks
			if ( Event.current.type == EventType.Layout )
			{
				if ( NodePortInfo.Port.IsConnected && NodePortInfo.Port.Connection != null && NodePortInfo.Port.Connection.node != null )
					connectionName = new GUIContent( NodePortInfo.Port.Connection.node.name );
				else
					connectionName = label;
			}

			CallNextDrawer( connectionName );
		}
	}
}
