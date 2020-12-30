# 死锁
当同步调用异步方法并使用.GetAwaiter().GetResult()方法或.Result属性获取结果时，同步执行的主线程阻塞等待异步方法的结果，异步方法等待主线程上拥有的同步上下文对象，此情况将造成死锁。

# Task.Yield
Task.Yield方法创建一个立即返回的awaitable。等待一个Yield可以让异步方法在执行后续的部分时返回到调用方法。可以理解为离开当前的消息队列，回到队列末尾，让处理器有时间处理其他任务。

# await
在遇到await关键字之后，系统做了以下工作：  
1.异步方法将被挂起  
2.将控制权返回给调用者  
3.使用线程池中的线程（而非额外创建新的线程）来计算await表达式的结果，所以await不会造成程序的阻塞  
4.完成对await表达式的计算之后，若await表达式后面还有代码则由执行await表达式的线程（不是调用方所在的线程）继续执行这些代码