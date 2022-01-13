# AdolescenceNovel

## 目次
- [データ一覧](#data)
- [アニメーション番号](#animationNum)
- [テキスト表示](#ShowText)
- [コマンド一覧](#command)
    - [画像関係](#sprite)
    - [マルチメディア関係](#sound)
    - [システム関係](#system)
    - [テキスト関係](#text)
- [応用的な処理](#advanced)



<a id="data"></a>

## データ一覧
    数値:整数全体
    文字列:ダブルクォーテーション(")で囲まれた文字全体
    論理値:true/false
    色コード:#000000~#FFFFFF

<a id="animationNum"></a>

## アニメーション番号
    1:  即表示
    10: フェードイン
残りのアニメーション番号は、Assets/Resources/Fadeにあるルール画像を利用する。番号はルール画像の名前に依存する。

<a id="command"></a>

## テキスト表示
通常の画像表示を行う時に特別なコマンドは必要としない。しかし、半角英数字から始まる事は許可しない。

    こんにちは
また、\[\]から始まる場合、その中の文字列は名前表示として用いられる。

    [私]こんにちは
ルビをつける際は、ルビを振る文字列とルビを/で区切り、これを半角過去()で囲む。

    (超電磁砲/レールガン)


## ラベル

アスタリスクから始まる半角英文字で構成されたタグをラベルとして用いることが出来る。

    *test


## コマンド一覧

<a id = "sprite"></a>

### 画像関係
<a id="background"></a>

#### バックグラウンド表示
```bg 色コード/画像パス```

```bg 色コード/画像パス,アニメーション番号```

```bg 色コード/画像パス,アニメーション番号,アニメーション時間```

    bg #000000,1
    バックグラウンド表示：１
    bg #FFFFFF,10,1000
    バックグラウンド表示：２
    bg "TestImage/background",1
    バックグラウンド表示：３
    bg "TestImage/background2",10,1000
    バックグラウンド表示：４

<a id="showpicture_staticplace"></a>

#### 固定位置画像表示
```ld 位置指定,画像パス```

```ld 位置指定,画像パス,アニメーション番号```

```ld 位置指定,画像パス,アニメーション番号,アニメーション時間```

    ld l,"TestImage/test2",1
    画像表示（固定）：１
    ld r,"TestImage/test1",10,1000
    画像表示（固定）：２

#### 画像消去(固定位置)
```cl 位置指定```

```cl 位置指定,アニメーション番号```

```cl 位置指定,アニメーション番号,アニメーション時間```

    cl l,1
    画像消去（固定）：１
    cl r,10,1000
    画像消去（固定）：２

#### 位置指定画像表示(表示状態)
```lsp 画像変数,画像パス,x座標,y座標```

    lsp rightPicture,"TestImage/test1",0,0

#### 位置指定画像表示(非表示状態)
```lsph 画像変数,画像パス,x座標,y座標```

    lsph leftPicture,"TestImage/test2",0,100

#### 表示状態変更
``` vsp 表示状態```

    vsp 1

#### 位置指定画像消去
```csp```

```csp 画像変数```

    csp rightPicture

#### 表示処理
```print アニメーション番号```

```print アニメーション番号,アニメーション時間```

    print 1

#### 画像移動
``` msp 画像変数,x座標,y座標```

    msp rightPicture,0,100


<a id = "sound"></a>

### マルチメディア関係

#### バックグラウンドミュージック再生
``` bgm 音声パス```

``` bgm 音声パス,音声タグ```

    bgm "TestSound/test1"
    bgm "TestSound/test1",Main

#### バックグラウンドミュージック停止
``` bgmstop```

    bgmstop


#### サウンドエフェクト再生
``` se 音声パス```

``` se 音声パス,音声タグ```

    se "TestSound/test2"
    se "TestSound/test2",Main

#### 動画再生
``` movie 動画パス```

    movie "TestMovie/test1"
<a id="system"></a>


### システム関係

#### ラベルジャンプ

```goto ラベル名```

    goto *title

#### ボタン定義

``` defbutton ボタン変数,幅,高さ,ボタン通常画像パス```

``` defbutton ボタン変数,幅,高さ,ボタン通常画像パス,ボタン選択時画像パス```

``` defbutton ボタン変数,幅,高さ,ボタン通常画像パス,ボタン選択時画像パス,ボタン通常フォント,ボタン選択時フォント```

    defbutton firstButton,100,50,"TestImage/textbox"

#### ボタン出力

``` button ボタン変数,x座標,y座標,表示文字,ラベル ```

    button firstButton,0,0,"Hello",*First

#### ボタン選択

``` select```

``` select 出力テキストボックス,文字列,文字列,...```

    select

    select testBox,"町","学校"



<a id="text"></a>

### テキスト関係

#### テキストボックス定義

``` textdef テキスト変数,画像パス,x座標,y座標,画像幅,画像高さ,オフセットx,オフセットy,テキストボックスの幅,テキストボックスの高さ,フォントの大きさ```
 
    textdef testBox,"TestImage/textbox",0,0,100,50,0,0,100,50,100

#### テキストボックス文字列描画

``` textwrite テキスト変数,出力内容,フォントの大きさ,フォントの色,フォント名```

    textwrite testBox,"こんにちは",50,#000000,"font/NotoSansJP-Black_SDF-large"

#### テキストボックスの表示

```texton```

```texton テキスト変数```

    texton
    texton testBox

#### テキストボックスの非表示

```textoff```

```textoff テキスト変数```

    textoff
    textoff testBox

#### フッター登録

```footerregist 画像パス,内容,画像の高さ,フォント名,フォントサイズ,オフセットx座標,オフセットy座標```

    footerregist "TestImage/textbox","これがフッターです",60,"font/NotoSansJP-Black_SDF-large",50,0,0

#### フッター表示

``` footeron ```

    footeron
<a id="advanced"></a>


### 応用的な使い方

#### 変数
小文字から始まる英文字で変数を定義することが出来ます。変数には文字列、数値、論理値の三種類を格納することが可能です。

#### 代入
代入は=で行うことが出来ます

    a = 100
    b = "hello"
    c = true

#### 条件分岐

```
if(条件式){
    内容記述
}
if(条件式)
{
    内容記述
}
```
#### 繰り返し処理

```
for(初期化,継続条件,更新処理)
{
    内容記述
}
for(初期化,継続条件,更新処理){
    内容記述
}
```