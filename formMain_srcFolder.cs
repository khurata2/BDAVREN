using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq; // System.Array.Count()
using System.Diagnostics; // ProcessStartInfo

namespace bdavren {
    public partial class formMain : Form {
        // ========== 処理対象のフォルダーを参照して rplsinfo でデータを読み取り保持 ==========
        private String rplsinfoPathFile;

        // ---------- フォルダー参照 ----------
        private void Click_btnSrcFolder( object sender, EventArgs e ) {
            String srcFolder;
            // フォルダー選択ダイアログ処理
            using ( FolderBrowserDialog fbd = new FolderBrowserDialog() ) {
                if ( fbd.ShowDialog( this ) == DialogResult.OK ) {
                    srcFolder = fbd.SelectedPath;
                    PrintStat( "フォルダー " + srcFolder + " が選択されました" );
                }
                else {
                    PrintStat( "フォルダーが選択されませんでした" );
                    MessageBox.Show( "フォルダーが選択されませんでした" );
                    return;
                }
            }

            // フォルダー選択後の初期化
            ClearUI();
            ClearCommonObj();
            sPath = srcFolder + "\\";
            tbxSrcFolder.Text = sPath;

            // 選択したフォルダーから m2ts ファイルを読み取って rplsinfo により情報を取得
            DisableUI();
            DirectoryInfo di = new DirectoryInfo( tbxSrcFolder.Text );
            if ( di.Exists ) {
                sPathFiles = Directory.GetFiles( tbxSrcFolder.Text, "*.m2ts" );
                if ( sPathFiles.Count() > 0 ) { // 処理対象の .m2ts ファイルが１個以上見つかった
                    fileNumber = sPathFiles.Count();
                    String myPath = System.IO.Path.GetDirectoryName( System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName );
                    rplsinfoPathFile = myPath + "\\rplsinfo.exe";
                    for ( int i = 0; i < fileNumber && i < MyConstants.maxFiles; i += 1 ) {
                        PrintStat( sPathFiles[ i ] + " から rplsinfo で情報を取得します" );
                        ProcessStartInfo psi = new ProcessStartInfo {
                          ErrorDialog = true,
                          FileName = rplsinfoPathFile,
                          Arguments = sPathFiles[ i ] + " " + MyConstants.rplsinfoOption,
                          CreateNoWindow = true,
                          RedirectStandardOutput = true,
                          UseShellExecute = false
                        };
                        Process p = Process.Start( psi );
                        p.WaitForExit();
                        String rplsinfoCSV = p.StandardOutput.ReadToEnd();
                        // 得られた CSV から各フィールドを読み取る
                        CSVdoubleQuoteParser CSVparser = new CSVdoubleQuoteParser( rplsinfoCSV );
                        sFilenames.Add( CSVparser.reader() );
                        dates.Add( CSVparser.reader() );
                        times.Add( CSVparser.reader() );
                        durations.Add( CSVparser.reader() );
                        offices.Add( CSVparser.reader() );
                        channels.Add( CSVparser.reader() );
                        genres.Add( CSVparser.reader() );
                        programnames.Add( CSVparser.reader() );
                        String caption = CSVparser.reader() + Environment.NewLine + Environment.NewLine;
                        caption += CSVparser.reader();
                        captions.Add( caption );
                        // 得られた各フィールド内容をテーブルに配置する
                        tblFiles.Rows.Add();
                        tblFiles.Rows[ i ].Cells[ "tblFilesColIdx" ].Value = ( i + 1 ).ToString();
                        tblFiles.Rows[ i ].Cells[ "tblFilesColSfilename" ].Value = sFilenames[ i ];
                        tblFiles.Rows[ i ].Cells[ "tblFilesColProgramname" ].Value = programnames[ i ];
                        tblFiles.Rows[ i ].Cells[ "tblFilesColChkOffice" ].Value = false;
                        tblFiles.Rows[ i ].Cells[ "tblFilesColOffice" ].Value = offices[ i ];
                        tblFiles.Rows[ i ].Cells[ "tblFilesColChkDate" ].Value = false;
                        tblFiles.Rows[ i ].Cells[ "tblFilesColDate" ].Value = dates[ i ];
                        tblFiles.Rows[ i ].Cells[ "tblFilesColChkDuration" ].Value = false;
                        tblFiles.Rows[ i ].Cells[ "tblFilesColDuration" ].Value = durations[ i ];
                    }
                    PrintStat( "全部で " + fileNumber.ToString() + " 個のファイル情報を取得しました" );
                }
                else {
                    PrintStat( "処理対象の .m2ts ファイル無し" );
                    MessageBox.Show( "処理対象の .m2ts ファイルが見つかりませんでした" );
                }
            }
            else { // このルートに来る事はまず無い
                PrintStat( "存在しないフォルダーを処理しようとしました（プログラム異常）" );
                MessageBox.Show( "存在しないフォルダーを処理しようとしました（プログラム異常）" );
            }
            EnableUI();
        }

        // ---------- テーブルクリックイベントによって詳細データを表示したりチェックボックスを変更する ----------
        private void CellClick_tblFiles( object sender, DataGridViewCellEventArgs e ) {
            DataGridView dgv = sender as DataGridView;
            if ( dgv != null ) {
                int y = e.RowIndex;
                if ( y >= 0 && y < fileNumber ) {
                    // 詳細データ表示
                    tbxProgName.Text = programnames[ y ];
                    tbxDateTime.Text = dates[ y ] + "-" + times[ y ];
                    tbxDuration.Text = " " + durations[ y ];
                    tbxChannel.Text = channels[ y ];
                    tbxOffice.Text = " " + offices[ y ];
                    tbxGenre.Text = " " + genres[ y ];
                    tbxCaption.Text = captions[ y ];
                    PrintStat( ( y + 1 ).ToString() + " 行目の詳細情報を表示しました" );
                    // チェックボックス操作（通常の操作だとダブルクリックしなければならないので自力実装）
                    int x = e.ColumnIndex;
                    if ( x == 3 || x == 5 || x == 7 ) { // "tblFilesColChkOffice" or "tblFilesColChkDate" or "tblFilesColChkDuration"
                        if ( ( bool )dgv.Rows[ y ].Cells[ x ].Value ) {
                            dgv.Rows[ y ].Cells[ x ].Value = false;
                        }
                        else {
                            dgv.Rows[ y ].Cells[ x ].Value = true;
                        }
                        cancelable = false;
                        btnCancel.Enabled = false;
                        dgv.Refresh();
                    }
                }
            }
            else { // まず有り得ないルート
                PrintStat( "DataGridView オブジェクト異常です" );
                MessageBox.Show( "DataGridView オブジェクト異常です" );
            }
        }

    }
}
