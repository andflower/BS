using BS.Model;
using CefSharp.WinForms;
using CefSharp;
using System;
using System.IO;
using System.Windows.Forms;
using BS.Properties;
using System.Diagnostics;

namespace BS
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Cef.IsInitialized)
            {
                CefSettings cefSettings = new CefSettings();
                cefSettings.Locale = "ko";
                CefSharpSettings.ShutdownOnExit = false;

                // 다른 CefSharp 설정을 여기에 추가할 수 있습니다.
                cefSettings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache");
                Debug.WriteLine(cefSettings.CachePath);

                // debugging port -> http://localhost:62000
                cefSettings.RemoteDebuggingPort = 62000;

                Cef.Initialize(cefSettings, performDependencyCheck: true, browserProcessHandler: null);
            }

            var localDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var jusorobinPath = Path.Combine(localDirectory, @"jusoro-2.0.0-win64-internet\jusoro\bin");

            // 외부 명령 실행 (startup.cmd)
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start {jusorobinPath}\\startup.cmd", // /C 옵션은 명령 실행 후 cmd 창을 닫습니다.
                WorkingDirectory = jusorobinPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true, // TODO : 창 숨기는 기능 필요
            };

            Process process = Process.Start(psi);
            //string result = process.StandardOutput.ReadToEnd();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            if (MainClass.isLogined == true)
            {
                Application.Run(new frmMain());
            }

            Cef.Shutdown();
            process.Close();
        }
    }
}
