/// " で囲まれて , などの文字で区切られた CSV 文字列を与え、１フィールドずつ読み出すクラスとメソッド
/// 区切り文字は " 以外なら何でも構わない
/// フィールド内容に \" や改行などが含まれていてもそのまま読み出す
/// あくまで " で囲まれた部分文字列を１フィールドとして読み出す

using System;

public class CSVdoubleQuoteParser {
    private String srcStr;

    public CSVdoubleQuoteParser( String CSVstring ) {
        srcStr = CSVstring;
    }

    public String reader() { // １要素ずつ読み取るメソッド
        String field = "";
        int idxHead = 0;
        int idxTail = 0;
        // まず最初にあるべき " を探索
        while ( srcStr.Substring( idxHead, 1 ) != "\"" ) {
            idxHead += 1; // カンマなども読み飛ばす
            if ( ( idxHead + 1 ) >= srcStr.Length ) { // 見つからなければヌル文字列配列を返す
                return field;
            }
        }
        idxHead += 1; // 最初にあった " を読み飛ばす
        idxTail = idxHead;
        // " が先にあるか、\" が先にあるかを調べる
        int idxQuote = srcStr.IndexOf( "\"", idxTail );
        int idxEscQuote = srcStr.IndexOf( "\\\"", idxTail );
        if ( idxQuote > -1 && idxEscQuote > -1 && idxQuote > idxEscQuote ) { // \" も " もあって、かつ \" が " よりも前にある
            idxTail = idxQuote + 1; // 読み飛ばす
        }
        else {
            if ( idxQuote > -1 && idxEscQuote > -1 && idxQuote < idxEscQuote ) { // \" も " もあって、かつ \" が " よりも後にある、１要素が切り出せる
                idxTail = idxQuote - 1;
            }
            else {
                if ( idxQuote > -1 && idxEscQuote == -1 ) { // " だけあるなら、１要素が切り出せる
                    idxTail = idxQuote - 1;
                }
                else { // それ以外ならデータ異常
                    return field;
                }
            }
        }
        // この時点で idxHead と idxTail は確定しているが、より先の要素があるかどうかは分かっていない
        field = srcStr.Substring( idxHead, idxTail - idxHead + 1 ); // 確定しているので１要素を切り出す
        srcStr = srcStr.Substring( idxTail + 1 + 2 ); // " と , で２文字を飛ばして保存する
        return field;
    }
}
