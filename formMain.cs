using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing; // Color

namespace bdavren {
    public partial class formMain : Form {
        // ========== class で使う Windows フォームを作成 ==========
        private Label label1;
        private TextBox tbxSrcFolder;
        private Button btnSrcFolder;
        private Label line1;
        private Label label2;
        private DataGridView tblFiles;
        private Label label3;
        private CheckBox chkAllOffice;
        private Label label4;
        private CheckBox chkAllDate;
        private Label label5;
        private CheckBox chkAllDuration;
        private Label label6;
        private TextBox tbxProgName;
        private Label label7;
        private TextBox tbxDateTime;
        private Label label8;
        private TextBox tbxDuration;
        private Label label9;
        private TextBox tbxChannel;
        private Label label10;
        private TextBox tbxOffice;
        private Label label11;
        private TextBox tbxGenre;
        private Label label12;
        private TextBox tbxCaption;
        private Label line2;
        private Label label13;
        private Button btnExec;
        private Button btnCancel;
        private Button btnClear;
        private Label line3;
        private Label label14;
        private TextBox tbxStatus;
        public formMain() {
            InitializeComponent();
        }

        // ---------- フォーム作成 ----------
        private void InitializeComponent() {
            this.SuspendLayout();

            // 上部分のコントロールを作成
            MakeLabel( ref label1, 10, 4, "1. 元動画ファイルのフォルダ（必須）" );
            MakeTextbox( ref tbxSrcFolder, "TbxSrcFolder", false, 240, 4, 640, 60, "" );
            MakeButton( ref btnSrcFolder, "BtnSrcFolder", 884, 2, 110, 24, "フォルダ参照" );
              btnSrcFolder.Click += new EventHandler( Click_btnSrcFolder );

            // 表のコントロールを作成
            MakeLineLabel( ref line1, 6, 28, 1180 );
            MakeLabel( ref label2, 10, 40, "2. 各動画ファイルと指定" );
            tblFiles = new DataGridView();
              tblFiles.Name = "TblFiles";
              tblFiles.AllowUserToAddRows = false;
              tblFiles.AutoGenerateColumns = false;
              tblFiles.EnableHeadersVisualStyles = false;
              tblFiles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb( 30, 80, 60 );
              tblFiles.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb( 220, 250, 240 );
              tblFiles.DefaultCellStyle.BackColor = Color.FromArgb( 200, 200, 200 );
              tblFiles.DefaultCellStyle.ForeColor = Color.FromArgb( 0, 0, 0 );
              tblFiles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
              tblFiles.Location = new Point( 16, 64 );
              tblFiles.Size = new Size( 800, 570 );
              tblFiles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
              tblFiles.CellBorderStyle = DataGridViewCellBorderStyle.Single;
              tblFiles.GridColor = Color.Black;
              tblFiles.RowHeadersVisible = false;
              tblFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
              tblFiles.MultiSelect = false;
              tblFiles.Dock = DockStyle.None;
              // インデックスカラム
              DataGridViewColumn tblFilesColIdx = new DataGridViewTextBoxColumn();
              tblFilesColIdx.Name = "tblFilesColIdx";
              tblFilesColIdx.HeaderText = "idx.";
              tblFilesColIdx.ValueType = typeof( String );
              tblFilesColIdx.Width = 26;
              tblFilesColIdx.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColIdx );
              // 元ファイル名カラム
              DataGridViewColumn tblFilesColSfilename = new DataGridViewTextBoxColumn();
              tblFilesColSfilename.Name = "tblFilesColSfilename";
              tblFilesColSfilename.HeaderText = "元ファイル名";
              tblFilesColSfilename.ValueType = typeof( String );
              tblFilesColSfilename.Width = 70;
              tblFilesColSfilename.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColSfilename );
              // 番組名カラム
              DataGridViewColumn tblFilesColProgramname = new DataGridViewTextBoxColumn();
              tblFilesColProgramname.Name = "tblFilesColProgramname";
              tblFilesColProgramname.HeaderText = "番組名";
              tblFilesColProgramname.ValueType = typeof( String );
              tblFilesColProgramname.Width = 412;
              tblFilesColProgramname.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColProgramname );
              // 放送局チェックカラム
              DataGridViewCheckBoxColumn tblFilesColChkOffice = new DataGridViewCheckBoxColumn();
              tblFilesColChkOffice.Name = "tblFilesColChkOffice";
              tblFilesColChkOffice.ThreeState = false;
              tblFilesColChkOffice.HeaderText = " ";
              tblFilesColChkOffice.Width = 20;
              tblFiles.Columns.Add( tblFilesColChkOffice );
              // 放送局カラム
              DataGridViewColumn tblFilesColOffice = new DataGridViewTextBoxColumn();
              tblFilesColOffice.Name = "tblFilesColOffice";
              tblFilesColOffice.HeaderText = "放送局";
              tblFilesColOffice.ValueType = typeof( String );
              tblFilesColOffice.Width = 90;
              tblFilesColOffice.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColOffice );
              // 放送日チェックカラム
              DataGridViewCheckBoxColumn tblFilesColChkDate = new DataGridViewCheckBoxColumn();
              tblFilesColChkDate.Name = "tblFilesColChkDate";
              tblFilesColChkDate.ThreeState = false;
              tblFilesColChkDate.HeaderText = " ";
              tblFilesColChkDate.Width = 20;
              tblFiles.Columns.Add( tblFilesColChkDate );
              // 放送日カラム
              DataGridViewColumn tblFilesColDate = new DataGridViewTextBoxColumn();
              tblFilesColDate.Name = "tblFilesColDate";
              tblFilesColDate.HeaderText = "放送日";
              tblFilesColDate.ValueType = typeof( String );
              tblFilesColDate.Width = 72;
              tblFilesColDate.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColDate );
              // 長さチェックカラム
              DataGridViewCheckBoxColumn tblFilesColChkDuration = new DataGridViewCheckBoxColumn();
              tblFilesColChkDuration.Name = "tblFilesColChkDuration";
              tblFilesColChkDuration.ThreeState = false;
              tblFilesColChkDuration.HeaderText = " ";
              tblFilesColChkDuration.Width = 20;
              tblFiles.Columns.Add( tblFilesColChkDuration );
              // 長さカラム
              DataGridViewColumn tblFilesColDuration = new DataGridViewTextBoxColumn();
              tblFilesColDuration.Name = "tblFilesColDuration";
              tblFilesColDuration.HeaderText = "長さ";
              tblFilesColDuration.ValueType = typeof( String );
              tblFilesColDuration.Width = 48;
              tblFilesColDuration.SortMode = DataGridViewColumnSortMode.NotSortable;
              tblFiles.Columns.Add( tblFilesColDuration );
              // 編集動作の設定
              tblFiles.CellClick += CellClick_tblFiles;
              tblFiles.AllowUserToAddRows = false;
              tblFiles.AllowUserToDeleteRows = false;
              tblFiles.ReadOnly = true;
            this.Controls.Add( tblFiles );

            // 表の下にあるチェックボックスコントロールを作成
            MakeCheckBox( ref chkAllOffice, 428, 640 );
              chkAllOffice.Click += Click_chkAllOffice;
            MakeLabel( ref label3, 440, 640, "放送局全チェック" );
            MakeCheckBox( ref chkAllDate, 568, 640 );
              chkAllDate.Click += Click_chkAllDate;
            MakeLabel( ref label4, 580, 640, "放送日全チェック" );
            MakeCheckBox( ref chkAllDuration, 708, 640 );
              chkAllDuration.Click += Click_chkAllDuration;
            MakeLabel( ref label5, 720, 640, "長さ全チェック" );

            // 表の右にあるコントロールを作成
            MakeLabel( ref label6, 830, 40, "番組名" );
            MakeTextbox( ref tbxProgName, "TbxProgName", true, 830, 64, 360, 60, "" );
            MakeLabel( ref label7, 830, 132, "放送日時" );
            MakeTextbox( ref tbxDateTime, "TbxDateTime", false, 900, 132, 120, 20, "" );
            MakeLabel( ref label8, 1040, 132, "長さ" );
            MakeTextbox( ref tbxDuration, "TbxDuration", false, 1070, 132, 120, 20, "" );
            MakeLabel( ref label9, 830, 160, "放送チャンネル" );
            MakeTextbox( ref tbxChannel, "TbxChannel", false, 930, 160, 80, 20, "" );
            MakeLabel( ref label10, 1020, 160, "放送局" );
            MakeTextbox( ref tbxOffice, "TbxOffice", false, 1070, 160, 120, 20, "" );
            MakeLabel( ref label11, 830, 188, "ジャンル" );
            MakeTextbox( ref tbxGenre, "TbxGenre", false, 884, 188, 306, 20, "" );
            MakeLabel( ref label12, 830, 216, "番組内容" );
            MakeTextbox( ref tbxCaption, "TbxCaption", true, 830, 240, 360, 424, "" );

            // 下部分のコントロールを作成
            MakeLineLabel( ref line2, 6, 674, 1180 );
            MakeLabel( ref label13, 10, 688, "3. リネーム・テキスト生成" );
            MakeButton( ref btnExec, "BtnExec", 190, 686, 110, 28, "　実行　" );
              btnExec.Enabled = false;
              btnExec.Click += Click_btnExec;
            MakeButton( ref btnCancel, "BtnCancel", 330, 686, 150, 28, "　リネームのキャンセル　" );
              btnCancel.Enabled = false;
              btnCancel.Click += Click_btnCancel;
            MakeButton( ref btnClear, "BtnClear", 1060, 686, 110, 28, "　全クリア　" );
              btnClear.Enabled = false;
              btnClear.Click += Click_btnClear;

            // ステータス表示部分のコントロールを作成
            MakeLineLabel( ref line3, 6, 718, 1180 );
            MakeLabel( ref label14, 10, 730, "状況・情報" );
            MakeTextbox( ref tbxStatus, "TbxStatus", true, 100, 730, 1088, 60, "" );
            statusText = "";

            // フォーム全体の設定
            this.Name = "formMain";
            this.Text = MyConstants.formName;
            this.AllowDrop = true;
            this.BackColor = Color.FromArgb( 0, 50, 30 );
            this.ForeColor = Color.FromArgb( 220, 250, 240 );
            this.ClientSize = new Size( 1200, 800 );
            this.ResumeLayout( false );
            this.PerformLayout();

            PrintStat( "プログラム開始しました" );
        }

        // ---------- ラベルコントロール作成 ----------
        private void MakeLabel( ref Label o, int xpos, int ypos, String text ) {
            o = new Label();
            o.AutoSize = true;
            o.Location = new Point( xpos, ypos );
            o.Font = new Font( label1.Font.OriginalFontName, 12f );
            o.Text = text;
            this.Controls.Add( o );
        }

        // ---------- 区切り線ラベルコントロール作成 ----------
        private void MakeLineLabel( ref Label o, int xpos, int ypos, int wid ) {
            o = new Label();
            o.AutoSize = false;
            o.Location = new Point( xpos, ypos );
            o.Size = new Size( wid, 2 );
            o.BorderStyle = BorderStyle.Fixed3D;
            o.BackColor = Color.FromArgb( 230, 230, 230 );
            o.Text = "";
            this.Controls.Add( o );
        }

        // ---------- テキストボックスコントロール作成 ----------
        private void MakeTextbox( ref TextBox o, String name, bool ml, int xpos, int ypos, int wid, int hei, String text ) {
            o = new TextBox();
            o.Name = name;
            o.Dock = DockStyle.None;
            o.BorderStyle = BorderStyle.Fixed3D;
            o.BackColor = Color.FromArgb( 230, 230, 230 );
            o.ForeColor = Color.FromArgb( 0, 0, 0 );
            o.Location = new Point( xpos, ypos );
            o.Size = new Size( wid, hei );
            o.ReadOnly = true;
            o.Text = text;
            if ( ml ) {
                o.ScrollBars = ScrollBars.Vertical;
                o.Multiline = true;
            }
            else {
                o.ScrollBars = ScrollBars.None;
                o.Multiline = false;
            }
            this.Controls.Add( o );
        }

        // ---------- ボタンコントロール作成 ----------
        private void MakeButton( ref Button o, String name, int xpos, int ypos, int wid, int hei, String text ) {
            o = new Button();
            o.Name = name;
            o.FlatStyle = FlatStyle.System;
            o.Location = new Point( xpos, ypos );
            o.Size = new Size( wid, hei );
            o.Font = new Font( btnSrcFolder.Font.OriginalFontName, 11f );
            o.Text = text;
            this.Controls.Add( o );
        }

        // ---------- チェックボックスコントロール作成 ----------
        private void MakeCheckBox( ref CheckBox o, int xpos, int ypos ) {
            o = new CheckBox();
            o.Location = new Point( xpos, ypos );
            o.Size = new Size( 16, 18 );
            o.Checked = false;
            o.Enabled = false;
            this.Controls.Add( o );
        }

        // ---------- コントロール非活性化 ----------
        private void DisableUI() {
            btnSrcFolder.Enabled = false;
            tblFiles.Enabled = false;
            btnExec.Enabled = false;
            btnCancel.Enabled = false;
            btnClear.Enabled = false;
            chkAllOffice.Enabled = false;
            chkAllDate.Enabled = false;
            chkAllDuration.Enabled = false;
        }

        // ---------- コントロール活性化 ----------
        private void EnableUI() {
            btnSrcFolder.Enabled = true;
            tblFiles.Enabled = true;
            if ( fileNumber > 0 ) {
              btnExec.Enabled = true;
              btnClear.Enabled = true;
              chkAllOffice.Enabled = true;
              chkAllDate.Enabled = true;
              chkAllDuration.Enabled = true;
            }
            if ( cancelable ) {
              btnCancel.Enabled = true;
            }
            else {
              btnCancel.Enabled = false;
            }
        }

        // ---------- ステータス表示 ----------
        private void PrintStat( String s ) {
            statusText += ( "[" + DateTime.Now + "] " + s + Environment.NewLine );
            tbxStatus.Text = statusText;
            tbxStatus.SelectionStart = tbxStatus.Text.Length;
            tbxStatus.Focus();
            tbxStatus.ScrollToCaret();
            //tbxStatus.Select( tbxStatus.Text.Length, 0 ); これでも最終行にスクロールするはずだが出来なかった
        }
    }
}
