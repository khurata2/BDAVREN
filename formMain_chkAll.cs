using System;
using System.Windows.Forms;

namespace bdavren {
    public partial class formMain : Form {
        // ========== 表の全チェック用のチェックボックス処理 ==========

        // ---------- 放送局名全チェック ----------
        private void Click_chkAllOffice( object sender, EventArgs e ) {
            bool chk = chkAllOffice.Checked;
            for ( int i = 0; i < fileNumber; i += 1 ) {
                tblFiles.Rows[ i ].Cells[ "tblFilesColChkOffice" ].Value = chk;
            }
            PrintStat( "放送局名" + ( chk ? "を全てチェックしました" : "のチェックを全て外しました" ) );
        }

        // ---------- 放送日全チェック ----------
        private void Click_chkAllDate( object sender, EventArgs e ) {
            bool chk = chkAllDate.Checked;
            for ( int i = 0; i < fileNumber; i += 1 ) {
                tblFiles.Rows[ i ].Cells[ "tblFilesColChkDate" ].Value = chk;
            }
            PrintStat( "放送日" + ( chk ? "を全てチェックしました" : "のチェックを全て外しました" ) );
        }

        // ---------- 長さ全チェック ----------
        private void Click_chkAllDuration( object sender, EventArgs e ) {
            bool chk = chkAllDuration.Checked;
            for ( int i = 0; i < fileNumber; i += 1 ) {
                tblFiles.Rows[ i ].Cells[ "tblFilesColChkDuration" ].Value = chk;
            }
            PrintStat( "長さ" + ( chk ? "を全てチェックしました" : "のチェックを全て外しました" ) );
        }

    }
}
