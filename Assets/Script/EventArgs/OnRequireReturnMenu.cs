//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2025-02-13 14:47:07
//------------------------------------------------------------


using MemoFramework;

namespace GMTK.EventArgs
{
    public class OnRequireReturnMenu : MFEventArgs
    {
        public static OnRequireReturnMenu Create()
        {
            OnRequireReturnMenu args = MFRefPool.Acquire<OnRequireReturnMenu>();
            return args;
        }


        public override void Clear()
        {
        }
    }
}