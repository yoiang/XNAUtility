using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace XNAUtility
{
    public class SharedVector3List
    {
        protected List<Vector3> mVectors;
        public SharedVector3List()
        {
            mVectors = new List<Vector3>();
        }
        public SharedVector3List( SharedVector3List copy )
        {
            mVectors = new List<Vector3>( copy.mVectors );
        }

        public Vector3 this[ int key ] { get { return mVectors[ key ]; } set { mVectors[ key ] = value; } }

        public int add( Vector3 addTo )
        {
            //            int Index = mVectors.Find( addTo );
            int Index;
            for( Index = 0; Index < mVectors.Count; ++Index )
            {
                if( mVectors[ Index ] == addTo )
                {
                    break;
                }
            }
            if( Index == mVectors.Count )
            {
                Index = mVectors.Count;
                mVectors.Add( addTo );
            }
            return Index;
        }
        public int getIndex( Vector3 getFrom )
        {
            int Index;
            for( Index = 0; Index < mVectors.Count; ++Index )
            {
                if( mVectors[ Index ] == getFrom )
                {
                    break;
                }
            }
            if( Index == mVectors.Count )
            {
                return -1;
            }
            return Index;
        }

        public VertexPositionColor[] getVertexPositionColorList( Color setColor )
        {
            VertexPositionColor[] List = new VertexPositionColor[ mVectors.Count ];
            for( int travVectors = 0; travVectors < mVectors.Count; ++travVectors )
            {
                List[ travVectors ] = new VertexPositionColor( mVectors[ travVectors ], setColor );
            }
            return List;
        }
    }

    public class VertexQueue<T> where T : struct
    {
        T[] Vertices;
        short[] Indices;
        short CurrentIndex;

        public VertexQueue( short setLength )
        {
            Vertices = new T[ setLength ];
            Indices = new short[ setLength ];
            CurrentIndex = 0;
        }

        public void add( T addValue )
        {
            if( CurrentIndex >= Vertices.Length )
            {
                throw ( new Exception( "Cannot exceed length " + Vertices.Length ) );
            }
            Vertices[ CurrentIndex ] = addValue;
            Indices[ CurrentIndex ] = CurrentIndex;
            CurrentIndex++;
        }

        public void draw( GraphicsDevice GraphicsDevice )
        {
            if( CurrentIndex / 3 >= 1 )
            {
                GraphicsDevice.DrawUserPrimitives<T>( PrimitiveType.TriangleList, Vertices, 0, ( int )( CurrentIndex / 3 ) );
            }
        }
    }

    static public class Debug
    {
        public static void drawAxis()
        {
            drawAxis( 100.0f );
        }

        public static void drawAxis( float Length)
        {
            GameArgs.Current.GraphicsDevice.VertexDeclaration = new VertexDeclaration( GameArgs.Current.GraphicsDevice, VertexPositionColor.VertexElements );
            GameArgs.Current.setBasicEffectMatrices( GameArgs.Current.BasicEffect );
            GameArgs.Current.BasicEffect.Begin();
            GameArgs.Current.BasicEffect.CurrentTechnique.Passes[ 0 ].Begin();

            VertexPositionColor[] vertices = new VertexPositionColor[ 6 ];
            vertices[ 0 ].Position = new Vector3( 0, 0, 0 );
            vertices[ 0 ].Color = Color.Red;
            vertices[ 1 ].Position = new Vector3( Length, 0, 0 );
            vertices[ 1 ].Color = Color.Red;

            vertices[ 2 ].Position = new Vector3( 0, 0, 0 );
            vertices[ 2 ].Color = Color.Green;
            vertices[ 3 ].Position = new Vector3( 0, Length, 0 );
            vertices[ 3 ].Color = Color.Green;

            vertices[ 4 ].Position = new Vector3( 0, 0, 0 );
            vertices[ 4 ].Color = Color.Blue;
            vertices[ 5 ].Position = new Vector3( 0, 0, Length );
            vertices[ 5 ].Color = Color.Blue;
            GameArgs.Current.GraphicsDevice.DrawUserPrimitives( PrimitiveType.LineList, vertices, 0, 3 );

            GameArgs.Current.BasicEffect.CurrentTechnique.Passes[ 0 ].End();
            GameArgs.Current.BasicEffect.End();
        }
    }

}
