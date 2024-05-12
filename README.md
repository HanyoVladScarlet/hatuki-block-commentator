# HatukiBlockCommentator

> 羽月方块锐评！

---

## 1. 简介

使用本程序来生成代码块.




---

## 2. 用法

### 2.1 命令行命令

代码生成器: 

载体: c# 的本地脚本 / Blazor微服务 (带实现)

本地脚本有八种命令: 

+ 帮助: `--help` / `-h` / `-?`
+ 获得版本号: `--version` / `-V`
+ 生成 target 文件: `-t [sourcepath] [targetpath]`
<!-- + 解析 target 文件: `-s [targetpath] [sourcepath]`
+ 生成 source 模板: `-s_tpl`
+ 生成 target 模板: `-t_tpl` -->

可以读取和写入csv文件(source)和txt文件(target). 有两套规则, 分别对应文件注释和成员注释.

文件注释: 

+ 第一行 -- 语言类型(目前只支持py和c#), 行宽, 类型(文件注释)
+ 第二行 -- 项目名称, 文件名称, 一行简介
+ 第三行 -- 作者, 创建日期, 更新日期 (缺省值)
+ 第四行起 -- 块类别, 成员名称, 介绍
  + 其中块类别是数字, [event,  field,  function]

成员注释: 

+ 第一行 -- 语言类型(目前只支持py和c#), 行宽, 类型(成员注释)
+ 第二行 -- 最后修改者, 改动内容, 一行简介
+ 第三行 -- 作者, 创建日期, 更新日期 (缺省值)
+ 第四行 -- 标题, 注意事项, 详细描述

> 成员注释的内容不合理, 需要进行修改.

### 2.2 示例

下载 Release 版本的 `HatukiBlockCommentator.exe` 文件, 并复制到一个文件夹 (这里以桌面举例). 确认可执行文件名称无误后, 在桌面新建一个文件 `demo.csv`, 将以下内容复制到文件中并保存.

+ 示例文件 `demo.csv`：

```csv
cs, 96, file,
Mutopia, IDestroyableEntity, IDestroyable is an interface as data holder associated with hitpoints and other data which could affect on entity's state of being alive or not.
Hatuki, 2024-05-09, 2024-05-10,
e, IDestroyableEntity.OnDestroy, Invoke when entity is destroyed.
e, IDestroyableEntity.OnTakeDamage, Invoke when entity is taking damage.
f, IsAlive, False if hp is under zero.
f, CurrentHitPoint, Cut down when taking damage.
f, MaxHitPoint, The maximum value of hp.
f, HitPointRegainRate, Current hp of the entity regains by time with second as unit.
f, IsKillable, Whether the entity can be killed. Some skills can prevent entity from dying immediately.
m, IDestroyableEntity.TakeDamage, Take damage of a certain type from source entity.
m, IDestroyableEntity.KillSelf, Kill this entity if hp is under zero.
```

 在 Powershell 中输入以下命令.

```dotnetcli
cd ~\Desktop           # 将pwd切换到桌面.
.\HatukiBlockCommentator.exe -t demo.csv demo.txt
```

桌面上会多出一个 `demo.txt` 的文件, 其内容如下：

+ 生成的文件 `demo.txt`：

```dotnetcli
/***********************************************************************************************
*                                                                                              *
*                                    Project Name : Mutopia                                    *
*                                                                                              *
*                               File Name :  IDestroyableEntity                                *
*                                                                                              *
*                                     Programmer : Hatuki                                      *
*                                                                                              *
*                                     Create : 2024-05-09                                      *
*                                                                                              *
*                                     Update : 2024-05-10                                      *
*                                                                                              *
*----------------------------------------------------------------------------------------------*
*                                                                                              *
*  IDestroyable is an interface as data holder associated with hitpoints and other data which  *
*                    could affect on entity's state of being alive or not.                     *
*                                                                                              *
*----------------------------------------------------------------------------------------------*
* Events:                                                                                      *
*   IDestroyableEntity.OnDestroy -- Invoke when entity is destroyed.                           *
*   IDestroyableEntity.OnTakeDamage -- Invoke when entity is taking damage.                    *
*----------------------------------------------------------------------------------------------*
* Fields:                                                                                      *
*   CurrentHitPoint -- Cut down when taking damage.                                            *
*   HitPointRegainRate -- Current hp of the entity regains by time with second as unit.        *
*   IsAlive -- False if hp is under zero.                                                      *
*   IsKillable -- Whether the entity can be killed. Some skills can prevent entity from dying  *
* immediately.                                                                                 *
*   MaxHitPoint -- The maximum value of hp.                                                    *
*----------------------------------------------------------------------------------------------*
* Methods:                                                                                     *
*   IDestroyableEntity.KillSelf -- Kill this entity if hp is under zero.                       *
*   IDestroyableEntity.TakeDamage -- Take damage of a certain type from source entity.         *
*==============================================================================================*/
```


可以尝试将 `demo.csv` 中的内容修改为如下内容：

```csv
py, 96, m,
Hatuki, Obsoleted implementation deleted, Used for address a comment.
4Chan, 2024-05-12, 2024-05-13,
BlockCommentator.Generate, None., None.
```

再次运行上述命令, 文件的内容发生了变化.

+ 生成的文件 `demo.txt`：

```python
#==============================================================================================#
#                                  BlockCommentator.Generate                                   #
#                                                                                              #
#                                            None.                                             #
#                                                                                              #
# Created : 4Chan at 2024-05-12                                                                #
#                                                                                              #
# About: Used for address a comment.                                                           #
#                                                                                              #
# Updated : Hatuki at 2024-05-13                                                               #
#                                                                                              #
# Modification: Obsoleted implementation deleted                                               #
#                                                                                              #
# Warning: None.                                                                               #
#==============================================================================================#
```

如此一来便可以方便地为代码添加醒目的注释了。

## 3. 编译

使用 `.net 8.0` 以上版本进行编译。


