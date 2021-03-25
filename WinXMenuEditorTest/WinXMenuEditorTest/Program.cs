using MenuWinX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WinXMenuEditorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myWinXLnk = @"C:\Users\503212497\AppData\Local\Microsoft\Windows\WinX\Group4\Paint.lnk";
            var myWinXApp = @"C:\Windows\regedit.exe";
            //var myWinXApp = @"C:\Users\503212497\Downloads\WinXMenuEditorRelease\WinXEditor.exe";
            var myWinXAppDir = @"Path.GetDirectoryName(myWinXApp)";
            //var myWinXLnk = @"C:\Users\503212497\AppData\Local\Microsoft\Windows\WinX\Group4\Registry Editor.lnk";

            HashLnk.CreateLnk(4, "Registry Editor", myWinXApp, myWinXAppDir, false, "");
            //HashLnk.CreateLnk(4, "WinX Menu Editor", myWinXApp, myWinXAppDir, true, "");
            //new HashLnk(myWinXLnk);

            ReadKey();
        }
    }
}
