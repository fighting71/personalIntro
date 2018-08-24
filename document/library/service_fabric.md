
![root配置](https://i.imgur.com/TkQa6s9.png)

> 程序组成

![构建组成](https://docs.microsoft.com/en-us/azure/service-fabric/media/service-fabric-application-model/application-model.png)

> root组成

	1. Parameters 参数配置

	2. ServiceManifestImport 从 ServicePackage中导入。
	
		注：名称和版本必须定义且匹配

	3. DefaultServices

		用于创建service实例，其类型必须在ServiceManifest中定义

。。。 突然明白partition 是什么意思 分区。

	一个appRoot 代表一个微服务
	一个service 代表一个节点
	一个partition代表一个分区
	一个replica代表一个副本

![应用程序与服务实例，分区和副本之间的关系。](https://docs.microsoft.com/en-us/azure/service-fabric/media/service-fabric-application-model/cluster-application-instances.png)

[https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-application-model](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-application-model "应用服务 配置文件的详细说明")

[https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-services-introduction](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-services-introduction "详细说明扩展")

> 子节点组成

![简单示例](https://i.imgur.com/NPbIRSg.png)

	1.ServiceTypes

		节点标识，注册节点时必须与此名称一致

	2.CodePackage
		
		EntryPoint 配置打包的信息，工作文件等。

		EnvironmentVariables
			环境参数配置			
			配置代理地址等。。。

	3.ConfigPackage

	4.Resources 
		Endpoints 端口配置

> 代码解析【回去弄=-=】


----------

	理解

----------
author:monster

since:8/21/2018 8:49:09 AM 

direction:service fabric analysis

[https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfigurationroot?view=aspnetcore-2.1](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfigurationroot?view=aspnetcore-2.1 "api broswser")