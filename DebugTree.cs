using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XNAUtility
{
    public partial class DebugTree : TreeView
    {
        Dictionary<string, TreeNode> CachedValues;
        public DebugTree() : base()
        {
            InitializeComponent();
            CachedValues = new Dictionary<string, TreeNode>();
        }

        protected override void OnPaint( PaintEventArgs pe )
        {
            base.OnPaint( pe );
        }

        public void setDebugValue( string Path, string Value )
        {
            TreeNode ItemNode = null;
            if( CachedValues.ContainsKey( Path ) )
            {
                ItemNode = CachedValues[ Path ];
            } else
            {
                char[] splitOn = { '|' };
                string[] SplitPath = Path.Split( splitOn );
                int PathDepth = 0;
                TreeNodeCollection travNodes = Nodes;
                while( PathDepth < SplitPath.Length )
                {
                    ItemNode = null;
                    for( int travContained = 0; travContained < travNodes.Count; ++travContained )
                    {
                        if( travNodes[ travContained ].Text == SplitPath[ PathDepth ] )
                        {
                            ItemNode = travNodes[ travContained ];
                            break;
                        }
                    }
                    if( ItemNode == null )
                    {
                        ItemNode = new TreeNode( SplitPath[ PathDepth ] );
                        travNodes.Add( ItemNode );
                    }
                    PathDepth++;
                    travNodes = ItemNode.Nodes;
                }
                if( travNodes.Count == 0 ) //TODO: fix hack, means values can only be leaf nodes
                {
                    travNodes.Add( new TreeNode() );
                }
                ItemNode = travNodes[ 0 ];
            }
            ItemNode.Text = Value;
        }
    }
}
