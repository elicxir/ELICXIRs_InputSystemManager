EISM:ELICXIRs_InputSystemManager

Copyright (c) 2022 ELICXIR
Released under the MIT license
https://opensource.org/licenses/mit-license.php


概要

Input System Packageを簡単に導入するためのアセット

Input System Packageの利点について
・各種キーボードやコントローラーを統一的に扱える。
・キーボード、コントローラーごとにマッピングを分けることができる。
・コントローラーのABXYの配置の違いを無視して設定できる。

EISMの特徴
・導入するだけでキーボード&ゲームパッドに対応した入力判定を使用可能。
・ボタン入力(入力の有無を見るデジタル的な入力)のみに対応している。
・トリガーやスティックなどのアナログ入力もデジタル入力として扱われる。
・タッチパネルやマウス入力は非対応。


使用方法

PackageManagerからInputSystemを導入してください。
Project Settings のPlayer / Other Settings / Active Input Handling を Input System Package (New) または BothにすることによりInputSystemを有効化できます。
その後、当機能をプロジェクトに導入してください。
InputSystemManager.prefabをシーン上に設置することにより準備は完了です。

ゲーム起動時にInit()を呼び出し、以降はUpdater()を呼び出すことにより入力を更新できます。

Updaterは毎フレーム呼び出すことを基本としています。GameManagerなどのUpdate()関数に処理を追加しておくとよいでしょう。

更新した入力は3つの関数Button(),ButtonUp(),ButtonDown()により扱うことができます。

Control(InputSystemManager.cs L149)はInputActions.inputactionsに対応する列挙型の変数で、
初期状態では以下の8つの入力が設定されています。(左から順に入力名,キーボードの対応,ゲームパッドの対応)
ゲームパッドはXBOXコントローラーを基準に表記しているため注意。

・Button1 : space : Aボタン
・Button2 : z     : Bボタン
・Button3 : x     : Xボタン
・Button4 : c     : Yボタン
・Up      : ↑    : スティックor十字キー 上
・Down    : ↓    : スティックor十字キー 下
・Right   : →    : スティックor十字キー 右
・Left    : ←    : スティックor十字キー 左

この値をbool型関数Button(),ButtonUp(),ButtonDown()の引数として渡すことで該当の入力を判定することができます。

Button()はButton()が呼ばれたときに該当の入力があればtrueを返し、そうでなければfalseを返します。
ButtonUp()は呼ばれたときに該当の入力が終了していればtrueを返し、そうでなければfalseを返します。
ButtonDown()は呼ばれたときに該当の入力が開始していればtrueを返し、そうでなければfalseを返します。

平たく言えばUpは入力を放した瞬間、Downは入力を開始した瞬間を検知できます。


InputSystemManager.cs L66により、ボタンが入力された際にログを出力します。不要なら削除してください。


InputArrow()関数について
Up,Down,Right,Leftの入力をVector2形式でまとめて取得できます。十字キーの入力を見る際に便利です。相反する方向がともに入力されている場合は0(入力なし)を出力します。


Controlの追加について
InputActions.inputactionsを編集した後は、Control(InputSystemManager.cs L149)をActions名(InputActions.inputactionsの中央列の緑の項目)と一致させてください。Actionsを追加or削除したときのみではなく、名前を変更したときにも操作が必要です。
例えば新しくButton5を追加したらControl側にもButton5という値を追加してください。

