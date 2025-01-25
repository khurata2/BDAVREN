# BDAVREN
Windows EXE, renaming BDAV 0000x.m2ts to NormalFilename.m2ts using rplsinfo.exe

BDAVREN - rplsinfo GUI wrapper version 1.0.0 (2025/01) for Windows 10 64bit 日本語版

概要説明
  BDAV の m2ts 内容に基づいて、ファイル名を番組名にリネームしたり、内容説明テキストファイルを生成する rplsinfo の GUI ラッパー。

動作条件
・本プログラムの動作には rplsinfo が必要である。本プログラムと同じフォルダーに rplsinfo.exe を配置すること。

ビルド方法
  全てのソースファイル（拡張子 .cs）を含むフォルダーでコマンドプロンプトを開き、以下のコマンドを実行する。
  C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /t:winexe *.cs
  そのフォルダーに BDAVREN.exe が生成されるので、それを実行すればよい。

注意事項
・処理できるファイルの個数上限は 100 であるが、maxFiles の初期値を書き換えてビルドすれば変えられる。
・リネームされるファイル名は "[放送日][放送局名] 番組名 (長さ).m2ts" という形式だが、
  放送日、放送局名、ファイル名、長さ、それぞれの順番は、プレースホルダ pfFilename を書き換えてビルドすれば変えられる。
・rplsinfoOption 内のオプション順は、メソッド Click_btnSrcFolder() 内の CSVparser.reader() 処理順と関連しているので、追加、変更する際は要注意。
・ファイル名に使えない文字や使いたくない文字は unsafes に定義されている。この各文字は safes で置き換えられる。
  これらのうち使いたくない文字は作者の主観なので、書き換えてビルドしても構わない。

参考資料
・rplsinfo について
  https://github.com/tsukumijima/rplsinfo/tree/master?tab=readme-ov-file
  https://github.com/tsukumijima/rplsinfo/blob/master/rplsinfo.txt

改版履歴
ver. 1.0.0   (2025.01)　初版。

All Copyright (C) 2025 khurata2
