using Microsoft.Xna.Framework;

namespace XNAUtility
{
    public class Camera : Placeable
    {
        float mNearClipDistance;
        float mFarClipDistance;
        float mAspectRatio;

        public BoundingFrustum ViewFrustum { get { return new BoundingFrustum( getViewMatrix() * getProjectionMatrix() ); } }

        public Camera( string setName, float setNearClipDistance, float setFarClipDistance, float setAspectRation, Vector3 setLocation, Vector3 setDirection )
            : base( setName, setLocation, setDirection )
        {
            mNearClipDistance = setNearClipDistance;
            mFarClipDistance = setFarClipDistance;
            mAspectRatio = setAspectRation;

            this.DrawOrder = 0;
        }

        public Matrix getProjectionMatrix()
        {
            return Matrix.CreatePerspectiveFieldOfView(
              MathHelper.PiOver4, // field of view
              mAspectRatio, // aspect ratio
              mNearClipDistance, mFarClipDistance // near and far clipping plane
            );
        }

        public Matrix getViewMatrix()
        {
            Matrix ViewMatrix = Matrix.Identity;
            ViewMatrix *= Matrix.CreateTranslation( Location );
            ViewMatrix *= Matrix.CreateRotationZ( Rotation.Z );
            ViewMatrix *= Matrix.CreateRotationY( Rotation.Y );
            ViewMatrix *= Matrix.CreateRotationX(Rotation.X );
            return ViewMatrix;
        }

        public override void setDebugData( DebugForm DebugForm )
        {
            if( DebugForm != null )
            {
                DebugForm.setDebugValue( Name + "|Camera|Near Clip Distance", mNearClipDistance.ToString() );
                DebugForm.setDebugValue( Name + "|Camera|Far Clip Distance", mFarClipDistance.ToString() );
                DebugForm.setDebugValue( Name + "|Camera|Aspect Ratio", mAspectRatio.ToString() );
                base.setDebugData( DebugForm );
            }
        }
    }
}
