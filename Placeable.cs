using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNAUtility
{
    public abstract class Placeable : DrawableGameComponent
    {
        private string mName;
        public string Name { get { return mName; } }

        private Vector3 mLocation;
        private Vector3 mRotation;
        public Vector3 Location { get { return mLocation; } set { mLocation = value; setDebugData(); } }
        public Vector3 Rotation { get { return mRotation; } set { mRotation = value; setDebugData(); } }

        public bool Debug;
        
        public Placeable( string setName ) : this( setName, Vector3.Zero, new Vector3( 0.0f, 0.0f, 1.0f ) )
        {
        }
        public Placeable( string setName, Vector3 setLocation )
            : this( setName, setLocation, new Vector3( 0.0f, 0.0f, 1.0f ) )
        {
        }
        public Placeable(string setName, Vector3 setLocation, Vector3 setRotation)
            : base( GameArgs.Current.Game )
        {
            mName = setName;

            mLocation = setLocation;
            mRotation = setRotation;

            setDebugData();
        }

/*        public override void Draw( GameTime GameTime )
        {
            base.Draw( GameTime );
            if( Debug )
            {
                // rotate and draw axis
            }
        }
        */

        public void setDebugData()
        {
            if( GameArgs.Current != null && GameArgs.Current.DebugForm != null )
            {
                setDebugData( GameArgs.Current.DebugForm );
            }
        }

        public virtual void setDebugData( DebugForm DebugForm )
        {
            if( DebugForm != null )
            {
                DebugForm.setDebugValue( Name + "|Placeable|Location", Location.ToString() );
                DebugForm.setDebugValue(Name + "|Placeable|Rotation", Rotation.ToString());
            }
        }
    }
}
