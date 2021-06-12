# Kula 语言
> Kula 是一个基于 .Net Framework 平台的解释型脚本语言。

![Kula_Daiamondo](https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fhbimg.b0.upaiyun.com%2F59af30fb8e979539fe816369c6dd37b06a3ee9a984f42-4G7yBG_fw658&refer=http%3A%2F%2Fhbimg.b0.upaiyun.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1624933443&t=32e57f6dcb44de881f052a290ea0eddc)

## 简介
这是一个具有即时编译器的，解释型脚本语言。    
这是由 [*HanamaruYabuki*](https://hanayabuki.github.com) 个人开发的，自拟标准的**玩具语言**。    
它可以基于 .Net Framework 4.6 (或以上) 运行在 Windows 系统的计算机上。 

Kula 语言诞生于 2021 年 5 月，并且正在高速的发展之中。    
所以，Kula 语言会在不久的未来支持越来越多的现代编程语言特性。   

## Kula语言 的特性
* 环境易部署
* 语法简单易学
* 面向过程
* 强类型 动态类型
* 面向过程编程
* 函数式编程
* 不规范的面向对象编程 ~~(如果你认为JS也是面向对象)~~
* *数组* 和 *字典* 数据容器
* 嵌入 C#

## [帮助文档 *( 点我跳转 )*](https://hanayabuki.github.io/Kula-Guide/#)
> *学习 Kula 语言不需要任何前置知识。*

## 伴生项目
* [Kula - Diana : Kula 语言的 VSCode 插件](https://github.com/HanaYabuki/Kula-Diana)
* [Kula - Guide : Kula 语言的 完全帮助文档](https://github.com/HanaYabuki/Kula-Guide)

------

## 更新日志
### kula - diamond-breath-0 (2021-6-10)
* 底层重写，分离 控制台程序 和 Kula引擎
* 允许作为DLL类库，嵌入C#程序
* 允许通过 `Queue<object>` 和 C# 交互，(当然也增加了对应函数)
* 默认启动模式改为 Release

### kula - crow-bite-1 (2021-6-6)
* 支持转义字符串
* LexToken 和 VMNode 结构调整，效率提高

### kula - crow-bite-0 (2021-6-3)
* 添加了 *作为引用类型的* **数组** **字典**
* 对应 数组和字典 增加了新的语法和内置方法
* 生硬的异常处理，以及对应的 `throw(msg:Str):None` 异常抛出函数

### kula - slider-shoot-0 (2021-6-2)
* 重新设计了函数的语法解析方式 (parser)，**实现了函数柯里化**
* 重写了字节码的解析
* 增加了少量内置函数

### kula - one-inch-2 (2021-6-1)
* 增加了 lambda 类型的词法分析支持
* 底层寻址机制重写，运行速度显著提升
* 添加了 Debug 模式下的计时功能，更改 格式化细节
* 增加了 返回值类型检查 (本来就该有的，一直忘了加

### kula - one-inch-1 (2021-5-30) (bug)
* 第三次底层重写，合并了主流程和函数流程，代码总量降低
* 扩展了 lambda 的存在形式，更改了函数的底层数据结构
* 重量级特性：**正确的闭包支持**
* ~~写的时候没注意，妈的，Lambda寻址是错的，根本不支持递归~~
* 更改了寻址方案，性能略微降低 (未来可能会优化)
* 依然略有混乱 (但有助于编码) 的错误信息

### kula - one-inch-0 (2021-5-29) (bug)
* 更多的内置函数 (输入处理，字符串解析)
* 部分底层重写，分离主流程和函数流程
* 重量级特性：**初步支持lambda演算**，**lambda懒加载** (我可是一开始就做了懒加载呢吼吼吼~！)
* 更加诡异的报错信息
* ~~*由于当前底层为引用类型，在闭包的使用中可能会出现一些诡异的现象，暂时不要过分相信Kula的闭包*~~ (one-inch-1 已修复)
* *暂未支持函数柯里化，未来的版本会对Parser进行一些调整来支持柯里化*

### kula - ice-coffin-0 (2021-5-26)
* 较为完善的基本语法
* 动态强类型系统
* 足够基本使用的内置函数
* 不完全封装的错误提示

### kula - test (2021-5-23) (这是一个可行性测试，不具备正常使用的能力)
* 测试级的语法
* 逻辑基本不能使用
* 不够完善的错误提示

------

## 项目其他信息
### 主要负责人
> 1. [会唱歌的花枝丸 - HanaYabuki on @github.com](https://github.com/HanaYabuki)

### 参与贡献代码的方式
> 1. 直接和我击剑

### 开源协议
> [GPL3.0](./LICENSE)

### FAQ
> **Q1** : Kula 语言是什么？我怎么没听说过？我需要学习他吗？        
>  
> **A1** : 要知道，Kula 暂时只是一个玩具语言，不具有 **很强的工程性 或 学习价值**，仅作为个人学习编译原理的一个中间产物。    
> 但是，如果您对这个项目感兴趣，并且 **愿意对语言加以研究** 或 **改进语言的一些细节设计**，鄙人感激不尽。      
> 
> **Q2** : 为什么叫 *Kula* 语言？    
> 
> **A2** : 因为 立项的时候在打拳皇。   
> 和 "为什么 Java 叫 Java" 同理 (🍀