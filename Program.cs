// Decompiled with JetBrains decompiler
// Type: MU_ToolKit.Program
// Assembly: Mu Shop Editor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9534AE4-E1B0-43D6-964B-EBF87DD823B7
// Assembly location: C:\Users\Rafael Mazzoni\Downloads\Modelos e Texturas\Projeto\EventItemBag-Editor\EventItemBag-Editor\EventItemBag-Editor.exe

using System;
using System.Windows.Forms;

namespace MU_ToolKit
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new ShopEditor());
    }
  }
}
