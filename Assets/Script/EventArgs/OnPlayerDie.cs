//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2025-02-13 14:47:07
//------------------------------------------------------------


using MemoFramework;

namespace GMTK.EventArgs
{
    public class OnPlayerDie : MFEventArgs
    {
        public static OnPlayerDie Create()
        {
            OnPlayerDie args = MFRefPool.Acquire<OnPlayerDie>();
            return args;
        }


        public override void Clear()
        {
        }
    }
}