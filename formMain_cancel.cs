using System;
using System.Windows.Forms;
using System.IO;

namespace bdavren {
    public partial class formMain : Form {
        // ========== リネーム・テキストファイル生成をキャンセル ==========
        private void Click_btnCancel( object sender, EventArgs e ) {
            DisableUI();
            cancelable = false;
            if ( fileNumber < 1 ) {
                EnableUI();
                return;
            }

            PrintStat( "リネームをキャンセルします" );
            for ( int i = 0; i < fileNumber; i += 1 ) {
                PrintStat( "ren \"" + sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".m2ts\" \"" + sPath + sFilenames[ i ] + "\"" );
                File.Move( sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".m2ts", sPath + sFilenames[ i ] );
            }
            PrintStat( "リネームをキャンセルしました" );

            PrintStat( "テキストファイルを削除します" );
            for ( int i = 0; i < fileNumber; i += 1 ) {
                PrintStat( "del \"" + sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".txt\"" );
                File.Delete( sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".txt" );
            }
            PrintStat( "テキストファイルを削除しました" );

            oFilenames.Clear();
            oFilenameSuffixes.Clear();
            EnableUI();
        }

    }
}
