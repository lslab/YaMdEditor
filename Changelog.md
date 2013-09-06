#2013-09-06
##修改功能
* 根据markdown风格输出html文件

#2013-09-05 
##新增功能
*  支持不同markdown 解析引擎。
*  支持GFM，TOC
##修改bug
* inputbox的imemode=on
#2013-09-04
##新增功能
* 粘贴内容格式为文本内容
* 编辑中tab改为4个空格
* 增加2个markdown paser,分别是：MarkdownSharp,SundownNet

##修改bug
* 编辑界面tab不可用。
* SundownNet dllImport问题。问题记录如下：
Platform invoke
To improve performance in interoperability with unmanaged code, incorrect calling conventions in a platform invoke now cause the application to fail. In previous versions, the marshaling layer resolved these errors up the stack.
Debugging your applications in Microsoft Visual Studio 2010 will alert you to these errors so you can correct them.
If you have binaries that cannot be updated, you can include the <NetFx40_PInvokeStackResilience> element in your application's configuration file to enable calling errors to be resolved up the stack as in earlier versions. However, this may affect the performance of your application.

This element enables you to trade faster interop marshaling for run-time resilience against incorrect platform invoke declarations.
Starting with the .NET Framework 4, a streamlined interop marshaling architecture provides a significant performance improvement for transitions from managed code to unmanaged code. In earlier versions of the .NET Framework, the marshaling layer detected incorrect platform invoke declarations on 32-bit platforms and automatically fixed the stack. The new marshaling architecture eliminates this step. As a result, transitions are very fast, but an incorrect platform invoke declaration can cause a program failure.
To make it easy to detect incorrect declarations during development, the Visual Studio debugging experience has been improved. The pInvokeStackImbalance managed debugging assistant (MDA) notifies you of incorrect platform invoke declarations when your application is running with the debugger attached.
To address scenarios where your application uses components that you cannot recompile, and that have incorrect platform invoke declarations, you can use the NetFx40_PInvokeStackResilience element. Adding this element to your application configuration file with enabled="1" opts into a compatibility mode with the behavior of earlier versions of the .NET Framework, at the cost of slower transitions. Assemblies that have been compiled against earlier versions of the .NET Framework are automatically opted into this compatibility mode, and do not need this element.

http://msdn.microsoft.com/en-us/library/ee941656(v=VS.100).aspx#core
http://msdn.microsoft.com/en-us/library/ff361650(v=vs.100).aspx


