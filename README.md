# CodeTool

## 简介

> 1. 一些自用常用帮助类代码整理：

### 1.异步同步多线程_1

> 1. 异步、同步、并行、事件的区别和使用方法,通过动画效果来展示。

### 2.Log_2

> 1. 包括自定义日志类和Nlog版本二次封装日志类共2个版本。
>
> 2. 其中自定义日志类包含的功能：
>
>    ```C#
>    //自定义日志版本，不依赖任何库，特点如下：
>    //线程安全，日志异步写入文件不影响业务逻辑；
>    //支持过期文件自动清理，也可自定义清理逻辑；
>    //缓存队列有内存上限防呆，防止异常情况下内存爆满；
>    //提供默认的静态日志记录器，也支持自定义多个日志记录器；
>    //通过委托方法支持日志文件名、日志记录格式的自定义，更加自由
>    ```
>
>    
>
> 3. Nlog日志类包含的功能如下：
>
>    ```c#
>    //1.指定日志保存天数，默认30天
>    //2.订阅写日志事件
>    //3.基本的日志类别读写
>    ```

### 3.HardwareHandler_3

> 获取客户端计算机硬件及系统信息帮助类。

### 4.FTPOperation_4

> FTP服务器的文件上转和下载操作

### 5.
