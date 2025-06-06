using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace BookRP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex? _mutex;

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetForegroundWindow(IntPtr hWnd);

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;

        protected override void OnStartup(StartupEventArgs e)
        {
            // 프로그램 중복 실행 방지
            _mutex = new Mutex(true, "BookRP", out bool createdNew);

            if (!createdNew)
            {
                BringExistingInstanceToFront();
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        /// <summary>
        /// 이미 실행중인 기존 인스턴스의 창을 앞으로 가져옵니다.
        /// </summary>
        private void BringExistingInstanceToFront()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                IntPtr hWnd = process.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_RESTORE); // 최소화 상태면 복원
                    SetForegroundWindow(hWnd); // 앞으로 가져오기
                }

                break;
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            base.OnExit(e);
        }
    }
}
