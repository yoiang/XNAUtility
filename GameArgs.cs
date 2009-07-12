using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAUtility
{
    public class GameArgs
    {
        public static GameArgs Current;
        public GameArgs( Microsoft.Xna.Framework.Game setGame )
        {
            Current = this;

            Game = setGame;
            GraphicsDeviceManager = new GraphicsDeviceManager( Game );
            ContentManager = Game.Content;

            WorldObjects = new List<Placeable>();
        }

        public Game Game;
        public static implicit operator Game( GameArgs cast )
        {
            return cast.Game;
        }

        public GraphicsDeviceManager GraphicsDeviceManager;
        public static implicit operator GraphicsDeviceManager( GameArgs cast )
        {
            return cast.GraphicsDeviceManager;
        }

        public GraphicsDevice GraphicsDevice;
        public static implicit operator GraphicsDevice( GameArgs cast )
        {
            return cast.GraphicsDevice;
        }

        public ContentManager ContentManager;
        public static implicit operator ContentManager( GameArgs cast )
        {
            return cast.ContentManager;
        }

        #region Debugging
        #region DebugForm
        private DebugForm mDebugForm;
        public DebugForm DebugForm { get { return mDebugForm; } }
        public void openDebugForm()
        {
            if( mDebugForm == null )
            {
                mDebugForm = new DebugForm();
                mDebugForm.Location = new System.Drawing.Point( Game.Window.ClientBounds.X + Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Y );
                mDebugForm.Show();
            }
            foreach( Placeable Object in WorldObjects )
            {
                Object.setDebugData( mDebugForm );
            }
        }

        public void closeDebugForm()
        {
            /*                if( mDebugForm != null )
                {
                    mDebugForm.Close();
                    mDebugForm = null;
                }*/
        }
        #endregion

        private bool mDebug;
        public bool Debug { get { return mDebug; } set { setDebug( value ); } }
        public virtual void setDebug( bool set )
        {
            if( mDebug != set )
            {
                mDebug = set;

                if( Debug )
                {
                    openDebugForm();
                } else
                {
                    closeDebugForm();
                }

                foreach( Placeable Object in WorldObjects )
                {
                    Object.Debug = mDebug;
                }
            }
        }
        #endregion

        private List<Placeable> WorldObjects;
        public void addWorldObject( Placeable add )
        {
            add.Debug = mDebug;
            WorldObjects.Add( add );
            Game.Components.Add( add );
        }

        public Matrix ViewMatrix;
        public Matrix ProjectionMatrix;
        public Matrix WorldMatrix;

        public BasicEffect BasicEffect;
        public void setBasicEffectMatrices( BasicEffect Effect )
        {
            Effect.View = ViewMatrix;
            Effect.Projection = ProjectionMatrix;
            Effect.World = WorldMatrix;
        }
    }
}
