v0.1:

开始快速撸一遍unity编辑器的部分，把之前的东西拾起来

v0.2:

1：增加对场景物体信息的基础展示，可以选中控制和自动展示 ps遇到一个坑:editor模式不支持invoke方法
2：增加编辑窗口按钮事件控制全局（单例）变量开关来控制场景物体信息的展示是否开启

v0.3:

1:mono域中操作的inspector value需要进行编译运行，手动更新inspector panel的方式进行处理对于自动化
数据更新来说简直太傻了，如果不想编译运行又可以实现自动化数据字段更新那需要怎么办呢？可以将值的修
改操作放在editor模式下的OnInspectorGUI的刷新中来进行操作。
2：序列化这一块的内容还是比较多的，我决定单列一个项目来详细研究一下这一块，项目名字就是serializeProject

v0.4

1:今天把unity不认的一些文件设置一下默认的打开程序，提高一下效率

v0.5

1：inspector中的参数我们指定类型后实际上是可以做约束的，作为可视化的一部分，当然要来个ProgressBar显示
的更舒服一下。
2：console窗口执行的都是系统的方法，我们自己操作控制的话需要用到系统映射的方式将对应editor类找到，通过
方法名获取对应方法，进行Invoke执行。
3：发现自己每次都需要查文档去看样式设计，干脆遍历出所有样式放到editor window里面，需要的时候点出来看就
好了，提高效率，简单做一个小的gm window

v0.6

1:加入Serialization数据存储，这一块很重要，编辑器不能每次都重新开始编吧，而且重要的是可以对inspector参数
做映射存档，保存同样一结构的ScriptableObject对应起来就可以做了，还是很方便的，对于美术编辑可以随便调，调
好存一份就好了
2：System.IO.Path的路径为E:\unityProjects\editorpath\editorpath\Assets;
Application.dataPath的路径为E:/unityProjects/editorpath/editorpath/Assets
注意区分


v0.7

1:做项目的时候会遇到prefab不知道在哪里被使用的情况，可以写一个对scene 列表的遍历查询来打印出对应位置就很舒服了