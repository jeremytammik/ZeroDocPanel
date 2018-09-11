#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace ZeroDocPanel
{
  [Transaction( TransactionMode.Manual )]
  [Regeneration( RegenerationOption.Manual )]
  public class Command : IExternalCommand
  {
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      TaskDialog.Show( App.Caption, App.Caption2 );
      return Result.Succeeded;
    }
  }
}
