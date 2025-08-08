﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Diagnostics;

namespace ONBOXAppl
{
    [Transaction(TransactionMode.Manual)]
    class SiteONBOX : IExternalCommand
    {


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

#if REVIT2025UP

                var startInfo = new ProcessStartInfo {
                    FileName = "http://www.onboxdesign.com.br/",
                    UseShellExecute = true
                };
                Process.Start(startInfo);

#else

            System.Diagnostics.Process.Start("http://www.onboxdesign.com.br/");

#endif

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class AboutONBOXApp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AboutUI aboutWindow = new AboutUI();
            aboutWindow.ShowDialog();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class Privacy : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            PrivacyUI privacyUI = new PrivacyUI();
            privacyUI.ShowDialog();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class ProjectFolder : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            string version = commandData.Application.Application.VersionNumber;
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Autodesk\\Revit\\Addins\\" + version + "\\ONBOX\\Project Examples"))
            {
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Autodesk\\Revit\\Addins\\" + version + "\\ONBOX\\Project Examples");
            }
            else
            {
                TaskDialog.Show(Properties.Messages.Common_Error, Properties.Messages.SampleProjects_DirNotFound);
            }
            return Result.Succeeded;
        }
    }
}
