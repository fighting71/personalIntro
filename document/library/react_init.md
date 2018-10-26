> install

1.prepare environment: node.js

	$ npm install -g cnpm --registry=https://registry.npm.taobao.org
	$ npm config set registry https://registry.npm.taobao.org
	
	安装模块
	$ cnpm install [name]

### 使用 create-react-app 快速构建 React 开发环境 ###

	$ cnpm install -g create-react-app
	$ create-react-app my-app
	$ cd my-app/
	$ npm start

项目的目录结构如下：

	my-app/
	  README.md
	  node_modules/
	  package.json
	  .gitignore
	  public/
	    favicon.ico
	    index.html
	    manifest.json
	  src/
	    App.css
	    App.js
	    App.test.js
	    index.css
	    index.js
	    logo.svg


> 直接使用
> 
 	Staticfile CDN 的 React CDN 库，地址如下：
	<script src="https://cdn.staticfile.org/react/16.4.0/umd/react.development.js"></script>
	<script src="https://cdn.staticfile.org/react-dom/16.4.0/umd/react-dom.development.js"></script>
	<!-- 生产环境中不建议使用 -->
	<script src="https://cdn.staticfile.org/babel-standalone/6.26.0/babel.min.js"></script>
	官方提供的 CDN 地址：
	
	<script src="https://unpkg.com/react@16/umd/react.development.js"></script>
	<script src="https://unpkg.com/react-dom@16/umd/react-dom.development.js"></script>
	<!-- 生产环境中不建议使用 -->
	<script src="https://unpkg.com/babel-standalone@6.15.0/babel.min.js"></script>

----------

## learning ##

	待后续深入使用后补充....

> 元素渲染


> jsx


> 组件


> State(状态)


> Props


> 事件处理


> 条件渲染


> 列表 & Keys


> 组件 API


> 组件生命周期


> AJAX


> 表单与事件


> Refs


----------

	Remark

	上手难度:***(对于熟悉js的使用及对于es6有一定了解的人没有任何压力)

	难点:
		1.在写法上并不是特别习惯(对于代码清晰度要求低的可以忽视)

		2.熟悉度的一个把握(学习一个框架 往往从常用api开始，而任何api都是需要一定的时间来记忆的。)

		3.emmm 没啥难度

	优势:
		1.清爽,写法十分具有趣味
		2.对于个人来说只是多了一些api需要记忆，其他的都能接受(大部分写法在之前都有过类似的尝试)
		3.社区帮助很全面(据说)
		4.emm ... 感觉不错


----------
author:monster

since:10/24/2018 4:54:08 PM 

direction:react 初级学习