## Save and Recovery ##

Resources直下のmagic_ring Prefabがセーブ機能または回復機能のprefabです。  

使い方はprefabをドラッグ&ドロップで置きたい場所に持っていき、
+ Only Save
+ Only Recovery
+ Save and Recovery

の中からモードを選びます。  
チェックボックス形式ですが一つだけ選んでください。  
複数選んだ場合の優先順位は上からになってます。  

Only Saveモードは自機が破壊された時のリスポーン位置を再設定するだけのものです。  
色はyellowです。  

Only Recoveryモードは自機の回復をするだけです。  
色はcyanです。

Save and Recoveryモードは位置の再設定と自機の回復の二つの機能を兼ね備えています。  
色はmagentaです。  

※配置した時の色は全てシアンになっていると思いますが、実行時にそれぞれのモードにあった色に変わります。  

位置のセーブ機能を使う場合は  
+ Rotation

に値を入れることで復帰時の向きを設定することができます。  
基本的にはyの値を変更するだけで良いです。  
また、単位はDegreeです。
