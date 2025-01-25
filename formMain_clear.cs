using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bdavren {
    public partial class formMain : Form {
        // ========== 全クリア ==========
        private void Click_btnClear( object sender, EventArgs e ) {
            DisableUI();
            ClearUI();
            ClearCommonObj();
            statusText = "";
            PrintStat( "全クリアしました" );
            EnableUI();
        }

        // --------- UI の内容をクリア ----------
        private void ClearUI() {
            tbxSrcFolder.Text = "";
            tblFiles.Rows.Clear();
            tbxProgName.Text = "";
            tbxDateTime.Text = "";
            tbxDuration.Text = "";
            tbxChannel.Text = "";
            tbxOffice.Text = "";
            tbxGenre.Text = "";
            tbxCaption.Text = "";
            btnExec.Enabled = false;
            btnCancel.Enabled = false;
            chkAllOffice.Checked = false;
            chkAllDate.Checked = false;
            chkAllDuration.Checked = false;
            chkAllOffice.Enabled = false;
            chkAllDate.Enabled = false;
            chkAllDuration.Enabled = false;
        }

        // ---------- 共通使用のオブジェクトをクリア ----------
        private void ClearCommonObj() {
            sPath = "";
            fileNumber = 0;
            sPathFiles = Array.Empty<String>();
            sFilenames.Clear();
            programnames.Clear();
            channels.Clear();
            offices.Clear();
            dates.Clear();
            times.Clear();
            durations.Clear();
            genres.Clear();
            captions.Clear();
            oFilenames.Clear();
            oFilenameSuffixes.Clear();
            cancelable = false;
        }

    }
}
