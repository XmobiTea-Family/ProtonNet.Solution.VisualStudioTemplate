
Remove-Item .\Release\ItemTemplates\ProtonNet\* -Recurse -Force
Remove-Item .\Release\ProjectTemplates\* -Recurse -Force

Compress-Archive -Path .\Item.XmobiTea.ProtonNet.EventHandler\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.EventHandler.zip
Compress-Archive -Path .\Item.XmobiTea.ProtonNet.ModelEventHandler\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.ModelEventHandler.zip
Compress-Archive -Path .\Item.XmobiTea.ProtonNet.ModelRequestHandler\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.ModelRequestHandler.zip
Compress-Archive -Path .\Item.XmobiTea.ProtonNet.RequestHandler\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.RequestHandler.zip
Compress-Archive -Path .\Item.XmobiTea.ProtonNet.WebApiController\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.WebApiController.zip
Compress-Archive -Path .\Item.XmobiTea.ProtonNet.WebApiHtml\* -DestinationPath .\Release\ItemTemplates\ProtonNet\Item.XmobiTea.ProtonNet.WebApiHtml.zip
Compress-Archive -Path .\Solution.XmobiTea.ProtonNet.SocketServer\* -DestinationPath .\Release\ProjectTemplates\Solution.XmobiTea.ProtonNet.SocketServer.zip
Compress-Archive -Path .\Solution.XmobiTea.ProtonNet.WebApiServer\* -DestinationPath .\Release\ProjectTemplates\Solution.XmobiTea.ProtonNet.WebApiServer.zip
