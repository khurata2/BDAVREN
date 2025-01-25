using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text; // Encoding

namespace bdavren {
    public partial class formMain : Form {
        // ========== 処理対象のフォルダーにある m2ts ファイルを rplsinfo データに随いリネームし、テキストファイルを生成 ==========

        // ---------- リネーム・テキストファイル生成実行 ----------
        private void Click_btnExec( object sender, EventArgs e ) {
            DisableUI();
            MakeOutputFilenames(); // 出力用のファイル名を作成
            PrintStat( "m2ts リネームを実行します" );
            RenameM2tsFiles();
            PrintStat( "m2ts リネームを実行しました" );
            PrintStat( "テキストファイルを生成します" );
            MakeTextFiles();
            PrintStat( "テキストファイルを生成しました" );
            cancelable = true; // 今の時点でキャンセル可能となった
            EnableUI();
        }

        // ---------- 表の状況を基に出力用ファイル名配列を作る ----------
        private void MakeOutputFilenames() {
            for ( int i = 0; i < fileNumber; i += 1 ) {
                String oFilename1 = MyConstants.phFilename.Substring( 0, MyConstants.phFilename.Length ); // String.Copy() は非推奨 cf. https://learn.microsoft.com/ja-jp/dotnet/api/system.string.copy?view=net-9.0
                // 放送日
                String date = "";
                if ( ( bool )tblFiles.Rows[ i ].Cells[ "tblFilesColChkDate" ].Value ) {
                    date = "[" + dates[ i ].Replace( "/", "." ) + "]";
                }
                String oFilename2 = setPlaceHolder( oFilename1, "date", date );
                // 放送局名
                String office = "";
                if ( ( bool )tblFiles.Rows[ i ].Cells[ "tblFilesColChkOffice" ].Value ) {
                    office = "[" + replaceSafeFilenameStr( offices[ i ] ) + "]";
                }
                String oFilename3 = setPlaceHolder( oFilename2, "office", office );
                // 番組名
                String programname = ( ( date.Length > 0 || office.Length > 0 ) ? " " : "" ) + replaceSafeFilenameStr( programnames[ i ] );
                String oFilename4 = setPlaceHolder( oFilename3, "programname", programname );
                // 長さ
                String duration = "";
                if ( ( bool )tblFiles.Rows[ i ].Cells[ "tblFilesColChkDuration" ].Value ) {
                    String [] durationStrs = durations[ i ].Split( ':' );
                    duration = replaceSafeFilenameStr( " (" + durationStrs[ 0 ] + "h" + durationStrs[ 1 ] + "m" + durationStrs[ 2 ] + "s)" );
                }
                String oFilename5 = setPlaceHolder( oFilename4, "duration", duration );
                oFilenames.Add( oFilename5 ); // プレースホルダ処理済みのファイル名を蓄積
                oFilenameSuffixes.Add( "" ); // ファイル名重複対応用の後置文字列を初期化して蓄積
            }
        }

        // ---------- 出力用ファイル名配列を基に m2ts ファイルをリネームする ----------
        private void RenameM2tsFiles() {
            for ( int i = 0; i < fileNumber; i += 1 ) {
                if ( File.Exists( sPath + oFilenames[ i ] + ".m2ts" ) ) { // 重複チェック
                    int s = 1;
                    oFilenameSuffixes[ i ] = "(" + s.ToString() + ")";
                    while ( File.Exists( sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".m2ts" ) ) { // 重複しなくなるまで後置した (数字) をインクリメントする
                        s += 1;
                        oFilenameSuffixes[ i ] = "(" + s.ToString() + ")";
                    }
                    // 重複が見つからなくなればリネーム
                    PrintStat( "ren \"" + sPath + sFilenames[ i ] + "\" \"" + sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".m2ts\"" );
                    File.Move( sPath + sFilenames[ i ], sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".m2ts" );
                }
                else { // 重複していなければそのままリネーム
                    PrintStat( "ren \"" + sPath + sFilenames[ i ] + "\" \"" + sPath + oFilenames[ i ] + ".m2ts\"" );
                    File.Move( sPath + sFilenames[ i ], sPath + oFilenames[ i ] + ".m2ts" );
                }
            }
        }

        // ---------- 出力用ファイル名配列を基にテキストファイルを生成する ----------
        private void MakeTextFiles() {
            for ( int i = 0; i < fileNumber; i += 1 ) {
                PrintStat( "create \"" + sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".txt\"" );
                using ( StreamWriter wFile = new StreamWriter( sPath + oFilenames[ i ] + oFilenameSuffixes[ i ] + ".txt", false, Encoding.UTF8 ) ) {
                    wFile.WriteLine( "番組名：" + programnames[ i ] +
                                     "\n放送日：" + dates[ i ] + "\n放送時間：" + times[ i ] + "\n長さ：" + durations[ i ] +
                                     "\nチャンネル：" + channels[ i ] + "\n放送局：" + offices[ i ] +
                                     "\nジャンル：" + genres[ i ] +
                                     "\n\n" + captions[ i ] );
                } // 自動的に Close() される
            }
        }

        // ---------- 与えられた文字列をファイル名として安全かつ使いたい文字列にして返す ----------
        private String replaceSafeFilenameStr( String s ) {
            return replaceChars( s, MyConstants.unsafes, MyConstants.safes );
        }

        // ---------- 対応文字列を元にテキストファイル内の文字を置換して返す関数 ----------
        private String replaceChars( String str, String src, String obj ) {
            if ( src.Length != obj.Length || str.Length < 1 || src.Length < 1 ) {
                return str;
            }
            String o = "";
            bool replaced = false;
            for ( int i = 0; i < str.Length; i += 1 ) {
                for ( int j = 0; j < src.Length; j += 1 ) {
                    if ( str.Substring( i, 1 ) == src.Substring( j, 1 ) ) {
                        o += obj.Substring( j, 1 );
                        replaced = true;
                        break;
                    }
                }
                if ( replaced ) {
                    ;
                }
                else {
                    o += str.Substring( i, 1 );
                }
                replaced = false;
            }
            return o;
        }

        // ---------- プレースホルダを展開する関数 ----------
        private String setPlaceHolder( String ph, String id, String s ) {
            int i;
            if ( ( i = ph.IndexOf( "?" + id + "?" ) ) < 0 ) { // id を探索する
                return s; // 展開されず
            }
            String [] splitters = { "?" + id + "?" };
            String [] ss = ph.Split( splitters, StringSplitOptions.None ); // id で分割する
            String ns = ss[ 0 ];
            for ( i = 1; i < ss.Length; i += 1 ) {
                ns += ( s + ss[ i ] );
            }
            return ns;
        }

    }
}
