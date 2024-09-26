// Decompiled with JetBrains decompiler
// Type: MU_ToolKit.Structures
// Assembly: Mu Shop Editor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9534AE4-E1B0-43D6-964B-EBF87DD823B7
// Assembly location: C:\Users\Rafael Mazzoni\Downloads\Modelos e Texturas\Projeto\EventItemBag-Editor\EventItemBag-Editor\EventItemBag-Editor.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MU_ToolKit
{
  public class Structures
  {
    private bool CheckAndFixLine(string theLine, out string[] fixedLine)
    {
      string str1 = theLine.Replace(" ", string.Empty).Replace("\t", string.Empty);
      if (!str1.StartsWith("/") && !str1.StartsWith("end") && str1.Length > 0)
      {
        List<string> stringList = new List<string>();
        string str2 = theLine;
        int num = 0;
        List<int> intList = new List<int>();
        for (int index = 0; index < theLine.Length; ++index)
        {
          if (theLine[index] == '"')
            intList.Add(num);
          ++num;
        }
        for (int index = 0; index < intList.Count; index += 2)
        {
          try
          {
            string oldValue = theLine.Substring(intList[index], intList[index + 1] - intList[index]);
            string newValue = oldValue.Replace("\t", " ").Replace(" ", "^");
            str2 = str2.Replace(oldValue, newValue);
          }
          catch
          {
          }
        }
        string[] strArray = str2.Replace(" ", "\t").Split('\t');
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (strArray[index].Replace(" ", string.Empty).Length > 0)
            stringList.Add(strArray[index].Replace("^", " "));
        }
        fixedLine = stringList.ToArray();
        return true;
      }
      fixedLine = (string[]) null;
      return false;
    }

    public string[] FixLine(string theLine)
    {
      string empty = string.Empty;
      string str1 = theLine;
      string[] strArray1 = theLine.Split('"');
      if (strArray1.Length == 3)
      {
        string str2 = strArray1[0];
        string str3 = strArray1[1];
        string str4 = strArray1[2];
        string str5 = str3.Replace('\t', ' ').Replace(' ', '$');
        str1 = str2 + str5 + str4;
      }
      string[] strArray2 = str1.Replace(' ', '\t').Split('\t');
      List<string> stringList = new List<string>();
      foreach (string str6 in strArray2)
      {
        if (str6.Length > 0)
          stringList.Add(str6);
      }
      return stringList.ToArray();
    }

    public void ReadItemList(
      string fLocation,
      bool isEx700ItemList,
      ref List<Structures.c_Groups> L_Groups,
      ref List<Structures.UniItem> L_Swords,
      ref List<Structures.UniItem> L_Axes,
      ref List<Structures.UniItem> L_MacesScepters,
      ref List<Structures.UniItem> L_Spears,
      ref List<Structures.UniItem> L_BowsCrossBows,
      ref List<Structures.UniItem> L_Staffs,
      ref List<Structures.UniItem> L_Shields,
      ref List<Structures.UniItem> L_Helms,
      ref List<Structures.UniItem> L_Armors,
      ref List<Structures.UniItem> L_Pants,
      ref List<Structures.UniItem> L_Gloves,
      ref List<Structures.UniItem> L_Boots,
      ref List<Structures.UniItem> L_WingsSkillsSeedsOther,
      ref List<Structures.UniItem> L_Others1,
      ref List<Structures.UniItem> L_Others2,
      ref List<Structures.UniItem> L_Scrolls,
      ref string[,] ItemName,
      ref string[,] ItemSize)
    {
      try
      {
        int num = 0;
        foreach (string readAllLine in File.ReadAllLines(fLocation))
        {
          string[] fixedLine;
          if (this.CheckAndFixLine(readAllLine, out fixedLine))
          {
            if (fixedLine.Length == 1)
            {
              num = Convert.ToInt32(fixedLine[0]);
              switch (num)
              {
                case 0:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Swords"));
                  num = 0;
                  continue;
                case 1:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Axes"));
                  num = 1;
                  continue;
                case 2:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Maces/Scepters"));
                  num = 2;
                  continue;
                case 3:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Spears"));
                  num = 3;
                  continue;
                case 4:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Bow/CrossBow"));
                  num = 4;
                  continue;
                case 5:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Staffs"));
                  num = 5;
                  continue;
                case 6:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Shield"));
                  num = 6;
                  continue;
                case 7:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Helms"));
                  num = 7;
                  continue;
                case 8:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Armors"));
                  num = 8;
                  continue;
                case 9:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Pants"));
                  num = 9;
                  continue;
                case 10:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Gloves"));
                  num = 10;
                  continue;
                case 11:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Boots"));
                  num = 11;
                  continue;
                case 12:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Wings/Orbs/Spheres"));
                  num = 12;
                  continue;
                case 13:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Pets/Rings/Etc"));
                  num = 13;
                  continue;
                case 14:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Jewels/Misc"));
                  num = 14;
                  continue;
                case 15:
                  L_Groups.Add(new Structures.c_Groups(num.ToString(), "Scrolls"));
                  num = 15;
                  continue;
                default:
                  continue;
              }
            }
            else
            {
              int index = 0;
              if (isEx700ItemList)
                index = 3;
              string[] strArray = fixedLine;
              Structures.UniItem uniItem = new Structures.UniItem()
              {
                Group = num,
                Index = Convert.ToInt32(strArray[index]),
                Slot = Convert.ToInt32(strArray[index + 1]),
                Skill = Convert.ToInt32(strArray[index + 2]),
                X = Convert.ToInt32(strArray[index + 3]),
                Y = Convert.ToInt32(strArray[index + 4]),
                Option = Convert.ToInt32(strArray[index + 6]),
                Name = strArray[index + 8].Replace("\"", string.Empty)
              };
              switch (num)
              {
                case 0:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_Swords.Add(uniItem);
                  break;
                case 1:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_Axes.Add(uniItem);
                  break;
                case 2:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_MacesScepters.Add(uniItem);
                  break;
                case 3:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_Spears.Add(uniItem);
                  break;
                case 4:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_BowsCrossBows.Add(uniItem);
                  break;
                case 5:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 13]);
                  L_Staffs.Add(uniItem);
                  break;
                case 6:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Shields.Add(uniItem);
                  break;
                case 7:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Helms.Add(uniItem);
                  break;
                case 8:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Armors.Add(uniItem);
                  break;
                case 9:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Pants.Add(uniItem);
                  break;
                case 10:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Gloves.Add(uniItem);
                  break;
                case 11:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_Boots.Add(uniItem);
                  break;
                case 12:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 12]);
                  L_WingsSkillsSeedsOther.Add(uniItem);
                  break;
                case 13:
                  uniItem.Durability = (int) Convert.ToInt16(strArray[index + 11]);
                  L_Others1.Add(uniItem);
                  break;
                case 14:
                  uniItem.Durability = 0;
                  L_Others2.Add(uniItem);
                  break;
                case 15:
                  uniItem.Durability = 0;
                  L_Scrolls.Add(uniItem);
                  break;
              }
              if (ItemName != null)
                ItemName[uniItem.Group, uniItem.Index] = uniItem.Name;
              if (ItemSize != null)
                ItemSize[uniItem.Group, uniItem.Index] = uniItem.X.ToString() + "x" + (object) uniItem.Y;
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "[ReadItemList] ERROR");
        Application.Exit();
      }
    }

    public void Setc_LevelData(ref List<Structures.c_LevelData> c_LevelDatas)
    {
      c_LevelDatas.Add(new Structures.c_LevelData(0, "+0"));
      c_LevelDatas.Add(new Structures.c_LevelData(1, "+1"));
      c_LevelDatas.Add(new Structures.c_LevelData(2, "+2"));
      c_LevelDatas.Add(new Structures.c_LevelData(3, "+3"));
      c_LevelDatas.Add(new Structures.c_LevelData(4, "+4"));
      c_LevelDatas.Add(new Structures.c_LevelData(5, "+5"));
      c_LevelDatas.Add(new Structures.c_LevelData(6, "+6"));
      c_LevelDatas.Add(new Structures.c_LevelData(7, "+7"));
      c_LevelDatas.Add(new Structures.c_LevelData(8, "+8"));
      c_LevelDatas.Add(new Structures.c_LevelData(9, "+9"));
      c_LevelDatas.Add(new Structures.c_LevelData(10, "+10"));
      c_LevelDatas.Add(new Structures.c_LevelData(11, "+11"));
      c_LevelDatas.Add(new Structures.c_LevelData(12, "+12"));
      c_LevelDatas.Add(new Structures.c_LevelData(13, "+13"));
      c_LevelDatas.Add(new Structures.c_LevelData(14, "+14"));
      c_LevelDatas.Add(new Structures.c_LevelData(15, "+15"));
    }

    public void Setc_OptionData(ref List<Structures.c_OptionData> c_OptionDatas)
    {
      Structures.c_OptionData cOptionData = new Structures.c_OptionData()
      {
        ID = 0,
        Name = "+0"
      };
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 1;
      cOptionData.Name = "+4";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 2;
      cOptionData.Name = "+8";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 3;
      cOptionData.Name = "+12";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 4;
      cOptionData.Name = "+16";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 5;
      cOptionData.Name = "+20";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 6;
      cOptionData.Name = "+24";
      c_OptionDatas.Add(cOptionData);
      cOptionData.ID = 7;
      cOptionData.Name = "+28";
      c_OptionDatas.Add(cOptionData);
    }

    public class c_Groups
    {
      public int _GroupID;
      public string _GroupName;

      public int Group
      {
        get => this._GroupID;
        set => this._GroupID = value;
      }

      public string GroupName
      {
        get => this._GroupName;
        set => this._GroupName = value;
      }

      public c_Groups(string GroupID, string GroupName)
      {
        int result = -1;
        int.TryParse(GroupID, out result);
        this._GroupID = result;
        this._GroupName = GroupName;
      }
    }

    public class c_LevelData
    {
      public int _LevelID;
      public string _LevelName;

      public int ID
      {
        get => this._LevelID;
        set => this._LevelID = value;
      }

      public string Name
      {
        get => this._LevelName;
        set => this._LevelName = value;
      }

      public c_LevelData(int ID, string Name)
      {
        this._LevelID = ID;
        this._LevelName = Name;
      }
    }

    public struct c_OptionData
    {
      public int ID { get; set; }

      public string Name { get; set; }
    }

    public class CustomPictureBox : PictureBox
    {
      private int _MSBType;
      private Color colorBorder = Color.Transparent;

      public Color BorderColor
      {
        get => this.colorBorder;
        set => this.colorBorder = value;
      }

      public int MSBType
      {
        get => this._MSBType;
        set => this._MSBType = value;
      }

      public CustomPictureBox() => this.SetStyle(ControlStyles.UserPaint, true);

      protected override void OnPaint(PaintEventArgs e)
      {
        base.OnPaint(e);
        e.Graphics.DrawRectangle(new Pen((Brush) new SolidBrush(this.colorBorder), 4f), e.ClipRectangle);
      }
    }

    public class CustomToolTip : ToolTip
    {
      private int _sizeX = 230;
      private int _sizeY = 140;

      public int sizeX
      {
        get => this._sizeX;
        set => this._sizeX = value;
      }

      public int sizeY
      {
        get => this._sizeY;
        set => this._sizeY = value;
      }

      public CustomToolTip()
      {
        this.OwnerDraw = true;
        this.Popup += new PopupEventHandler(this.OnPopup);
        this.Draw += new DrawToolTipEventHandler(this.OnDraw);
      }

      private void OnDraw(object sender, DrawToolTipEventArgs e)
      {
        Graphics graphics1 = e.Graphics;
        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.Silver, Color.Goldenrod, 50f);
        graphics1.FillRectangle((Brush) linearGradientBrush, e.Bounds);
        Graphics graphics2 = graphics1;
        Pen pen = new Pen(Brushes.Azure, 1f);
        Rectangle bounds1 = e.Bounds;
        int x1 = bounds1.X;
        bounds1 = e.Bounds;
        int y1 = bounds1.Y;
        bounds1 = e.Bounds;
        int width = bounds1.Width - 1;
        bounds1 = e.Bounds;
        int height = bounds1.Height - 1;
        Rectangle rect = new Rectangle(x1, y1, width, height);
        graphics2.DrawRectangle(pen, rect);
        Graphics graphics3 = graphics1;
        string toolTipText1 = e.ToolTipText;
        Font font1 = new Font(e.Font, FontStyle.Bold);
        Brush silver = Brushes.Silver;
        Rectangle bounds2 = e.Bounds;
        double x2 = (double) (bounds2.X + 6);
        bounds2 = e.Bounds;
        double y2 = (double) (bounds2.Y + 6);
        PointF point1 = new PointF((float) x2, (float) y2);
        graphics3.DrawString(toolTipText1, font1, silver, point1);
        Graphics graphics4 = graphics1;
        string toolTipText2 = e.ToolTipText;
        Font font2 = new Font(e.Font, FontStyle.Bold);
        Brush black = Brushes.Black;
        Rectangle bounds3 = e.Bounds;
        double x3 = (double) (bounds3.X + 5);
        bounds3 = e.Bounds;
        double y3 = (double) (bounds3.Y + 5);
        PointF point2 = new PointF((float) x3, (float) y3);
        graphics4.DrawString(toolTipText2, font2, black, point2);
        linearGradientBrush.Dispose();
      }

      private void OnPopup(object sender, PopupEventArgs e) => e.ToolTipSize = new Size(this._sizeX, this._sizeY);
    }

    public struct ShopItem
    {
      public int ShopLocX;
      public int ShopLocY;
      public string UniqName;
      public string TempName;
      public int Group;
      public int Index;

      public byte Level { get; set; }

      public byte Level2 { get; set; }

      public byte Durablity { get; set; }

      public bool Skill { get; set; }

      public bool Luck { get; set; }

      public byte Option { get; set; }

      public byte Excellent { get; set; }
    }

    public struct ShopItem2
    {
      public int ShopLocX;
      public int ShopLocY;
      public string UniqName;
      public string TempName;
      public int Group;
      public int Index;

      public byte Level { get; set; }

      public byte Level2 { get; set; }

      public byte Durablity { get; set; }

      public bool Skill { get; set; }

      public bool Luck { get; set; }

      public byte Option { get; set; }

      public byte Excellent { get; set; }

      public byte SetOpt { get; set; }

      public byte Sock { get; set; }
    }

    public struct UniItem
    {
      public int Group { get; set; }

      public int Index { get; set; }

      public int Slot { get; set; }

      public int Skill { get; set; }

      public int X { get; set; }

      public int Y { get; set; }

      public int Option { get; set; }

      public string Name { get; set; }

      public int Durability { get; set; }
    }
  }
}
