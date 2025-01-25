using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bdavren {
    public partial class formMain : Form {
        // ========== class 内で共通に使う定義 ==========

        private String sPath; // 処理すべき .m2ts ファイルの格納パス
        private int fileNumber; // 処理すべき .m2ts ファイルの個数
        private String [] sPathFiles; // Directory.GetFiles() で得られる .m2ts ファイルのフルパス名

        private List<String> sFilenames = new List<String>(); // .m2ts ファイル名（パス含まず）
        private List<String> programnames = new List<String>(); // 番組名
        private List<String> channels = new List<String>(); // チャンネル名
        private List<String> offices = new List<String>(); // 放送局名
        private List<String> dates = new List<String>(); // 放送日
        private List<String> times = new List<String>(); // 放送時刻
        private List<String> durations = new List<String>(); // 長さ
        private List<String> genres = new List<String>(); // ジャンル
        private List<String> captions = new List<String>(); // 番組説明（番組情報と番組詳細情報を合わせたもの）

        private List<String> oFilenames = new List<String>(); // 出力用ファイル名（拡張子を含まず）、.m2ts リネームと .txt 生成に使う
        private List<String> oFilenameSuffixes = new List<String>(); // 出力用ファイル名に後置する重複表示文字列、.m2ts リネームと .txt 生成に使う

        private bool cancelable = false; // リネームのキャンセルが出来るかどうか

        private String statusText; // 状況表示文字列

    }
}
