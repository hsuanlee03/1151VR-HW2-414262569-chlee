1.	螢幕截圖
 
2.	GitHub連結
https://github.com/hsuanlee03/1151VR-HW2-414262569-chlee
3.	YouTube連結
https://youtu.be/rh5brBkNFas
4.	說明製作流程和相關操作
<專案開啟>
1.開啟Unity
2.建立2D專案
<腳色與背景>
1.上網下載免費腳色與背景
2.依據動作更改重新處理檔案(如圖)
    
(由左至右分別是：左/右移動1、左右移動2、上跳、下跳)
<背景設置>
1.在Hierarchy按左鍵並選取【create empty】，將名稱改為BackgroundManager
2.在這個檔案中新增所需數量的sprite
3.在sprite中新增處理好的背景圖片
<腳色設置>
1.將選定的腳色拉入畫面中，並在Hierarchy中將名稱改成Player。
2.在Inspector中新增【Sprite Renderer】，並把圖層數值設為1(避免被背景遮住)。
3.在Inspector中新增【Rigidbody 2D】，並勾選【Freeze Rotation】(z軸)。
4.在asset資料夾中新增【script】，並修改名稱成Myscript。
5.撰寫腳本
根據我所希望的呈現方式，我寫了讓腳色能左右移動和上下跳動的腳本，並讓腳色在左右移動皆能切換圖片，也讓腳色在上跳及下跳後能恢復成一開始的動作。
6.程式完成後，將Myscript拉入Player中。
7.可執行程式。
<終點設立>
1.將終點物件拉進畫面中
2.我在終點物件的Inspector介面中新增【Box collider 2D】，勾選【is trigger】，並同時將Player最上方的【tag】改成Player。(Player觸碰到終點物件便能啟動程式)
2. 在asset資料夾中新增script，並修改名稱成Goalflag。
3.撰寫腳本
我寫了當腳色觸碰到終點物件能夠喚起「音效」和「彩帶特效」的腳本。
<彩帶特效>
1.	將滑鼠移到 【Visual Effects】
2.	在右側子選單中點擊 【Particle System】（粒子系統）
3.	將這個檔案移動到flag裡，並更改參數和顏色
4.	調整好後，在 Inspector 視窗最上方，點【Play On Awake】(避免彩帶一開始就放完)
5.	困境
	一開始在編寫Player的腳本時，我參照教科書上的內容，但畫面一直出現紅色驚嘆號，查找資料後發現教科書上的內容已經變成舊版的寫法，於是我參考資料，修正腳本。
	寫完Player的腳本時，我想測試腳本卻發現Player並不會移動，最後在Inspector確認時才發現腳本並沒有放在對的位置。
	Player能移動時，我發現Player到了右邊界會消失，於是我把Camera放進Player中，畫面就會跟著腳色移動了。
