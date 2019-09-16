using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ankh.UI.VSSelectionControls;

namespace ReviewBoardVsx.UI
{
    class SubmitListView : SmartListView
    {
        public SubmitListView()
        {
            SmartColumn path = new SmartColumn(this, "Path", 60, "Path");
            SmartColumn project = new SmartColumn(this, "Project", 60, "Project");
            SmartColumn change = new SmartColumn(this, "Change", 60, "Change");
            SmartColumn fullPath = new SmartColumn(this, "Full Path", 60, "FullPath");

            Columns.AddRange(new ColumnHeader[]
            {
                path,
                project,
                change,
                fullPath
            });

            project.Groupable = true;

            path.Hideable = false;

            SortColumns.Add(path);
            GroupColumns.Add(project);

            FinalSortColumn = path;

            ShowSelectAllCheckBox = true;
        }
    }
}
