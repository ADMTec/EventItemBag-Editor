// Decompiled with JetBrains decompiler
// Type: MU_ToolKit.ShopEditor
// Assembly: Mu Shop Editor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9534AE4-E1B0-43D6-964B-EBF87DD823B7
// Assembly location: C:\Users\Rafael Mazzoni\Downloads\Modelos e Texturas\Projeto\EventItemBag-Editor\EventItemBag-Editor\EventItemBag-Editor.exe

using Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MU_ToolKit
{
  public class ShopEditor : Form
  {
    private Button button_Add;
    private Button button_Update;
    private List<Structures.c_LevelData> c_LevelDatas = new List<Structures.c_LevelData>();
    private List<Structures.c_OptionData> c_OptionDatas = new List<Structures.c_OptionData>();
    private CheckBox checkBox_DurLock;
    public CheckBox checkBox_ExcOpt1;
    public CheckBox checkBox_ExcOpt2;
    public CheckBox checkBox_ExcOpt3;
    public CheckBox checkBox_ExcOpt4;
    public CheckBox checkBox_ExcOpt5;
    public CheckBox checkBox_ExcOpt6;
    private CheckBox checkBox_FO;
    private CheckBox checkBox_Luck;
    private CheckBox checkBox_Skill;
    private IContainer components;
    private bool DontWork;
    private ToolStripMenuItem fileToolStripMenuItem;
    private GroupBox groupBox_NewItem_ExcOpt;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private int isEx700ItemList;
    private string[,] ItemName = new string[16, 513];
    private string[,] ItemSize = new string[16, 513];
    private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();
    private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();
    private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();
    private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();
    private Label label_FileName;
    private Label label_Size;
    private int LastSelectedItemIndex;
    private Structures.CustomPictureBox LastSelectetItem = new Structures.CustomPictureBox();
    private ListBox listBox_Group;
    private ListBox listBox_Index;
    private ListBox listBox_Level;
    private ListBox listBox_Option;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem newToolStripMenuItem;
    private NumericUpDown numericUpDown_Durability;
    private bool[,] OccupiedBoxes = new bool[16, 9];
    private int OldDurValue;
    private ToolStripMenuItem openToolStripMenuItem;
    private PictureBox pictureBox_ItemPreview;
    private RadioButton radioButton_ExcArmor;
    private RadioButton radioButton_ExcWeapon;
    private RadioButton radioButton_ExcWings;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private Structures.ShopItem SelectedSI;
    private Structures.ShopItem[,] ShopItems = new Structures.ShopItem[16, 9];
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Structures strct = new Structures();
    private string RutaArchivo = "";
    private Button button5;
    private ListView listView1;
    private ColumnHeader Group;
    private ColumnHeader Index;
    private GroupBox groupBox4;
    private ListBox listBox_maxlvl;
    private ColumnHeader Item;
    private ColumnHeader MinLvl;
    private ColumnHeader MaxLvl;
    private ColumnHeader Skill;
    private ColumnHeader Luck;
    private ColumnHeader Opt;
    private ColumnHeader Exe;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private ListView listView2;
    private ColumnHeader Item2;
    private ColumnHeader Group2;
    private ColumnHeader Index2;
    private ColumnHeader MinLvl2;
    private ColumnHeader MaxLvl2;
    private ColumnHeader Skill2;
    private ColumnHeader Luck2;
    private ColumnHeader Opt2;
    private ColumnHeader Exe2;
    private ColumnHeader SetOpt2;
    private ColumnHeader Sock2;
    private Button button6;
    private TextBox textBox0;
    private string OpenedFile = "0";
    private GroupBox groupBox5;
    private ListBox listBox_SetOption;
    private GroupBox groupBox6;
    private ListBox listBox_Socket;
    private GroupBox groupBox7;
    private GroupBox groupBox8;
    private string Section = "0";

    public ShopEditor() => this.InitializeComponent();

    private void button_Add_Click(object sender, EventArgs e)
    {
      string empty = string.Empty;
      Structures.ShopItem shopItem = new Structures.ShopItem()
      {
        Group = Convert.ToInt32(this.listBox_Group.SelectedValue),
        Index = Convert.ToInt32(this.listBox_Index.SelectedValue),
        Level = Convert.ToByte(this.listBox_Level.SelectedValue),
        Level2 = Convert.ToByte(this.listBox_maxlvl.SelectedValue),
        Option = Convert.ToByte(this.listBox_Option.SelectedValue),
        Skill = this.checkBox_Skill.Checked,
        Luck = this.checkBox_Luck.Checked,
        Durablity = Convert.ToByte(this.numericUpDown_Durability.Value),
        Excellent = this.GetExcVal()
      };
      string str = string.Empty + (shopItem.Excellent > (byte) 0 ? "Excellent " : "") + this.listBox_Index.Text + "+" + (object) shopItem.Level + this.listBox_Option.Text + (shopItem.Skill ? "+Skill" : "") + (shopItem.Luck ? (object) "+Luck" : (object) "") + "\n\nDurability: " + (object) shopItem.Durablity;
      if (shopItem.Excellent > (byte) 0)
        str + "\n\nExcellent Options:\n" + (this.checkBox_ExcOpt1.Checked ? this.checkBox_ExcOpt1.Text + "\n" : "") + (this.checkBox_ExcOpt2.Checked ? this.checkBox_ExcOpt2.Text + "\n" : "") + (this.checkBox_ExcOpt3.Checked ? this.checkBox_ExcOpt3.Text + "\n" : "") + (this.checkBox_ExcOpt4.Checked ? this.checkBox_ExcOpt4.Text + "\n" : "") + (this.checkBox_ExcOpt5.Checked ? this.checkBox_ExcOpt5.Text + "\n" : "") + (this.checkBox_ExcOpt6.Checked ? this.checkBox_ExcOpt6.Text : "");
      this.listView1.Items.Add(new ListViewItem(this.listBox_Index.Text)
      {
        SubItems = {
          shopItem.Group.ToString(),
          shopItem.Index.ToString(),
          shopItem.Level.ToString(),
          this.listBox_maxlvl.SelectedIndex.ToString(),
          Convert.ToInt32(shopItem.Skill).ToString(),
          Convert.ToInt32(shopItem.Luck).ToString(),
          shopItem.Option.ToString(),
          shopItem.Excellent.ToString()
        }
      });
    }

    private void button_Update_Click(object sender, EventArgs e)
    {
      if (this.Section == "1")
      {
        this.listView1.FocusedItem.SubItems[1].Text = Convert.ToString(this.listBox_Group.SelectedValue);
        this.listView1.FocusedItem.SubItems[2].Text = Convert.ToString(this.listBox_Index.SelectedValue);
        this.listView1.FocusedItem.SubItems[3].Text = Convert.ToString(this.listBox_Level.SelectedValue);
        this.listView1.FocusedItem.SubItems[4].Text = Convert.ToString(this.listBox_maxlvl.SelectedIndex);
        this.listView1.FocusedItem.SubItems[5].Text = Convert.ToString(Convert.ToInt16(this.checkBox_Skill.Checked));
        this.listView1.FocusedItem.SubItems[6].Text = Convert.ToString(Convert.ToInt16(this.checkBox_Luck.Checked));
        this.listView1.FocusedItem.SubItems[7].Text = Convert.ToString(this.listBox_Option.SelectedValue);
        this.listView1.FocusedItem.SubItems[8].Text = Convert.ToString(this.GetExcVal());
      }
      else
      {
        if (!(this.Section == "2"))
          return;
        this.listView2.FocusedItem.SubItems[1].Text = Convert.ToString(this.listBox_Group.SelectedValue);
        this.listView2.FocusedItem.SubItems[2].Text = Convert.ToString(this.listBox_Index.SelectedValue);
        this.listView2.FocusedItem.SubItems[3].Text = Convert.ToString(this.listBox_Level.SelectedValue);
        this.listView2.FocusedItem.SubItems[4].Text = Convert.ToString(this.listBox_maxlvl.SelectedIndex);
        this.listView2.FocusedItem.SubItems[5].Text = Convert.ToString(Convert.ToInt16(this.checkBox_Skill.Checked));
        this.listView2.FocusedItem.SubItems[6].Text = Convert.ToString(Convert.ToInt16(this.checkBox_Luck.Checked));
        this.listView2.FocusedItem.SubItems[7].Text = Convert.ToString(this.listBox_Option.SelectedValue);
        this.listView2.FocusedItem.SubItems[8].Text = Convert.ToString(this.GetExcVal());
        this.listView2.FocusedItem.SubItems[9].Text = this.listBox_SetOption.Text;
        this.listView2.FocusedItem.SubItems[10].Text = Convert.ToString(this.listBox_Socket.SelectedIndex);
      }
    }

    private void ChangeOccupid(int startX, int startY, int LengthX, int LengthY, bool state)
    {
      for (int index1 = 0; index1 < LengthY; ++index1)
      {
        for (int index2 = 0; index2 < LengthX; ++index2)
          this.OccupiedBoxes[index1 + startY, index2 + startX] = state;
      }
    }

    private void checkBox_FO_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox_FO.Checked)
        return;
      this.checkBox_ExcOpt1.Checked = true;
      this.checkBox_ExcOpt2.Checked = true;
      this.checkBox_ExcOpt3.Checked = true;
      this.checkBox_ExcOpt4.Checked = true;
      this.checkBox_ExcOpt5.Checked = true;
      this.checkBox_ExcOpt6.Checked = true;
      this.listBox_Level.SelectedIndex = 15;
      this.listBox_Option.SelectedValue = (object) 7;
      this.checkBox_Luck.Checked = true;
      this.checkBox_FO.Checked = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private byte GetExcVal()
    {
      int num1 = 0;
      int num2 = this.checkBox_ExcOpt1.Checked ? num1 + 1 : num1;
      int num3 = this.checkBox_ExcOpt2.Checked ? num2 + 2 : num2;
      int num4 = this.checkBox_ExcOpt3.Checked ? num3 + 4 : num3;
      int num5 = this.checkBox_ExcOpt4.Checked ? num4 + 8 : num4;
      int num6 = this.checkBox_ExcOpt5.Checked ? num5 + 16 : num5;
      return Convert.ToByte(this.checkBox_ExcOpt6.Checked ? num6 + 32 : num6);
    }

    private bool GetFirstFreeBox(int neededX, int neededY, ref int acceptedX, ref int acceptedY)
    {
      for (int index1 = 1; index1 <= 15; ++index1)
      {
        for (int index2 = 1; index2 <= 8; ++index2)
        {
          if (!this.OccupiedBoxes[index1, index2])
          {
            bool flag = false;
            for (int index3 = 0; index3 < neededY; ++index3)
            {
              for (int index4 = 0; index4 < neededX; ++index4)
              {
                if (!flag)
                {
                  if (index1 + index3 <= 15 & index2 + index4 <= 8)
                  {
                    if (this.OccupiedBoxes[index1 + index3, index2 + index4])
                      flag = true;
                  }
                  else
                    flag = true;
                }
              }
            }
            if (!flag)
            {
              acceptedX = index2;
              acceptedY = index1;
              return true;
            }
          }
        }
      }
      return false;
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ShopEditor));
      this.listBox_Group = new ListBox();
      this.listBox_Index = new ListBox();
      this.listBox_Level = new ListBox();
      this.listBox_Option = new ListBox();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.groupBox3 = new GroupBox();
      this.checkBox_DurLock = new CheckBox();
      this.numericUpDown_Durability = new NumericUpDown();
      this.checkBox_Luck = new CheckBox();
      this.checkBox_Skill = new CheckBox();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new ToolStripMenuItem();
      this.button_Add = new Button();
      this.groupBox_NewItem_ExcOpt = new GroupBox();
      this.radioButton_ExcWings = new RadioButton();
      this.radioButton_ExcArmor = new RadioButton();
      this.radioButton_ExcWeapon = new RadioButton();
      this.checkBox_ExcOpt6 = new CheckBox();
      this.checkBox_ExcOpt5 = new CheckBox();
      this.checkBox_ExcOpt4 = new CheckBox();
      this.checkBox_ExcOpt3 = new CheckBox();
      this.checkBox_ExcOpt2 = new CheckBox();
      this.checkBox_ExcOpt1 = new CheckBox();
      this.label_Size = new Label();
      this.button_Update = new Button();
      this.checkBox_FO = new CheckBox();
      this.label_FileName = new Label();
      this.pictureBox_ItemPreview = new PictureBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.listView1 = new ListView();
      this.Item = new ColumnHeader();
      this.Group = new ColumnHeader();
      this.Index = new ColumnHeader();
      this.MinLvl = new ColumnHeader();
      this.MaxLvl = new ColumnHeader();
      this.Skill = new ColumnHeader();
      this.Luck = new ColumnHeader();
      this.Opt = new ColumnHeader();
      this.Exe = new ColumnHeader();
      this.groupBox4 = new GroupBox();
      this.listBox_maxlvl = new ListBox();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.textBox6 = new TextBox();
      this.textBox7 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.listView2 = new ListView();
      this.Item2 = new ColumnHeader();
      this.Group2 = new ColumnHeader();
      this.Index2 = new ColumnHeader();
      this.MinLvl2 = new ColumnHeader();
      this.MaxLvl2 = new ColumnHeader();
      this.Skill2 = new ColumnHeader();
      this.Luck2 = new ColumnHeader();
      this.Opt2 = new ColumnHeader();
      this.Exe2 = new ColumnHeader();
      this.SetOpt2 = new ColumnHeader();
      this.Sock2 = new ColumnHeader();
      this.button6 = new Button();
      this.textBox0 = new TextBox();
      this.groupBox5 = new GroupBox();
      this.listBox_SetOption = new ListBox();
      this.groupBox6 = new GroupBox();
      this.listBox_Socket = new ListBox();
      this.groupBox7 = new GroupBox();
      this.groupBox8 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.numericUpDown_Durability.BeginInit();
      this.menuStrip1.SuspendLayout();
      this.groupBox_NewItem_ExcOpt.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_ItemPreview).BeginInit();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.SuspendLayout();
      this.listBox_Group.FormattingEnabled = true;
      this.listBox_Group.Location = new Point(12, 38);
      this.listBox_Group.Name = "listBox_Group";
      this.listBox_Group.Size = new Size(158, 134);
      this.listBox_Group.TabIndex = 0;
      this.listBox_Group.SelectedIndexChanged += new EventHandler(this.listBox_Group_SelectedIndexChanged);
      this.listBox_Index.FormattingEnabled = true;
      this.listBox_Index.Location = new Point(176, 38);
      this.listBox_Index.Name = "listBox_Index";
      this.listBox_Index.Size = new Size(213, 134);
      this.listBox_Index.TabIndex = 1;
      this.listBox_Index.SelectedIndexChanged += new EventHandler(this.listBox_Index_SelectedIndexChanged);
      this.listBox_Level.FormattingEnabled = true;
      this.listBox_Level.Location = new Point(7, 14);
      this.listBox_Level.Name = "listBox_Level";
      this.listBox_Level.Size = new Size(41, 186);
      this.listBox_Level.TabIndex = 2;
      this.listBox_Level.SelectedIndexChanged += new EventHandler(this.listBox_Level_SelectedIndexChanged);
      this.listBox_Option.FormattingEnabled = true;
      this.listBox_Option.Location = new Point(5, 14);
      this.listBox_Option.Name = "listBox_Option";
      this.listBox_Option.Size = new Size(44, 95);
      this.listBox_Option.TabIndex = 3;
      this.groupBox1.Controls.Add((Control) this.listBox_Level);
      this.groupBox1.Location = new Point(12, 180);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(55, 215);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "MinLvl";
      this.groupBox2.Controls.Add((Control) this.listBox_Option);
      this.groupBox2.Location = new Point(132, 260);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(54, 120);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Option";
      this.groupBox3.Controls.Add((Control) this.checkBox_DurLock);
      this.groupBox3.Controls.Add((Control) this.numericUpDown_Durability);
      this.groupBox3.Location = new Point(157, 216);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(106, 42);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Durability";
      this.checkBox_DurLock.AutoSize = true;
      this.checkBox_DurLock.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_DurLock.Location = new Point(54, 19);
      this.checkBox_DurLock.Name = "checkBox_DurLock";
      this.checkBox_DurLock.Size = new Size(50, 17);
      this.checkBox_DurLock.TabIndex = 5;
      this.checkBox_DurLock.Text = "Lock";
      this.checkBox_DurLock.UseVisualStyleBackColor = true;
      this.numericUpDown_Durability.Location = new Point(6, 18);
      this.numericUpDown_Durability.Name = "numericUpDown_Durability";
      this.numericUpDown_Durability.Size = new Size(44, 20);
      this.numericUpDown_Durability.TabIndex = 4;
      this.numericUpDown_Durability.ValueChanged += new EventHandler(this.numericUpDown_Durability_ValueChanged);
      this.checkBox_Luck.AutoSize = true;
      this.checkBox_Luck.Location = new Point(19, 410);
      this.checkBox_Luck.Name = "checkBox_Luck";
      this.checkBox_Luck.Size = new Size(50, 17);
      this.checkBox_Luck.TabIndex = 6;
      this.checkBox_Luck.Text = "Luck";
      this.checkBox_Luck.UseVisualStyleBackColor = true;
      this.checkBox_Skill.AutoSize = true;
      this.checkBox_Skill.Location = new Point(75, 410);
      this.checkBox_Skill.Name = "checkBox_Skill";
      this.checkBox_Skill.Size = new Size(45, 17);
      this.checkBox_Skill.TabIndex = 7;
      this.checkBox_Skill.Text = "Skill";
      this.checkBox_Skill.UseVisualStyleBackColor = true;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.fileToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(652, 24);
      this.menuStrip1.TabIndex = 13;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.Visible = false;
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.newToolStripMenuItem,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.saveAsToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new Size(114, 22);
      this.newToolStripMenuItem.Text = "New";
      this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new Size(114, 22);
      this.openToolStripMenuItem.Text = "Open";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new Size(114, 22);
      this.saveAsToolStripMenuItem.Text = "Save As";
      this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
      this.button_Add.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.button_Add.Location = new Point(12, 499);
      this.button_Add.Name = "button_Add";
      this.button_Add.Size = new Size(83, 30);
      this.button_Add.TabIndex = 22;
      this.button_Add.Text = "Add Section 1";
      this.button_Add.UseVisualStyleBackColor = true;
      this.button_Add.Click += new EventHandler(this.button_Add_Click);
      this.groupBox_NewItem_ExcOpt.BackColor = Color.Transparent;
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.radioButton_ExcWings);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.radioButton_ExcArmor);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.radioButton_ExcWeapon);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt6);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt5);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt4);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt3);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt2);
      this.groupBox_NewItem_ExcOpt.Controls.Add((Control) this.checkBox_ExcOpt1);
      this.groupBox_NewItem_ExcOpt.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.groupBox_NewItem_ExcOpt.ForeColor = SystemColors.ControlText;
      this.groupBox_NewItem_ExcOpt.Location = new Point(197, 279);
      this.groupBox_NewItem_ExcOpt.Name = "groupBox_NewItem_ExcOpt";
      this.groupBox_NewItem_ExcOpt.Size = new Size(198, 151);
      this.groupBox_NewItem_ExcOpt.TabIndex = 18;
      this.groupBox_NewItem_ExcOpt.TabStop = false;
      this.groupBox_NewItem_ExcOpt.Text = "Excellent Options";
      this.radioButton_ExcWings.AutoSize = true;
      this.radioButton_ExcWings.Location = new Point(136, 18);
      this.radioButton_ExcWings.Name = "radioButton_ExcWings";
      this.radioButton_ExcWings.Size = new Size(55, 17);
      this.radioButton_ExcWings.TabIndex = 14;
      this.radioButton_ExcWings.Text = "Wings";
      this.radioButton_ExcWings.UseVisualStyleBackColor = true;
      this.radioButton_ExcWings.CheckedChanged += new EventHandler(this.radioButton_Exc_CheckedChanged);
      this.radioButton_ExcArmor.AutoSize = true;
      this.radioButton_ExcArmor.Location = new Point(78, 18);
      this.radioButton_ExcArmor.Name = "radioButton_ExcArmor";
      this.radioButton_ExcArmor.Size = new Size(52, 17);
      this.radioButton_ExcArmor.TabIndex = 13;
      this.radioButton_ExcArmor.Text = "Armor";
      this.radioButton_ExcArmor.UseVisualStyleBackColor = true;
      this.radioButton_ExcArmor.CheckedChanged += new EventHandler(this.radioButton_Exc_CheckedChanged);
      this.radioButton_ExcWeapon.AutoSize = true;
      this.radioButton_ExcWeapon.Location = new Point(6, 18);
      this.radioButton_ExcWeapon.Name = "radioButton_ExcWeapon";
      this.radioButton_ExcWeapon.Size = new Size(66, 17);
      this.radioButton_ExcWeapon.TabIndex = 12;
      this.radioButton_ExcWeapon.Text = "Weapon";
      this.radioButton_ExcWeapon.UseVisualStyleBackColor = true;
      this.radioButton_ExcWeapon.CheckedChanged += new EventHandler(this.radioButton_Exc_CheckedChanged);
      this.checkBox_ExcOpt6.AutoSize = true;
      this.checkBox_ExcOpt6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt6.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt6.Location = new Point(6, 133);
      this.checkBox_ExcOpt6.Name = "checkBox_ExcOpt6";
      this.checkBox_ExcOpt6.Size = new Size(80, 17);
      this.checkBox_ExcOpt6.TabIndex = 20;
      this.checkBox_ExcOpt6.Text = "checkBox6";
      this.checkBox_ExcOpt6.UseVisualStyleBackColor = true;
      this.checkBox_ExcOpt5.AutoSize = true;
      this.checkBox_ExcOpt5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt5.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt5.Location = new Point(6, 115);
      this.checkBox_ExcOpt5.Name = "checkBox_ExcOpt5";
      this.checkBox_ExcOpt5.Size = new Size(80, 17);
      this.checkBox_ExcOpt5.TabIndex = 19;
      this.checkBox_ExcOpt5.Text = "checkBox5";
      this.checkBox_ExcOpt5.UseVisualStyleBackColor = true;
      this.checkBox_ExcOpt4.AutoSize = true;
      this.checkBox_ExcOpt4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt4.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt4.Location = new Point(6, 97);
      this.checkBox_ExcOpt4.Name = "checkBox_ExcOpt4";
      this.checkBox_ExcOpt4.Size = new Size(80, 17);
      this.checkBox_ExcOpt4.TabIndex = 18;
      this.checkBox_ExcOpt4.Text = "checkBox4";
      this.checkBox_ExcOpt4.UseVisualStyleBackColor = true;
      this.checkBox_ExcOpt3.AutoSize = true;
      this.checkBox_ExcOpt3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt3.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt3.Location = new Point(6, 78);
      this.checkBox_ExcOpt3.Name = "checkBox_ExcOpt3";
      this.checkBox_ExcOpt3.Size = new Size(80, 17);
      this.checkBox_ExcOpt3.TabIndex = 17;
      this.checkBox_ExcOpt3.Text = "checkBox3";
      this.checkBox_ExcOpt3.UseVisualStyleBackColor = true;
      this.checkBox_ExcOpt2.AutoSize = true;
      this.checkBox_ExcOpt2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt2.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt2.Location = new Point(6, 60);
      this.checkBox_ExcOpt2.Name = "checkBox_ExcOpt2";
      this.checkBox_ExcOpt2.Size = new Size(80, 17);
      this.checkBox_ExcOpt2.TabIndex = 16;
      this.checkBox_ExcOpt2.Text = "checkBox2";
      this.checkBox_ExcOpt2.UseVisualStyleBackColor = true;
      this.checkBox_ExcOpt1.AutoSize = true;
      this.checkBox_ExcOpt1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.checkBox_ExcOpt1.ForeColor = SystemColors.ControlText;
      this.checkBox_ExcOpt1.Location = new Point(6, 42);
      this.checkBox_ExcOpt1.Name = "checkBox_ExcOpt1";
      this.checkBox_ExcOpt1.Size = new Size(80, 17);
      this.checkBox_ExcOpt1.TabIndex = 15;
      this.checkBox_ExcOpt1.Text = "checkBox1";
      this.checkBox_ExcOpt1.UseVisualStyleBackColor = true;
      this.label_Size.AutoSize = true;
      this.label_Size.BorderStyle = BorderStyle.FixedSingle;
      this.label_Size.Location = new Point(363, 260);
      this.label_Size.Name = "label_Size";
      this.label_Size.Size = new Size(26, 15);
      this.label_Size.TabIndex = 19;
      this.label_Size.Text = "1x1";
      this.button_Update.Enabled = false;
      this.button_Update.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.button_Update.Location = new Point(12, 433);
      this.button_Update.Name = "button_Update";
      this.button_Update.Size = new Size(78, 30);
      this.button_Update.TabIndex = 21;
      this.button_Update.Text = "Update Item";
      this.button_Update.UseVisualStyleBackColor = true;
      this.button_Update.Click += new EventHandler(this.button_Update_Click);
      this.checkBox_FO.AutoSize = true;
      this.checkBox_FO.Location = new Point(157, 180);
      this.checkBox_FO.Name = "checkBox_FO";
      this.checkBox_FO.Size = new Size(92, 30);
      this.checkBox_FO.TabIndex = 11;
      this.checkBox_FO.Text = "Full Options\r\n+15+28+Luck";
      this.checkBox_FO.UseVisualStyleBackColor = true;
      this.checkBox_FO.CheckedChanged += new EventHandler(this.checkBox_FO_CheckedChanged);
      this.label_FileName.BackColor = Color.Black;
      this.label_FileName.ForeColor = Color.White;
      this.label_FileName.Location = new Point(277, 5);
      this.label_FileName.Name = "label_FileName";
      this.label_FileName.Size = new Size(208, 15);
      this.label_FileName.TabIndex = 23;
      this.label_FileName.TextAlign = ContentAlignment.TopCenter;
      this.pictureBox_ItemPreview.BackColor = Color.FromArgb(37, 47, 1);
      this.pictureBox_ItemPreview.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox_ItemPreview.Location = new Point(269, 180);
      this.pictureBox_ItemPreview.Name = "pictureBox_ItemPreview";
      this.pictureBox_ItemPreview.Size = new Size(120, 94);
      this.pictureBox_ItemPreview.TabIndex = 14;
      this.pictureBox_ItemPreview.TabStop = false;
      this.button1.BackgroundImage = (Image) componentResourceManager.GetObject("button1.BackgroundImage");
      this.button1.BackgroundImageLayout = ImageLayout.Stretch;
      this.button1.Location = new Point(5, 5);
      this.button1.Margin = new Padding(0);
      this.button1.Name = "button1";
      this.button1.Size = new Size(30, 30);
      this.button1.TabIndex = 24;
      this.button1.TextImageRelation = TextImageRelation.ImageAboveText;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.BackgroundImage = (Image) componentResourceManager.GetObject("button2.BackgroundImage");
      this.button2.BackgroundImageLayout = ImageLayout.Stretch;
      this.button2.Location = new Point(71, 5);
      this.button2.Name = "button2";
      this.button2.Size = new Size(30, 30);
      this.button2.TabIndex = 26;
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.BackgroundImage = (Image) componentResourceManager.GetObject("button3.BackgroundImage");
      this.button3.BackgroundImageLayout = ImageLayout.Stretch;
      this.button3.Location = new Point(104, 5);
      this.button3.Name = "button3";
      this.button3.Size = new Size(30, 30);
      this.button3.TabIndex = 27;
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Visible = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button4.BackgroundImage = (Image) componentResourceManager.GetObject("button4.BackgroundImage");
      this.button4.BackgroundImageLayout = ImageLayout.Stretch;
      this.button4.Location = new Point(38, 5);
      this.button4.Name = "button4";
      this.button4.Size = new Size(30, 30);
      this.button4.TabIndex = 25;
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button5.Location = new Point(164, 9);
      this.button5.Name = "button5";
      this.button5.Size = new Size(107, 23);
      this.button5.TabIndex = 28;
      this.button5.Text = "www.gamesbit.net";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.listView1.Columns.AddRange(new ColumnHeader[9]
      {
        this.Item,
        this.Group,
        this.Index,
        this.MinLvl,
        this.MaxLvl,
        this.Skill,
        this.Luck,
        this.Opt,
        this.Exe
      });
      this.listView1.Location = new Point(6, 17);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(567, 238);
      this.listView1.TabIndex = 29;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      this.listView1.KeyPress += new KeyPressEventHandler(this.listView1_KeyPress_1);
      this.Item.Text = "Item";
      this.Item.Width = 108;
      this.Group.Text = "Group";
      this.Group.Width = 42;
      this.Index.Text = "Index";
      this.Index.Width = 40;
      this.MinLvl.Text = "MinLvl";
      this.MaxLvl.Text = "MaxLvl";
      this.Skill.Text = "Skill";
      this.Luck.Text = "Luck";
      this.Opt.Text = "Opt";
      this.Exe.Text = "Exe";
      this.groupBox4.Controls.Add((Control) this.listBox_maxlvl);
      this.groupBox4.Location = new Point(75, 180);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(55, 215);
      this.groupBox4.TabIndex = 30;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "MaxLvl";
      this.listBox_maxlvl.FormattingEnabled = true;
      this.listBox_maxlvl.Items.AddRange(new object[16]
      {
        (object) "+0",
        (object) "+1",
        (object) "+2",
        (object) "+3",
        (object) "+4",
        (object) "+5",
        (object) "+6",
        (object) "+7",
        (object) "+8",
        (object) "+9",
        (object) "+10",
        (object) "+11",
        (object) "+12",
        (object) "+13",
        (object) "+14",
        (object) "+15"
      });
      this.listBox_maxlvl.Location = new Point(6, 14);
      this.listBox_maxlvl.Name = "listBox_maxlvl";
      this.listBox_maxlvl.Size = new Size(41, 186);
      this.listBox_maxlvl.TabIndex = 0;
      this.textBox1.Location = new Point(277, 15);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 31;
      this.textBox1.Visible = false;
      this.textBox2.Location = new Point(529, 49);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(60, 20);
      this.textBox2.TabIndex = 32;
      this.textBox3.Location = new Point(601, 49);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(60, 20);
      this.textBox3.TabIndex = 33;
      this.textBox4.Location = new Point(667, 49);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(60, 20);
      this.textBox4.TabIndex = 34;
      this.textBox5.Location = new Point(733, 49);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(88, 20);
      this.textBox5.TabIndex = 35;
      this.textBox6.Location = new Point(834, 49);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size(60, 20);
      this.textBox6.TabIndex = 36;
      this.textBox7.Location = new Point(909, 49);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(50, 20);
      this.textBox7.TabIndex = 37;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(423, 33);
      this.label1.Name = "label1";
      this.label1.Size = new Size(63, 13);
      this.label1.TabIndex = 38;
      this.label1.Text = "EventName";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(531, 33);
      this.label2.Name = "label2";
      this.label2.Size = new Size(49, 13);
      this.label2.TabIndex = 39;
      this.label2.Text = "DropZen";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(601, 33);
      this.label3.Name = "label3";
      this.label3.Size = new Size(53, 13);
      this.label3.TabIndex = 40;
      this.label3.Text = "DropRate";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(669, 33);
      this.label4.Name = "label4";
      this.label4.Size = new Size(58, 13);
      this.label4.TabIndex = 41;
      this.label4.Text = "DropCount";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(732, 33);
      this.label5.Name = "label5";
      this.label5.Size = new Size(89, 13);
      this.label5.TabIndex = 42;
      this.label5.Text = "SetItemDropRate";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(831, 33);
      this.label6.Name = "label6";
      this.label6.Size = new Size(74, 13);
      this.label6.TabIndex = 43;
      this.label6.Text = "ItemDropType";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(908, 33);
      this.label7.Name = "label7";
      this.label7.Size = new Size(52, 13);
      this.label7.TabIndex = 44;
      this.label7.Text = "Fireworks";
      this.label7.Click += new EventHandler(this.label7_Click);
      this.listView2.Columns.AddRange(new ColumnHeader[11]
      {
        this.Item2,
        this.Group2,
        this.Index2,
        this.MinLvl2,
        this.MaxLvl2,
        this.Skill2,
        this.Luck2,
        this.Opt2,
        this.Exe2,
        this.SetOpt2,
        this.Sock2
      });
      this.listView2.Location = new Point(6, 13);
      this.listView2.Name = "listView2";
      this.listView2.Size = new Size(567, 238);
      this.listView2.TabIndex = 45;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = View.Details;
      this.listView2.SelectedIndexChanged += new EventHandler(this.listView2_SelectedIndexChanged);
      this.listView2.KeyPress += new KeyPressEventHandler(this.listView2_KeyPress);
      this.Item2.Text = "Item";
      this.Item2.Width = 108;
      this.Group2.Text = "Group";
      this.Group2.Width = 45;
      this.Index2.Text = "Index";
      this.Index2.Width = 40;
      this.MinLvl2.Text = "MinLvl";
      this.MinLvl2.Width = 45;
      this.MaxLvl2.Text = "MaxLvl";
      this.MaxLvl2.Width = 48;
      this.Skill2.Text = "Skill";
      this.Skill2.Width = 40;
      this.Luck2.Text = "Luck";
      this.Luck2.Width = 40;
      this.Opt2.Text = "Opt";
      this.Opt2.Width = 40;
      this.Exe2.Text = "Exe";
      this.Exe2.Width = 40;
      this.SetOpt2.Text = "SetOpt";
      this.SetOpt2.Width = 45;
      this.Sock2.Text = "SocketOption";
      this.Sock2.Width = 80;
      this.button6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 177);
      this.button6.Location = new Point(12, 547);
      this.button6.Name = "button6";
      this.button6.Size = new Size(83, 30);
      this.button6.TabIndex = 46;
      this.button6.Text = "Add Section 2";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.textBox0.Location = new Point(423, 49);
      this.textBox0.Name = "textBox0";
      this.textBox0.Size = new Size(100, 20);
      this.textBox0.TabIndex = 47;
      this.groupBox5.Controls.Add((Control) this.listBox_SetOption);
      this.groupBox5.Location = new Point(130, 445);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(77, 117);
      this.groupBox5.TabIndex = 48;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "SetOption";
      this.listBox_SetOption.FormattingEnabled = true;
      this.listBox_SetOption.Items.AddRange(new object[6]
      {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "8"
      });
      this.listBox_SetOption.Location = new Point(15, 16);
      this.listBox_SetOption.Name = "listBox_SetOption";
      this.listBox_SetOption.Size = new Size(41, 95);
      this.listBox_SetOption.TabIndex = 1;
      this.groupBox6.Controls.Add((Control) this.listBox_Socket);
      this.groupBox6.Location = new Point(213, 445);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(136, 117);
      this.groupBox6.TabIndex = 49;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Socket Free Slot";
      this.listBox_Socket.FormattingEnabled = true;
      this.listBox_Socket.Items.AddRange(new object[6]
      {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5"
      });
      this.listBox_Socket.Location = new Point(17, 16);
      this.listBox_Socket.Name = "listBox_Socket";
      this.listBox_Socket.Size = new Size(41, 95);
      this.listBox_Socket.TabIndex = 2;
      this.groupBox7.Controls.Add((Control) this.listView1);
      this.groupBox7.Location = new Point(400, 78);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(583, 260);
      this.groupBox7.TabIndex = 50;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Section 1";
      this.groupBox8.Controls.Add((Control) this.listView2);
      this.groupBox8.Location = new Point(400, 342);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(583, 260);
      this.groupBox8.TabIndex = 51;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Section 2";
      this.ClientSize = new Size(990, 606);
      this.Controls.Add((Control) this.groupBox8);
      this.Controls.Add((Control) this.groupBox7);
      this.Controls.Add((Control) this.groupBox6);
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.textBox0);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox7);
      this.Controls.Add((Control) this.textBox6);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label_FileName);
      this.Controls.Add((Control) this.checkBox_FO);
      this.Controls.Add((Control) this.button_Update);
      this.Controls.Add((Control) this.label_Size);
      this.Controls.Add((Control) this.groupBox_NewItem_ExcOpt);
      this.Controls.Add((Control) this.button_Add);
      this.Controls.Add((Control) this.pictureBox_ItemPreview);
      this.Controls.Add((Control) this.checkBox_Skill);
      this.Controls.Add((Control) this.checkBox_Luck);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.listBox_Index);
      this.Controls.Add((Control) this.listBox_Group);
      this.Controls.Add((Control) this.menuStrip1);
      this.MaximizeBox = false;
      this.Name = nameof (ShopEditor);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "EventItemBag Editor";
      this.Load += new EventHandler(this.ShopEditor_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.numericUpDown_Durability.EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBox_NewItem_ExcOpt.ResumeLayout(false);
      this.groupBox_NewItem_ExcOpt.PerformLayout();
      ((ISupportInitialize) this.pictureBox_ItemPreview).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox7.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void listBox_Group_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listBox_Group.SelectedIndex == -1)
        return;
      this.DontWork = true;
      switch ((int) this.listBox_Group.SelectedValue)
      {
        case 0:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Swords;
          break;
        case 1:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Axes;
          break;
        case 2:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_MacesScepters;
          break;
        case 3:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Spears;
          break;
        case 4:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_BowsCrossBows;
          break;
        case 5:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Staffs;
          break;
        case 6:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Shields;
          break;
        case 7:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Helms;
          break;
        case 8:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Armors;
          break;
        case 9:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Pants;
          break;
        case 10:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Gloves;
          break;
        case 11:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Boots;
          break;
        case 12:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_WingsSkillsSeedsOthers;
          break;
        case 13:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Others1;
          break;
        case 14:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Others2;
          break;
        case 15:
          this.listBox_Index.DisplayMember = "Name";
          this.listBox_Index.ValueMember = "Index";
          this.listBox_Index.DataSource = (object) this.L_Scrolls;
          break;
      }
      this.listBox_Index.SelectedIndex = -1;
      this.DontWork = false;
      if (this.LastSelectedItemIndex > this.listBox_Index.Items.Count - 1)
        return;
      this.listBox_Index.SelectedIndex = this.LastSelectedItemIndex;
    }

    private void listBox_Index_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.listBox_Index.SelectedIndex != -1 & !this.DontWork))
        return;
      this.LastSelectedItemIndex = this.listBox_Index.SelectedIndex;
      try
      {
        this.pictureBox_ItemPreview.BackgroundImage = (Image) Resources.ResourceManager.GetObject("_" + this.listBox_Group.SelectedValue + this.listBox_Index.SelectedValue);
        Size size = this.pictureBox_ItemPreview.BackgroundImage.Size;
        int width1 = size.Width;
        size = this.pictureBox_ItemPreview.Size;
        int width2 = size.Width;
        if (width1 <= width2)
        {
          size = this.pictureBox_ItemPreview.BackgroundImage.Size;
          int height1 = size.Height;
          size = this.pictureBox_ItemPreview.Size;
          int height2 = size.Height;
          if (height1 <= height2)
          {
            this.pictureBox_ItemPreview.BackgroundImageLayout = ImageLayout.Center;
            goto label_7;
          }
        }
        this.pictureBox_ItemPreview.BackgroundImageLayout = ImageLayout.Zoom;
      }
      catch
      {
        this.pictureBox_ItemPreview.BackgroundImage = (Image) Resources.ResourceManager.GetObject("no_img");
      }
label_7:
      Structures.UniItem selectedItem = (Structures.UniItem) this.listBox_Index.SelectedItem;
      this.label_Size.Text = selectedItem.X.ToString() + "x" + (object) selectedItem.Y;
      this.checkBox_Skill.Checked = selectedItem.Skill != 0 && this.checkBox_Skill.Checked;
      this.listBox_Option.SelectedIndex = selectedItem.Option == 0 ? 0 : this.listBox_Option.SelectedIndex;
      this.numericUpDown_Durability.Value = selectedItem.Durability == 0 ? 0M : this.numericUpDown_Durability.Value;
      switch (selectedItem.Slot)
      {
        case -1:
        case 8:
        case 236:
          this.checkBox_ExcOpt1.Checked = false;
          this.checkBox_ExcOpt2.Checked = false;
          this.checkBox_ExcOpt3.Checked = false;
          this.checkBox_ExcOpt4.Checked = false;
          this.checkBox_ExcOpt5.Checked = false;
          this.checkBox_ExcOpt6.Checked = false;
          break;
        case 0:
        case 9:
          this.radioButton_ExcWeapon.Checked = true;
          break;
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 10:
          if (selectedItem.Group > 5)
          {
            this.radioButton_ExcArmor.Checked = true;
            break;
          }
          this.radioButton_ExcWeapon.Checked = true;
          break;
        case 7:
          this.radioButton_ExcWings.Checked = true;
          break;
      }
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShopItems = new Structures.ShopItem[16, 9];
      this.SelectedSI = new Structures.ShopItem();
      this.LastSelectetItem = new Structures.CustomPictureBox();
      this.ChangeOccupid(1, 1, 8, 15, false);
      this.button_Update.Enabled = false;
    }

    private void numericUpDown_Durability_ValueChanged(object sender, EventArgs e)
    {
      if (this.numericUpDown_Durability.Focused)
        this.OldDurValue = (int) this.numericUpDown_Durability.Value;
      else if (this.checkBox_DurLock.Checked)
        this.numericUpDown_Durability.Value = (Decimal) this.OldDurValue;
      else
        this.OldDurValue = (int) this.numericUpDown_Durability.Value;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "Text files (*.txt)|*.txt";
      openFileDialog1.Title = "Select a Text Shop file to Load";
      OpenFileDialog openFileDialog2 = openFileDialog1;
      if (openFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      string[] strArray1 = openFileDialog2.FileName.Split('.');
      if (strArray1[strArray1.Length - 1] == "txt")
      {
        string[] strArray2 = openFileDialog2.FileName.Split('\\');
        this.label_FileName.Text = strArray2[strArray2.Length - 1];
        this.ShopItems = new Structures.ShopItem[16, 9];
        this.SelectedSI = new Structures.ShopItem();
        this.LastSelectetItem = new Structures.CustomPictureBox();
        this.ChangeOccupid(1, 1, 8, 15, false);
        this.ReadShopFile(openFileDialog2.FileName);
      }
      else
      {
        int num = (int) MessageBox.Show("Invalid file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private unsafe void pb_MouseClick(object sender, MouseEventArgs e)
    {
      Structures.CustomPictureBox customPictureBox = (Structures.CustomPictureBox) sender;
      string[] strArray1 = customPictureBox.Name.Split('_');
      string[] strArray2 = strArray1[strArray1.Length - 2].Split('x');
      string[] strArray3 = strArray1[strArray1.Length - 1].Split('x');
      int int16_1 = (int) Convert.ToInt16(strArray2[1]);
      int int16_2 = (int) Convert.ToInt16(strArray2[0]);
      int int16_3 = (int) Convert.ToInt16(strArray3[1]);
      int int16_4 = (int) Convert.ToInt16(strArray3[0]);
      string str = "Item_" + (object) int16_2 + "x" + (object) int16_1 + "_" + (object) int16_4 + "x" + (object) int16_3;
      if (e.Button == MouseButtons.Right)
      {
        if (MessageBox.Show("    Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
          return;
        Structures.ShopItem[,] shopItems = this.ShopItems;
        int upperBound1 = shopItems.GetUpperBound(0);
        int upperBound2 = shopItems.GetUpperBound(1);
        for (int lowerBound1 = shopItems.GetLowerBound(0); lowerBound1 <= upperBound1; ++lowerBound1)
        {
          for (int lowerBound2 = shopItems.GetLowerBound(1); lowerBound2 <= upperBound2; ++lowerBound2)
          {
            Structures.ShopItem shopItem = shopItems[lowerBound1, lowerBound2];
            if (str == shopItem.UniqName)
            {
              *(Structures.ShopItem*) ref this.ShopItems.Address(shopItem.ShopLocY, shopItem.ShopLocX) = new Structures.ShopItem();
              break;
            }
          }
        }
        this.ChangeOccupid(int16_1, int16_2, int16_3, int16_4, false);
        this.button_Update.Enabled = false;
      }
      else
      {
        if (e.Button != MouseButtons.Left || this.LastSelectetItem == customPictureBox)
          return;
        customPictureBox.BorderColor = Color.Gold;
        this.LastSelectetItem.BorderColor = Color.Transparent;
        this.LastSelectetItem = customPictureBox;
        Structures.ShopItem[,] shopItems = this.ShopItems;
        int upperBound3 = shopItems.GetUpperBound(0);
        int upperBound4 = shopItems.GetUpperBound(1);
        for (int lowerBound3 = shopItems.GetLowerBound(0); lowerBound3 <= upperBound3; ++lowerBound3)
        {
          for (int lowerBound4 = shopItems.GetLowerBound(1); lowerBound4 <= upperBound4; ++lowerBound4)
          {
            Structures.ShopItem shopItem = shopItems[lowerBound3, lowerBound4];
            if (str == shopItem.UniqName)
            {
              this.SelectedSI = shopItem;
              break;
            }
          }
        }
        this.listBox_Group.SelectedValue = (object) this.SelectedSI.Group;
        this.listBox_Index.SelectedValue = (object) this.SelectedSI.Index;
        this.listBox_Level.SelectedIndex = (int) this.SelectedSI.Level;
        this.listBox_Option.SelectedIndex = (int) this.SelectedSI.Option;
        this.checkBox_Luck.Checked = this.SelectedSI.Luck;
        this.checkBox_Skill.Checked = this.SelectedSI.Skill;
        this.numericUpDown_Durability.Value = (Decimal) this.SelectedSI.Durablity;
        this.checkBox_ExcOpt1.Checked = ((int) this.SelectedSI.Excellent & 1) == 1;
        this.checkBox_ExcOpt2.Checked = ((int) this.SelectedSI.Excellent >> 1 & 1) == 1;
        this.checkBox_ExcOpt3.Checked = ((int) this.SelectedSI.Excellent >> 2 & 1) == 1;
        this.checkBox_ExcOpt4.Checked = ((int) this.SelectedSI.Excellent >> 3 & 1) == 1;
        this.checkBox_ExcOpt5.Checked = ((int) this.SelectedSI.Excellent >> 4 & 1) == 1;
        this.checkBox_ExcOpt6.Checked = ((int) this.SelectedSI.Excellent >> 5 & 1) == 1;
        this.button_Update.Enabled = true;
      }
    }

    private void radioButton_Exc_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton_ExcArmor.Checked)
      {
        this.checkBox_ExcOpt1.Text = "Zen Drop +30%";
        this.checkBox_ExcOpt2.Text = "Def Success Rate +10%";
        this.checkBox_ExcOpt3.Text = "Reflect +5%";
        this.checkBox_ExcOpt4.Text = "Damage Decrease +4%";
        this.checkBox_ExcOpt5.Text = "Mana +4%";
        this.checkBox_ExcOpt6.Text = "HP +4%";
      }
      else if (this.radioButton_ExcWeapon.Checked)
      {
        this.checkBox_ExcOpt1.Text = "Mob Kill +mana/8";
        this.checkBox_ExcOpt2.Text = "Mob Kill +life/8";
        this.checkBox_ExcOpt3.Text = "Attack(Wizardy) Speed +7";
        this.checkBox_ExcOpt4.Text = "Damage +2%";
        this.checkBox_ExcOpt5.Text = "Damage +level/20";
        this.checkBox_ExcOpt6.Text = "Exc Damage Rate +10%";
      }
      else
      {
        if (!this.radioButton_ExcWings.Checked)
          return;
        this.checkBox_ExcOpt1.Text = "Ignor Def +5% / HP +125";
        this.checkBox_ExcOpt2.Text = "Return Attack +5% / Mana +125";
        this.checkBox_ExcOpt3.Text = "Life Recovery +5% /Ignor Def +3%";
        this.checkBox_ExcOpt4.Text = "Mana Recovery +5% / AG +50";
        this.checkBox_ExcOpt5.Text = "--- / Attack(Wiz) Speed+5";
        this.checkBox_ExcOpt6.Text = "---";
      }
    }

    private void ReadShopFile(string fName)
    {
      foreach (string readAllLine in File.ReadAllLines(fName))
      {
        if (!readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("\"") & !readAllLine.ToLower().Replace("\t", "").Trim().StartsWith("end") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("/") & readAllLine.ToUpper().Replace("\t", "").Trim().Length > 1)
        {
          string[] strArray = readAllLine.Replace(" ", "\t").Split('\t');
          List<string> stringList = new List<string>();
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (strArray[index].Trim().Length != 0)
              stringList.Add(strArray[index]);
          }
          string[] array = stringList.ToArray();
          int length = array.Length;
          try
          {
            if (array.Length == 8)
            {
              Structures.ShopItem shopItem = new Structures.ShopItem()
              {
                Group = Convert.ToInt32(array[0]),
                Index = Convert.ToInt32(array[1]),
                Level = Convert.ToByte(array[2]),
                Level2 = Convert.ToByte(array[3]),
                Durablity = Convert.ToByte(array[3]),
                Skill = Convert.ToBoolean(Convert.ToByte(array[4])),
                Luck = Convert.ToBoolean(Convert.ToByte(array[5])),
                Option = Convert.ToByte(array[6]),
                Excellent = Convert.ToByte(array[7])
              };
              string empty = string.Empty;
              string str1 = string.Empty + (shopItem.Excellent > (byte) 0 ? "Excellent " : "");
              string str2 = this.ItemName[shopItem.Group, shopItem.Index] + "+" + (object) shopItem.Level + "+" + (shopItem.Option == (byte) 1 ? (object) "4" : (shopItem.Option == (byte) 2 ? (object) "8" : (shopItem.Option == (byte) 3 ? (object) "12" : (shopItem.Option == (byte) 4 ? (object) "16" : (shopItem.Option == (byte) 5 ? (object) "20" : (shopItem.Option == (byte) 6 ? (object) "24" : (shopItem.Option == (byte) 7 ? (object) "28" : (object) "0"))))))) + (shopItem.Skill ? "+Skill" : "") + (shopItem.Luck ? (object) "+Luck" : (object) "") + "\n\nDurabilityAA: " + (object) shopItem.Durablity;
              if (shopItem.Excellent > (byte) 0)
              {
                string str3 = str2 + "\n\nExcellent Option: " + (object) shopItem.Excellent;
              }
              Structures.UniItem uniItem = new Structures.UniItem()
              {
                Group = shopItem.Group,
                Index = shopItem.Index
              };
              uniItem.X = (int) Convert.ToInt16(this.ItemSize[uniItem.Group, uniItem.Index].Split('x')[0]);
              uniItem.Y = (int) Convert.ToInt16(this.ItemSize[uniItem.Group, uniItem.Index].Split('x')[1]);
              this.listView1.Items.Add(new ListViewItem(this.ItemName[shopItem.Group, shopItem.Index])
              {
                SubItems = {
                  shopItem.Group.ToString(),
                  shopItem.Index.ToString(),
                  shopItem.Level.ToString(),
                  shopItem.Level2.ToString(),
                  Convert.ToInt32(shopItem.Skill).ToString(),
                  Convert.ToInt32(shopItem.Luck).ToString(),
                  shopItem.Option.ToString(),
                  shopItem.Excellent.ToString()
                }
              });
            }
          }
          catch
          {
            break;
          }
        }
      }
    }

    private void ReadShopFile1(string fName)
    {
      foreach (string readAllLine in File.ReadAllLines(fName))
      {
        if (!readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("\"") & !readAllLine.ToLower().Replace("\t", "").Trim().StartsWith("end") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("/") & readAllLine.ToUpper().Replace("\t", "").Trim().Length > 1)
        {
          string[] strArray = readAllLine.Replace(" ", "\t").Split('\t');
          List<string> stringList = new List<string>();
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (strArray[index].Trim().Length != 0)
              stringList.Add(strArray[index]);
          }
          string[] array = stringList.ToArray();
          int length = array.Length;
          try
          {
            if (array.Length == 10)
            {
              Structures.ShopItem2 shopItem2 = new Structures.ShopItem2()
              {
                Group = Convert.ToInt32(array[0]),
                Index = Convert.ToInt32(array[1]),
                Level = Convert.ToByte(array[2]),
                Level2 = Convert.ToByte(array[3]),
                Durablity = Convert.ToByte(array[3]),
                Skill = Convert.ToBoolean(Convert.ToByte(array[4])),
                Luck = Convert.ToBoolean(Convert.ToByte(array[5])),
                Option = Convert.ToByte(array[6]),
                Excellent = Convert.ToByte(array[7]),
                SetOpt = Convert.ToByte(array[8]),
                Sock = Convert.ToByte(array[9])
              };
              string empty = string.Empty;
              string str1 = string.Empty + (shopItem2.Excellent > (byte) 0 ? "Excellent " : "");
              string str2 = this.ItemName[shopItem2.Group, shopItem2.Index] + "+" + (object) shopItem2.Level + "+" + (shopItem2.Option == (byte) 1 ? (object) "4" : (shopItem2.Option == (byte) 2 ? (object) "8" : (shopItem2.Option == (byte) 3 ? (object) "12" : (shopItem2.Option == (byte) 4 ? (object) "16" : (shopItem2.Option == (byte) 5 ? (object) "20" : (shopItem2.Option == (byte) 6 ? (object) "24" : (shopItem2.Option == (byte) 7 ? (object) "28" : (object) "0"))))))) + (shopItem2.Skill ? "+Skill" : "") + (shopItem2.Luck ? (object) "+Luck" : (object) "") + "\n\nDurabilityAA: " + (object) shopItem2.Durablity;
              if (shopItem2.Excellent > (byte) 0)
              {
                string str3 = str2 + "\n\nExcellent Option: " + (object) shopItem2.Excellent;
              }
              Structures.UniItem uniItem = new Structures.UniItem()
              {
                Group = shopItem2.Group,
                Index = shopItem2.Index
              };
              uniItem.X = (int) Convert.ToInt16(this.ItemSize[uniItem.Group, uniItem.Index].Split('x')[0]);
              uniItem.Y = (int) Convert.ToInt16(this.ItemSize[uniItem.Group, uniItem.Index].Split('x')[1]);
              ListViewItem listViewItem = new ListViewItem(this.ItemName[shopItem2.Group, shopItem2.Index]);
              listViewItem.SubItems.Add(shopItem2.Group.ToString());
              listViewItem.SubItems.Add(shopItem2.Index.ToString());
              ListViewItem.ListViewSubItemCollection subItems1 = listViewItem.SubItems;
              byte num = shopItem2.Level;
              string text1 = num.ToString();
              subItems1.Add(text1);
              ListViewItem.ListViewSubItemCollection subItems2 = listViewItem.SubItems;
              num = shopItem2.Level2;
              string text2 = num.ToString();
              subItems2.Add(text2);
              listViewItem.SubItems.Add(Convert.ToInt32(shopItem2.Skill).ToString());
              listViewItem.SubItems.Add(Convert.ToInt32(shopItem2.Luck).ToString());
              ListViewItem.ListViewSubItemCollection subItems3 = listViewItem.SubItems;
              num = shopItem2.Option;
              string text3 = num.ToString();
              subItems3.Add(text3);
              ListViewItem.ListViewSubItemCollection subItems4 = listViewItem.SubItems;
              num = shopItem2.Excellent;
              string text4 = num.ToString();
              subItems4.Add(text4);
              ListViewItem.ListViewSubItemCollection subItems5 = listViewItem.SubItems;
              num = shopItem2.SetOpt;
              string text5 = num.ToString();
              subItems5.Add(text5);
              ListViewItem.ListViewSubItemCollection subItems6 = listViewItem.SubItems;
              num = shopItem2.Sock;
              string text6 = num.ToString();
              subItems6.Add(text6);
              this.listView2.Items.Add(listViewItem);
            }
          }
          catch
          {
            break;
          }
        }
      }
    }

    private void ReadShopFile2(string fName)
    {
      foreach (string readAllLine in File.ReadAllLines(fName))
      {
        if (!readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("0") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("1") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("2") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("3") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("4") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("5") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("6") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("7") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("8") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("9") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("10") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("11") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("12") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("13") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("14") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("15") & !readAllLine.ToLower().Replace("\t", "").Trim().StartsWith("end") & !readAllLine.ToUpper().Replace("\t", "").Trim().StartsWith("/") & readAllLine.ToUpper().Replace("\t", "").Trim().Length > 0)
        {
          string[] strArray = readAllLine.Replace(" ", "_").Split('\t');
          List<string> stringList = new List<string>();
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (strArray[index].Trim().Length != 0)
              stringList.Add(strArray[index]);
          }
          string[] array = stringList.ToArray();
          if (array.Length < 1)
          {
            int num = (int) MessageBox.Show("\tInvalid line00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
          try
          {
            this.textBox0.Text = array[0].Replace("_", " ").Replace("\"", "");
            this.textBox2.Text = array[1].Replace("_", "");
            this.textBox3.Text = array[2].Replace("_", "");
            this.textBox4.Text = array[3].Replace("_", "");
            this.textBox5.Text = array[4].Replace("_", "");
            this.textBox6.Text = array[5].Replace("_", "");
            this.textBox7.Text = array[6].Replace("_", "");
          }
          catch
          {
            int num = (int) MessageBox.Show("\tInvalid line11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
        }
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Title = "Select a Location to save the Shop file";
      saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
      SaveFileDialog saveFileDialog2 = saveFileDialog1;
      if (saveFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      string[] strArray1 = saveFileDialog2.FileName.Split('\\');
      this.label_FileName.Text = strArray1[strArray1.Length - 1];
      string[] strArray2 = saveFileDialog2.FileName.Split('\\');
      string str1 = strArray2[strArray2.Length - 1].Split('.')[0];
      StreamWriter streamWriter = new StreamWriter(saveFileDialog2.FileName)
      {
        AutoFlush = true
      };
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//Shop Editor cortesia de www.GamesBit.net");
      streamWriter.WriteLine("///////////////////////////");
      streamWriter.WriteLine("//Aporte de www.fb.com/karuritoku");
      streamWriter.WriteLine("///////////////////////////");
      streamWriter.WriteLine("//Shop: {0}", (object) str1);
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//Group\tIndex\tLevel\tDur\tSkill\tLuck\tOpt\tExeOpt\tSkt[1]\tSkt[2]\tSkt[3]\tSkt[4]\tSkt[5]\tElem\tInfo");
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//");
      for (int index1 = 1; index1 < 16; ++index1)
      {
        for (int index2 = 1; index2 < 9; ++index2)
        {
          if (this.ShopItems[index1, index2].UniqName != null)
          {
            Structures.ShopItem shopItem = this.ShopItems[index1, index2];
            string str2 = string.Empty + (shopItem.Excellent > (byte) 0 ? "Excellent " : "");
            string str3 = "*\t*\t*\t*\t*\t*";
            streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", (object) shopItem.Group, (object) shopItem.Index, (object) shopItem.Level, (object) shopItem.Durablity, (object) Convert.ToInt16(shopItem.Skill), (object) Convert.ToInt16(shopItem.Luck), (object) shopItem.Option, (object) shopItem.Excellent, (object) str3, (object) this.ItemName[shopItem.Group, shopItem.Index]);
          }
        }
      }
      streamWriter.WriteLine("end");
      streamWriter.Close();
    }

    private void ShopEditor_Load(object sender, EventArgs e)
    {
      this.listBox_SetOption.SelectedIndex = 0;
      this.listBox_Socket.SelectedIndex = 0;
      this.isEx700ItemList = Convert.ToBoolean(((ShopEditor) Application.OpenForms[0]).isEx700ItemList) ? 1 : 0;
      if (this.isEx700ItemList == 1)
        this.strct.ReadItemList("Data\\ItemListSettings_ex700.ini", true, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref this.ItemSize);
      else
        this.strct.ReadItemList("Data\\ItemListSettings.ini", false, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref this.ItemSize);
      this.listBox_Group.DisplayMember = "GroupName";
      this.listBox_Group.ValueMember = "Group";
      this.listBox_Group.DataSource = (object) this.L_Groups;
      this.strct.Setc_LevelData(ref this.c_LevelDatas);
      this.listBox_Level.DataSource = (object) this.c_LevelDatas;
      this.listBox_Level.ValueMember = "ID";
      this.listBox_Level.DisplayMember = "Name";
      this.listBox_maxlvl.SelectedIndex = 1;
      this.strct.Setc_OptionData(ref this.c_OptionDatas);
      this.listBox_Option.DataSource = (object) this.c_OptionDatas;
      this.listBox_Option.DisplayMember = "Name";
      this.listBox_Option.ValueMember = "ID";
      this.radioButton_ExcWeapon.Checked = true;
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.TopMost = true;
      this.TopMost = false;
      this.BringToFront();
      this.Focus();
    }

    private void wwwgamesbitnetToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.ShopItems = new Structures.ShopItem[16, 9];
      this.SelectedSI = new Structures.ShopItem();
      this.LastSelectetItem = new Structures.CustomPictureBox();
      this.ChangeOccupid(1, 1, 8, 15, false);
      this.button_Update.Enabled = false;
      this.OpenedFile = "0";
      this.listView1.Items.Clear();
      this.listView2.Items.Clear();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "Text files (*.txt)|*.txt";
      openFileDialog1.Title = "Select a Text Shop file to Load";
      OpenFileDialog openFileDialog2 = openFileDialog1;
      if (openFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      this.RutaArchivo = openFileDialog2.FileName;
      this.OpenedFile = "1";
      string[] strArray1 = openFileDialog2.FileName.Split('.');
      if (strArray1[strArray1.Length - 1] == "txt")
      {
        string[] strArray2 = openFileDialog2.FileName.Split('\\');
        this.label_FileName.Text = strArray2[strArray2.Length - 1];
        this.ShopItems = new Structures.ShopItem[16, 9];
        this.SelectedSI = new Structures.ShopItem();
        this.LastSelectetItem = new Structures.CustomPictureBox();
        this.ChangeOccupid(1, 1, 8, 15, false);
        this.listView1.Items.Clear();
        this.listView2.Items.Clear();
        this.ReadShopFile(openFileDialog2.FileName);
        this.ReadShopFile1(openFileDialog2.FileName);
        this.ReadShopFile2(openFileDialog2.FileName);
      }
      else
      {
        int num = (int) MessageBox.Show("Invalid file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Title = "Select a Location to save the Shop file";
      saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
      SaveFileDialog saveFileDialog2 = saveFileDialog1;
      if (saveFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      string[] strArray1 = saveFileDialog2.FileName.Split('\\');
      this.label_FileName.Text = strArray1[strArray1.Length - 1];
      string[] strArray2 = saveFileDialog2.FileName.Split('\\');
      string str1 = strArray2[strArray2.Length - 1].Split('.')[0];
      StreamWriter streamWriter = new StreamWriter(saveFileDialog2.FileName)
      {
        AutoFlush = true
      };
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//Shop Editor cortesia de www.GamesBit.net");
      streamWriter.WriteLine("///////////////////////////");
      streamWriter.WriteLine("//Aporte de www.fb.com/karuritoku");
      streamWriter.WriteLine("///////////////////////////");
      streamWriter.WriteLine("//Shop: {0}", (object) str1);
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//Group\tIndex\tLevel\tDur\tSkill\tLuck\tOpt\tExeOpt\tSkt[1]\tSkt[2]\tSkt[3]\tSkt[4]\tSkt[5]\tElem\tInfo");
      streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
      streamWriter.WriteLine("//");
      for (int index1 = 1; index1 < 16; ++index1)
      {
        for (int index2 = 1; index2 < 9; ++index2)
        {
          if (this.ShopItems[index1, index2].UniqName != null)
          {
            Structures.ShopItem shopItem = this.ShopItems[index1, index2];
            string str2 = string.Empty + (shopItem.Excellent > (byte) 0 ? "Excellent " : "");
            string str3 = "*\t*\t*\t*\t*\t*";
            streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", (object) shopItem.Group, (object) shopItem.Index, (object) shopItem.Level, (object) shopItem.Durablity, (object) Convert.ToInt16(shopItem.Skill), (object) Convert.ToInt16(shopItem.Luck), (object) shopItem.Option, (object) shopItem.Excellent, (object) str3, (object) this.ItemName[shopItem.Group, shopItem.Index]);
          }
        }
      }
      streamWriter.WriteLine("end");
      streamWriter.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.OpenedFile == "0")
      {
        this.button3.PerformClick();
      }
      else
      {
        string[] strArray1 = this.RutaArchivo.Split('\\');
        this.label_FileName.Text = strArray1[strArray1.Length - 1];
        string[] strArray2 = this.RutaArchivo.Split('\\');
        string str = strArray2[strArray2.Length - 1].Split('.')[0];
        StreamWriter streamWriter = new StreamWriter(this.RutaArchivo)
        {
          AutoFlush = true
        };
        streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
        streamWriter.WriteLine("//Editor Cortesia de www.GamesBit.net");
        streamWriter.WriteLine("///////////////////////////");
        streamWriter.WriteLine("//Aporte de www.facebook.com/Arnold.DGD");
        streamWriter.WriteLine("///////////////////////////");
        streamWriter.WriteLine("//Archivo: {0}", (object) str);
        streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
        streamWriter.WriteLine("0");
        streamWriter.WriteLine("//EventName\tDropZen\tItemDropRate\tItemDropCount\tSetItemDropRate\tItemDropType\tFireworks");
        streamWriter.WriteLine("\"" + this.textBox0.Text + "\"\t" + this.textBox2.Text + "\t" + this.textBox3.Text + "\t" + this.textBox4.Text + "\t" + this.textBox5.Text + "\t" + this.textBox6.Text + "\t" + this.textBox7.Text);
        streamWriter.WriteLine("end");
        streamWriter.WriteLine("");
        streamWriter.WriteLine("1");
        streamWriter.WriteLine("//Section\tType\tMinLevel\tMaxLevel\tSkill\tLuck\tOption\tExcellent\tNameItem");
        int count1 = this.listView1.Items.Count;
        for (int index = 0; index < count1; ++index)
          streamWriter.WriteLine(this.listView1.Items[index].SubItems[1].Text + "\t" + this.listView1.Items[index].SubItems[2].Text + "\t" + this.listView1.Items[index].SubItems[3].Text + "\t" + this.listView1.Items[index].SubItems[4].Text + "\t" + this.listView1.Items[index].SubItems[5].Text + "\t" + this.listView1.Items[index].SubItems[6].Text + "\t" + this.listView1.Items[index].SubItems[7].Text + "\t" + this.listView1.Items[index].SubItems[8].Text);
        streamWriter.WriteLine("end");
        streamWriter.WriteLine("2");
        streamWriter.WriteLine("//Section\tType\tMinLevel\tMaxLevel\tSkill\tLuck\tOption\tExcellent\tSetOption\tSocketOption\tNameItem");
        int count2 = this.listView2.Items.Count;
        for (int index = 0; index < count2; ++index)
          streamWriter.WriteLine(this.listView2.Items[index].SubItems[1].Text + "\t" + this.listView2.Items[index].SubItems[2].Text + "\t" + this.listView2.Items[index].SubItems[3].Text + "\t" + this.listView2.Items[index].SubItems[4].Text + "\t" + this.listView2.Items[index].SubItems[5].Text + "\t" + this.listView2.Items[index].SubItems[6].Text + "\t" + this.listView2.Items[index].SubItems[7].Text + "\t" + this.listView2.Items[index].SubItems[8].Text + "\t" + this.listView2.Items[index].SubItems[9].Text + "\t" + this.listView2.Items[index].SubItems[10].Text);
        streamWriter.WriteLine("end");
        streamWriter.Close();
      }
    }

    private void button5_Click(object sender, EventArgs e) => Process.Start("http://gamesbit.net");

    private void listBox_Level_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void UpdateSelect(string tipo)
    {
      if (tipo == "1")
      {
        object selectedItems = (object) this.listView1.SelectedItems;
        this.textBox1.Text = this.listView1.FocusedItem.SubItems[1].Text;
        this.listBox_Group.SelectedValue = (object) Convert.ToInt32(this.listView1.FocusedItem.SubItems[1].Text);
        this.listBox_Index.SelectedValue = (object) Convert.ToInt32(this.listView1.FocusedItem.SubItems[2].Text);
        this.listBox_Level.SelectedIndex = Convert.ToInt32(this.listView1.FocusedItem.SubItems[3].Text);
        this.listBox_maxlvl.SelectedIndex = Convert.ToInt32(this.listView1.FocusedItem.SubItems[4].Text);
        this.listBox_Option.SelectedIndex = Convert.ToInt32(this.listView1.FocusedItem.SubItems[7].Text);
        this.checkBox_Luck.Checked = Convert.ToBoolean(Convert.ToInt16(this.listView1.FocusedItem.SubItems[6].Text));
        this.checkBox_Skill.Checked = Convert.ToBoolean(Convert.ToInt16(this.listView1.FocusedItem.SubItems[5].Text));
        this.checkBox_ExcOpt1.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) & 1) == 1;
        this.checkBox_ExcOpt2.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) >> 1 & 1) == 1;
        this.checkBox_ExcOpt3.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) >> 2 & 1) == 1;
        this.checkBox_ExcOpt4.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) >> 3 & 1) == 1;
        this.checkBox_ExcOpt5.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) >> 4 & 1) == 1;
        this.checkBox_ExcOpt6.Checked = (Convert.ToInt32(this.listView1.FocusedItem.SubItems[8].Text) >> 5 & 1) == 1;
        this.button_Update.Enabled = true;
      }
      else
      {
        if (!(tipo == "2"))
          return;
        object selectedItems = (object) this.listView2.SelectedItems;
        this.textBox1.Text = this.listView2.FocusedItem.SubItems[1].Text;
        this.listBox_Group.SelectedValue = (object) Convert.ToInt32(this.listView2.FocusedItem.SubItems[1].Text);
        this.listBox_Index.SelectedValue = (object) Convert.ToInt32(this.listView2.FocusedItem.SubItems[2].Text);
        this.listBox_Level.SelectedIndex = Convert.ToInt32(this.listView2.FocusedItem.SubItems[3].Text);
        this.listBox_maxlvl.SelectedIndex = Convert.ToInt32(this.listView2.FocusedItem.SubItems[4].Text);
        this.listBox_Option.SelectedIndex = Convert.ToInt32(this.listView2.FocusedItem.SubItems[7].Text);
        this.checkBox_Luck.Checked = Convert.ToBoolean(Convert.ToInt16(this.listView2.FocusedItem.SubItems[6].Text));
        this.checkBox_Skill.Checked = Convert.ToBoolean(Convert.ToInt16(this.listView2.FocusedItem.SubItems[5].Text));
        this.checkBox_ExcOpt1.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) & 1) == 1;
        this.checkBox_ExcOpt2.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) >> 1 & 1) == 1;
        this.checkBox_ExcOpt3.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) >> 2 & 1) == 1;
        this.checkBox_ExcOpt4.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) >> 3 & 1) == 1;
        this.checkBox_ExcOpt5.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) >> 4 & 1) == 1;
        this.checkBox_ExcOpt6.Checked = (Convert.ToInt32(this.listView2.FocusedItem.SubItems[8].Text) >> 5 & 1) == 1;
        int num = Convert.ToInt32(this.listView2.FocusedItem.SubItems[9].Text);
        if (num > 4)
          num = 5;
        this.listBox_SetOption.SelectedIndex = num;
        this.listBox_Socket.SelectedIndex = Convert.ToInt32(this.listView2.FocusedItem.SubItems[10].Text);
        this.button_Update.Enabled = true;
      }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Section = "1";
      this.UpdateSelect("1");
    }

    private void pictureBox_Init_1x1_Click(object sender, EventArgs e)
    {
    }

    private void label7_Click(object sender, EventArgs e)
    {
    }

    private void button6_Click(object sender, EventArgs e)
    {
      string empty = string.Empty;
      Structures.ShopItem2 shopItem2 = new Structures.ShopItem2()
      {
        Group = Convert.ToInt32(this.listBox_Group.SelectedValue),
        Index = Convert.ToInt32(this.listBox_Index.SelectedValue),
        Level = Convert.ToByte(this.listBox_Level.SelectedValue),
        Level2 = Convert.ToByte(this.listBox_maxlvl.SelectedValue),
        Option = Convert.ToByte(this.listBox_Option.SelectedValue),
        Skill = this.checkBox_Skill.Checked,
        Luck = this.checkBox_Luck.Checked,
        Durablity = Convert.ToByte(this.numericUpDown_Durability.Value),
        Excellent = this.GetExcVal(),
        SetOpt = Convert.ToByte(Convert.ToInt32(this.listBox_SetOption.Text)),
        Sock = Convert.ToByte(Convert.ToInt32(this.listBox_Socket.SelectedIndex))
      };
      string str = string.Empty + (shopItem2.Excellent > (byte) 0 ? "Excellent " : "") + this.listBox_Index.Text + "+" + (object) shopItem2.Level + this.listBox_Option.Text + (shopItem2.Skill ? "+Skill" : "") + (shopItem2.Luck ? (object) "+Luck" : (object) "") + "\n\nDurability: " + (object) shopItem2.Durablity;
      if (shopItem2.Excellent > (byte) 0)
        str + "\n\nExcellent Options:\n" + (this.checkBox_ExcOpt1.Checked ? this.checkBox_ExcOpt1.Text + "\n" : "") + (this.checkBox_ExcOpt2.Checked ? this.checkBox_ExcOpt2.Text + "\n" : "") + (this.checkBox_ExcOpt3.Checked ? this.checkBox_ExcOpt3.Text + "\n" : "") + (this.checkBox_ExcOpt4.Checked ? this.checkBox_ExcOpt4.Text + "\n" : "") + (this.checkBox_ExcOpt5.Checked ? this.checkBox_ExcOpt5.Text + "\n" : "") + (this.checkBox_ExcOpt6.Checked ? this.checkBox_ExcOpt6.Text : "");
      this.listView2.Items.Add(new ListViewItem(this.listBox_Index.Text)
      {
        SubItems = {
          shopItem2.Group.ToString(),
          shopItem2.Index.ToString(),
          shopItem2.Level.ToString(),
          this.listBox_maxlvl.SelectedIndex.ToString(),
          Convert.ToInt32(shopItem2.Skill).ToString(),
          Convert.ToInt32(shopItem2.Luck).ToString(),
          shopItem2.Option.ToString(),
          shopItem2.Excellent.ToString(),
          shopItem2.SetOpt.ToString(),
          shopItem2.Sock.ToString()
        }
      });
    }

    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Section = "2";
      this.UpdateSelect("2");
    }

    private void listView1_KeyPress_1(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Back) || MessageBox.Show("    Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.listView1.FocusedItem.Remove();
    }

    private void listView2_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Back) || MessageBox.Show("    Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.listView2.FocusedItem.Remove();
    }
  }
}
