using MemoFramework;
namespace GMTK.EventArgs
{
    public class OnRequireEnterSelectLevel : MFEventArgs
    {
        public static OnRequireEnterSelectLevel Create()
        {
            OnRequireEnterSelectLevel args = MFRefPool.Acquire<OnRequireEnterSelectLevel>();
            return args;
        }
        public override void Clear()
        {
        }
    }
}