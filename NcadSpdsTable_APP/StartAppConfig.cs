using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Multicad.Runtime;

namespace NcadSpdsTable_APP
{
    public class StartAPP
    {
        [CommandMethod("WorkWithSpdsTable", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public void StartApp()
        {
            GlobalFormApp startform = new GlobalFormApp();
            HostMgd.ApplicationServices.Application.ShowModelessDialog(startform);
        }
    }
}