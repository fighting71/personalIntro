
> 代理服务器 <==> 网络信息的中转站

> 功能:

1. 提高访问速度，大多数的代理服务器都有缓存功能。
2. 突破限制，也就是FQ了
3. 隐藏身份



----------
> URL

	URL(Uniform Resource Locator) 地址用于描述一个网络上的资源，基本格式如下

	schema://host[:port#]/path/.../[?query-string][#anchor]

schema			指定低层使用的协议(例如:http,https,ftp)

host			HTTP服务器的IP地址或者域名

port#			HTTP服务器的端口号，若使用默认端口(80)则可省略

path			访问资源的路径

query-string	发送给http服务器的数据

anchor-			锚

> HTTP消息结构

	Request 消息分为3部分，
	第一部分叫Request line, 
	第二部分叫Request header, 
	第三部分是body. header和body之间有个空行， 结构如下图

![](https://pic002.cnblogs.com/images/2012/263119/2012020914293943.png)

	第一行中的Method表示请求方法,比如"POST","GET", 
	Path-to-resoure表示请求的资源， 
	Http/version-number 表示HTTP协议的版本号

	当使用的是"GET" 方法的时候， body是为空的

----------

> HTTP协议是无状态的

http协议是无状态的，同一个客户端的这次请求和上次请求是没有对应关系，对http服务器来说,它并不知道这两个请求来自同一个客户端。为了解决这个问题，Web程序引入了Cookie机制来维护状态


----------

> Get和Post方法的区别

	Http协议定义了很多与服务器交互的方法，
	最基本的有4种，分别是GET,POST,PUT,DELETE. 
	一个URL地址用于描述一个网络上的资源，而HTTP中的GET, POST, PUT, DELETE就对应着对这个资源的查，改，增，删4个操作。
	我们最常见的就是GET和POST了。
	GET一般用于获取/查询资源信息，而POST一般用于更新资源信息.

我们看看GET和POST的区别

1. GET提交的数据会放在URL之后，以?分割URL和传输数据，参数之间以&相连，如EditPosts.aspx?name=test1&id=123456.  POST方法是把提交的数据放在HTTP包的Body中.

2. GET提交的数据大小有限制（因为浏览器对URL的长度有限制），而POST方法提交的数据没有限制.

3. GET方式需要使用Request.QueryString来取得变量的值，而POST方式通过Request.Form来获取变量的值。

4. GET方式提交数据，会带来安全问题，比如一个登录页面，通过GET方式提交数据时，用户名和密码将出现在URL上，如果页面可以被缓存或者其他人可以访问这台机器，就可以从历史记录获得该用户的账号和密码.

> 状态码

	Response 消息中的第一行叫做状态行，
	由HTTP协议版本号， 状态码， 状态消息 三部分组成。
	
	状态码用来告诉HTTP客户端,HTTP服务器是否产生了预期的Response.
	
	HTTP/1.1中定义了5类状态码， 状态码由三位数字组成，第一个数字定义了响应的类别
	
	1XX  提示信息 - 表示请求已被成功接收，继续处理
	
	2XX  成功 - 表示请求已被成功接收，理解，接受
	
	3XX  重定向 - 要完成请求必须进行更进一步的处理
	
	4XX  客户端错误 -  请求有语法错误或请求无法实现
	
	5XX  服务器端错误 -   服务器未能实现合法的请求

----------
author:monster

since:8/31/2018 3:02:31 PM 

direction:http protocol

source:[https://www.cnblogs.com/TankXiao/archive/2012/02/13/2342672.html](https://www.cnblogs.com/TankXiao/archive/2012/02/13/2342672.html "博文")