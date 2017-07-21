# SweepBoom
Game SweepBoom created by CSharp

---

# Development Tool
Microsoft Visual Studio Community 2015

---

# Framework Description
![frame.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/frame.png)
由软件功能架构图可以看出，界面主要由登录界面、注册界面、主界面、难度选择界面以及排行榜界面组成。其中，登录界面运用了流行的设计，有注册功能按钮以及免注册直接玩游戏按钮，满足玩家两种心态的需求，是该游戏最人性化的设计。注册界面追求简洁。主界面通过检测玩家所选择的难度，来决定自己的雷区大小以及雷数。难度选择方面除了简陋的3种选择，更智能化地添加了自定义模式。在排行榜上，可以看出每个用户在玩此游戏中的记录排行榜。

---

# Class Design and Description
![des1](https://github.com/kwongtailau/SweepBoom/blob/master/image/des.png)
先分析三个类，分别是登录界面的`loginDlg`、主界面`Form1`、难度选择界面的`modelChooseDlg`：

其中，在类`LoginDlg`中，重要的字段有`loginUserName`与`loginPassWord`，两个变量设置为静态，以便供给其他类使用，例如在操作数据库的时候，用作标记。而重要的方法有`loginSureButton_Click`与`nonRegister_click`，两者最终结果是连接到主界面，但区别就是前者需要正确用户和密码登录，而后者不需要，作为后果，就是登录的用户的记录会记录到游戏记录排行当中，而免登录的因为没有提供静态的`loginUserName`而无法操作数据库。

在类`Form1`中,通过设置参数`BoomCount`,与`BoomSize`构造出不同难度的主界面，其中`sweepBoomCount`是记录当前用户所排除的雷数.重要的几个方法是：

- `BtnLeft_Click`:该方法允许用户通过鼠标左击事件，进行对雷的点开，如果点中雷，游戏结束；

- `BtnLeft_OnMouseDoubleClick`：提供用户通过鼠标双击事件，把已经确定的雷附近8个为揭开确定不是雷的button的翻开，如果用户排错雷，立刻游戏结束； 

- `BtnRight_Click`：提供用户通过鼠标右击事件，达到标记雷的作用。再点击，即取消标记；
- `checkGame`：该方法的作用，确定用户每完成一次点击之后是否达到了排完全部雷，如果排完全部雷的，就通过判断该用户是否登录了，如果已经登录则记录该用户的数据到数据库当中，否则`return`，继续监测是否排光雷；
- `newform`：它通过监控`modelChooseDlg`中的`SetModel`来选择new出一个新的`Form1`，此处作为一个线程的启动方法起着重要的作用，用过线程实现对旧的Form1的摧毁； 
- `timer1_Tick`：该方法这是记录显示的时间，设置每次的时间为1000毫秒。

在`modelChooseDlg`类中，我设置了静态字段`setBoomCount`、`setBoomSize`、`setModel`以达到传值的作用。起初，设置以上三个为默认的简单模式的参数，通过监控用户选择的`radioButton`来设置不同的值，以达到变化，改变主界面的大小，雷数等等。

![des2](https://github.com/kwongtailau/SweepBoom/blob/master/image/des2.png)
在类`ScoreShowDlg`中，通过读取数据库，分别将读取的数据添加的不同模式的`dataSet`当中，并且通过`DataGirlView`显示，这里的读取时按时间顺序读取的，所以`dataSet`里面的数据就已经是排列整齐的。

在`RegisterDlg`中，重要的方法是`regisSureButton_Click`，该方法用来读取用户的输入是否合法，输入合法则打开数据库添加到里面，如果非法则返回让用户重新输入。

类`BoomButton`是整个扫雷游戏的核心。考虑到点击扫雷的时候需要用到鼠标的左击右击事件，而且关系到一些按钮的打开等，特从button类当中继承就免去了自己重新画过一个按钮，并且写这些鼠标事件的麻烦。另外，属性里面重要的有`countAround`,它是每个按钮计算附近雷数的一个重要属性，`hasBoom`记录的是该按钮下隐藏的是否为雷，而`status`记录的是左右击事件的记录：`close`,`open`,`mark`。`x`与`y`记录的是当前的按钮在整一个主界面的位置。关于鼠标的双击事件，本来button里面是有双击事件的，当不知道为什么似乎被`c#`屏蔽了，所以通过单击事件，外加`timer`，重写了一个双击事件。

---

# SQL Design and Description
![sql](https://github.com/kwongtailau/SweepBoom/blob/master/image/sql.png)

![sql2](https://github.com/kwongtailau/SweepBoom/blob/master/image/sql2.png)

---

# Running Status
## Start View
![start.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/start.png)

## Register View
![register.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/register.png)

## Simple Model View
![simple.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/simple.png)

## Finish View
![finish.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/finish.png)

## Choose Level View
![choose.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/choose.png)

## Show Score View
![show.pic](https://github.com/kwongtailau/SweepBoom/blob/master/image/show.png)

---

# Problem
> 在设计当中，一开始我是使用了access数据库的，但是发现它说我缺少引擎，而且要在一个x86，即32位的环境下编译，我就将数据库换成了sql server。

