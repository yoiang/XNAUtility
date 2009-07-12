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
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        public void setDebugValue( string Path, string Value )
        {
            if( !DebugTree.IsDisposed )
            {
                DebugTree.setDebugValue( Path, Value );
            }
        }
    }
}
