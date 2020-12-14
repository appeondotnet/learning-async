# learning-async
WPF 学习笔记

## 学习目的
针对实际开发中遇到的一系列异步问题，通过深入学习，给出解决方案。

## 异步学习计划

### 第一周 熟悉异步
* [了解多线程和异步区别](https://www.cnblogs.com/tdws/p/6172207.html)
* [初步了解异步](https://docs.microsoft.com/zh-cn/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming)
* [ConfigurationAwait](https://devblogs.microsoft.com/dotnet/configureawait-faq/)

学习目标：基本了解异步编程，熟悉 TAP 模型(Task/async/await)，积累理论知识。

### 第二周 系统学习异步
* 还原死锁(UI 项目中)
* 调试反编译代码(dnSpy/.NET Reflector)，了解异步执行流程
* [系统学习 TAP](https://docs.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)

学习目标：了解 async/await 语法糖，执行上下文等运行机制，系统学习 TAP。

## 第三周 解决问题
* 提出 async void 主线程进入解决方案
* 提出/论证 ConfigurationAwait 最佳方案

## 检验学习(以是否能回答下述问题为准)
* Task.Yield() 作用
* WaitHandle 是什么
* 异步方法的标准格式
* UI 项目中死锁的原因
* 异步状态机中 -1/0 分别代表什么状态
* CancellationToken.Register() 使用场景
* ConfigurationAwait(false) 表示什么意思
* 为什么在 WPF 项目中 .Wait() 会死锁
* 为什么只有遇到真正的异步代码块时线程才会被释放
* 怎么封装一个通用的超时处理方法，且不阻断异步的传递
* 为什么内层全部使用了 await，最外层调用未使用 await，内层也不会等待
* **ASP.NET 项目每个请求一个线程，怎么处理静态变量 HttpContext.Current 的并发**
* **如何通过自定义执行上下文将所有任务放到同一个线程执行**
