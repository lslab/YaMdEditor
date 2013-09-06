#Markdown标准语法

http://daringfireball.net/projects/markdown/

##标题

Markdown 支持两种标题的语法，类 Setext 和类 atx 形式。
类 Setext 形式是用底线的形式，利用 = （最高阶标题）和 - （第二阶标题），例如：
标题1
=============
标题２
-------------
任何数量的 = 和 - 都可以有效果。
类 Atx 形式则是在行首插入 1 到 6 个 # ，对应到标题 1 到 6 阶，例如：
# 这是 H1
## 这是 H2
###### 这是 H6

你可以选择性地「闭合」类 atx 样式的标题，这纯粹只是美观用的，若是觉得这样看起来比较舒适，你就可以在行尾加上 #，而行尾的 # 数量也不用和开头一样（行首的井字符数量决定标题的阶数）：
# 这是 H1 #
## 这是 H2 ##
### 这是 H3 ######


##换行
在文字的末尾使用两个或两个以上的空格来表示换行。

##引用

行首使用>加上一个空格表示引用段落，内部可以嵌套多个引用。

语法：

> 这是一个引用，
> 这里木有换行，   
> 在这里换行了。
> > 内部嵌套

##列表

###无序列表
无序列表使用*、+或-后面加上空格来表示。

语法：

* Item 1
* Item 2
* Item 3

+ Item 1
+ Item 2
+ Item 3

- Item 1
- Item 2
- Item 3

###有序列表
有序列表使用数字加英文句号加空格表示。

语法：

1. Item 1
2. Item 2
3. Item 3

##代码区域

行内代码使用反斜杠`表示。 
代码段落则是在每行文字前加4个空格或者1个缩进符表示。

语法：

Bash中可以使用echo来进行输出。
    $ echo 'Something'
    $ echo -e '\tSomething\n'

##强调

Markdown使用*或_表示强调。

语法：

单星号 = *斜体*
单下划线 = _斜体_
双星号 = **加粗**
双下划线 = __加粗__

##水平线

如果在一行里只放三个或更多个连字符，或星号或下划线，你就会得到一个水平线标记(<hr />)。下面每一行都会得到一个水平线：

* * *

***

*****

- - -

---------------------------------------

##链接

Markdown支持两种风格的链接：Inline和Reference。

https://help.github.com/articles/github-flavored-markdown

语法：

Inline：以中括号标记显示的链接文本，后面紧跟用小括号包围的链接。如果链接有title属性，则在链接中使用空格加“title属性”。
Reference：一般应用于多个不同位置使用相同链接。通常分为两个部分，调用部分为[链接文本][ref]；定义部分可以出现在文本中的其他位置，格式为[ref]: https://github.com/lslab/YaMdEditor (可选的标题)。 
注：ref中不区分大小写。

这是一个Inline[示例](https://github.com/lslab/YaMdEditor "可选的title")。
这是一个Reference[示例][ref]。
[ref]: https://github.com/lslab/YaMdEditor

##图片

图片的使用方法基本上和链接类似，只是在中括号前加叹号。 
注：Markdown不能设置图片大小，如果必须设置则应使用HTML标记<img>。

语法：

Inline示例：![替代文本](http://www.google.com/intl/en_ALL/images/srpr/logo1w.png "可选的title")
Reference示例：![替代文本][pic]
[pic]: http://www.google.com/intl/en_ALL/images/srpr/logo1w.png "可选的title"
HTML示例：<img src="http://www.google.com/intl/en_ALL/images/srpr/logo1w.png" alt="替代文本" title="标题文本" width="200" />

##其他

###自动链接

使用尖括号，可以为输入的URL或者邮箱自动创建链接。如test@domain.com。
例如：
<https://github.com/lslab/YaMdEditor>

###分隔线

在一行中使用三个或三个以上的*、-或_可以添加分隔线，其中可以有空白，但是不能有其他字符。

###转义字符

Markdown中的转义字符为\，可以转义的有：

\\ 反斜杠
\` 反引号
\* 星号
\_ 下划线
\{\} 大括号
\[\] 中括号
\(\) 小括号
\# 井号
\+ 加号
\- 减号
\. 英文句号
\! 感叹号

#GitHub风格Markdown语法
##换行

GFM 引入的最大差异就是对换行的处理。
下面这个段落被一个换行符分隔成了两个短语：
Roses are red
Violets are blue

将被渲染为：
Roses are red
Violets are blue

##单词中的多个下划线

没有理由只把一个单词的一部分显示为斜体，尤其是当你在处理代码和那些经常出现多个下划线的名称时。因此，GFM 将忽略单词中的多个下划线。

perform_complicated_task
do_this_and_do_that_and_another_thing
将被渲染为：
perform_complicated_task
do_this_and_do_that_and_another_thing

##删除线
Strikethrough
~~Mistaken text.~~

##链接自动识别

GFM 将自动为标准的 URL 加链接，所以如果你只想链接到一个 URL（而不想设置链接文字），那你简单地输入这个 URL 就可以，它将被自动转换为一个链接。（译注：Email 地址也适用于此特性。）

##围栏式代码块
Markdown 会把每行前面空四格的文本转换为代码块。GFM 也支持这种语法，同时，还支持围栏式代码块。只要把你的代码块包裹在 ``` 之间，你就不需要通过无休止的缩进来标记代码块了。

```
require 'redcarpet'
markdown = Redcarpet.new("Hello World!")
puts markdown.to_html
```

如果你使用空格来缩进代码块，请留意列表中的代码块需要缩进 8 个空格，以确保它会被正确地标记为代码块。

##语法着色
在处理代码块方面更进一步，你可以为代码码指定语法着色效果。在围栏式代码块中，你可以指定一个可选的语言标识符，然后就可以为它启用语法着色了。举个例子，这样可以为一段 Ruby 代码着色：

```ruby
require 'redcarpet'
markdown = Redcarpet.new("Hello World!")
puts markdown.to_html
```
##表格
支持如下格式的表格。
First Header  | Second Header
------------- | -------------
Content Cell  | Content Cell
Content Cell  | Content Cell


#StackOverflow风格Markdown
http://stackoverflow.com/editing-help

#Markdown Extra
http://michelf.ca/projects/php-markdown/extra/

##围栏式代码块
代码块包裹在至少3个～之间
~~~
require 'redcarpet'
markdown = Redcarpet.new("Hello World!")
puts markdown.to_html
~~~

##表格
First Header  | Second Header
------------- | -------------
Content Cell  | Content Cell
Content Cell  | Content Cell

|First Header|Second Header|
|-------------|-------------|
|Content Cell  | Content Cell|
|Content Cell  | Content Cell|

| Tables        | Are           | Cool  |
|:------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| zebra stripes | are neat      |    $1 |

##简写
Abbreviations

PHP Markdown Extra adds supports for abbreviations (HTML tag <abbr>). How it works is pretty simple: create an abbreviation definition like this:

*[HTML]: Hyper Text Markup Language
*[W3C]:  World Wide Web Consortium
then, elsewhere in the document, write text such as:

The HTML specification
is maintained by the W3C.

and any instance of those words in the text will become:

The <abbr title="Hyper Text Markup Language">HTML</abbr> specification
is maintained by the <abbr title="World Wide Web Consortium">W3C</abbr>.

Abbreviations are case-sensitive, and will span on multiple words when defined as such. An abbreviation may also have an empty definition, in which case <abbr> tags will be added in the text but the title attribute will be omitted.

##脚注
Footnotes

Footnotes work mostly like reference-style links. A footnote is made of two things: a marker in the text that will become a superscript number; a footnote definition that will be placed in a list of footnotes at the end of the document. A footnote looks like this:

That's some text with a footnote.[^1]

[^1]: And that's the footnote.